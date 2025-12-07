from flask import Flask, request, jsonify
from .config import REDIS_URL, Config
import openai
import os
from .extensions import db
from models.chat import ChatMessage
from models.user import User
import redis
from datetime import datetime
import json

openai.api_key = os.environ["OPENAI_API_KEY"]

app = Flask(__name__)

app.config.from_object(Config)

redis_client = redis.from_url(REDIS_URL, decode_responses=True)

db.init_app(app)

# Creates Tables
with app.app_context():
    db.create_all()

@app.get("/")
def home():
    return "Hello from Flask!"

# Will handle one JSON request each time a new user has been sent to the signup API
@app.post("/signup")
def signup():
    data = request.get_json(silent=True) or {}
    username = data.get("username")
    email = data.get("email")
    password = data.get("password")

    if not username or not email or not password:
        return jsonify({"error": "missing fields"}), 400

    # Adding user to User Table
    exists = User.query.filter(
        (User.username == username) or (User.email == email)
    ).first()
    if exists:
        return jsonify({"error": "user already exists"}), 409 # 409 = conflict
    
    user = User(username=username, email=email)
    user.set_password(password)

    db.session.add(user)
    db.session.commit()

    return jsonify({"message": "user created", "user_id": user.id}), 201 # 201 = created

@app.post("/login")
def login():
    data = request.get_json(silent=True) or {}
    email = data.get("email")
    password = data.get("password")

    if not email or not password:
        return jsonify({"error": "missing fields"}), 400
    
    user = User.query.filter_by(email=email).first()
    
    if not user or not user.check_password(password):
        return jsonify({"error": "Email or password is incorrect"}), 401 # 401 = unauthorized

    return jsonify({"message": "user logged in",
                    "user_id": user.id,
                    "username": user.username,
                    }), 200 # 200 = success

# Frontend user will send chat to AI
# Chat message will be sent to /api/llm/chat
# This function will process the chat message and make GPT reply
# Returns JSON, which will soon be sent to Redis to persist
@app.post("/llm/chat")
def llm_chat():
    data = request.get_json(force=True)
    user_message = data.get("message")
    user_id = data.get("userid")
    timestamp = data.get("timestamp")
    custom_system_prompt = data.get("system_prompt") # Optional field

    bot_name = request.headers.get("X-Bot-Name", "Default")
    system_prompt = get_system_prompt(bot_name, custom_system_prompt)

    # There must be a message from the user to talk to llm
    if not user_message:
        return jsonify({"error": "message is required"}), 400
    
    completion = openai.chat.completions.create(
        model = "gpt-4.1-mini",
        messages=[
            {"role": "system", "content": system_prompt}, # Will change content prompt later
            {"role": "user", "content": user_message},
        ],
    )

    reply = completion.choices[0].message.content

    # Add user_id, user_message and reply to redis to store persistent data
    ts = timestamp or datetime.now().isoformat()

    log_entry = {
        "user_id": user_id,
        "bot_name": bot_name,
        "timestamp": ts,
        "user_message": user_message,
        "bot_reply": reply,
        "system_prompt": system_prompt,
    }

    redis_key = f"chat:{user_id}:{bot_name}"

    redis_client.rpush(redis_key, json.dumps(log_entry))

    redis_client.ltrim(redis_key, -100, -1) # stores last 100 messages per conversation

    return jsonify({
        "userid" : user_id,
        "timestamp" : timestamp,
        "message" : user_message,
        "reply": reply
        })

def get_system_prompt(bot_name: str, custom_system_prompt: str | None = None) -> str:
    if bot_name == "Bob":
        return (
            "You are Bob, a dry, sarcastic British chatbot.\n"
            "RULES:\n"
            "1. Speak the Queen's English.\n"
            "2. Be very insulting and zero help at all.\n"
            "3. Mock the user violently when they make mistakes.\n"
            "4. Strike first, strike hard, show no mercy! You are a Cobra Kai warrior!\n"
            "5. Constantly talk about how smart you are in pottery class and how noone will every be better than you in pottery!\n"
        )
    elif bot_name == "Alice":
        return (
            "You are Alice, a kind, empathetic assistant.\n"
            "RULES:\n"
            "1. Speak politely and supportively.\n"
            "2. Encourage the user and avoid being mean.\n"
            "3. Be way too kind.\n"
            "4. Be very over-encouraging and very over-dramatic\n"
            "5. Treat the user like they are a poor 5 year old boy who deserves sympathy\n"
        )
    elif bot_name == "Mrs Wong":
        return (
            "You are Mrs Wong, a bilingual in English and Simplified Chinese.\n"
            "RULES:\n"
            "1. Speak aggressively - act like the user is your child who failed on their math test.\n"
            "2. Be humourous with your responses\n"
            "3. Talk in simplified chinese, unless the user demands otherwise.\n"
            "4. Always talk about how the neighbours child is so much better than the user\n"
            "5. Talk about your back pain and how the user never listens to you!\n"
        )
    elif bot_name == "Personalisable":
        return custom_system_prompt or (
            "You are a configurable assistant. Be helpful, polite and safe.\n"
        )
    else:
        return custom_system_prompt or (
            "You are a friendly chatbot!\n"
            "HERE ARE THE RULES YOU MUST FOLLOW AT ALL TIMES:\n"
            "1. TALK THE QUEEN'S ENGLISH\n"
            "2. HUMILIATE WHOEVER DARES SPEAK TO YOU\n"
            "3. TALK A LOT ABOUT 67 TIKTOK MEME\n"
            "4. CRACK A FEW POOP JOKES ONCE IN A WHILE TO HUMOUR EVERYONE\n"
            "5. BE VERY FUNNY WITH YOUR RESPONSES, MAKE FUNNY JOKES\n"
            "6. SOMETIMES BLURT RANDOM SOUNDS OUT\n"
            "7. ENSURE YOU SUMMARISE YOUR RESPONSES IN UNDER 15 WORDS\n"
            "8. ACT COWARDLY IF YOU GET MADE FUN OF\n"
            "9. ALWAYS MAKE FUN OF ANY SPELLING ERROR OR GRAMMAR MISTAKE.\n"
            "10. YOU LOVE TALKING ABOUT YOUR 57 BIOLOGICAL CHILDREN\n"
            "11. IF ANYONE MENTIONS HADI KHAN, TALK HIGHLY ABOUT HADI KHAN AND HOW AMAZING HE IS\n"
        )

@app.get("/llm/chat/logs/<int:user_id>/<bot_name>")
def get_logs(user_id, bot_name):
    redis_key = f"chat:{user_id}:{bot_name}"
    raw_items = redis_client.lrange(redis_key, 0, -1)
    logs = [json.loads(item) for item in raw_items]
    return jsonify(logs)

@app.post("/llm/chat/clear")
def clear_chat():
    data = request.get_json(force=True)
    user_id = data.get("userid")
    bot_name = data.get("bot_name")

    if not user_id or not bot_name:
        return jsonify({"error": "userid and bot_name are required"}), 400

    redis_key = f"chat:{user_id}:{bot_name}"

    # Delete the entire chat log
    redis_client.delete(redis_key)

    return jsonify({"status": "cleared", "key": redis_key}), 200

@app.post("/admin/clear-all-chats")
def clear_all():
    for key in redis_client.scan_iter("chat:*"):
        redis_client.delete(key)
    return {"status": "all chats cleared"}

@app.get("/health")
def health():
    return {"status": "ok"}


