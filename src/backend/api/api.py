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
        (User.username == username) | (User.email == email)
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
    custom_system_prompt = data.get("system_prompt")  # Optional

    if not user_message:
        return jsonify({"error": "message is required"}), 400
    if not user_id:
        return jsonify({"error": "userid is required"}), 400

    bot_name = request.headers.get("X-Bot-Name", "Default")
    ts = timestamp or datetime.now().isoformat()

    # Known built-in bots use fixed prompts
    BUILT_IN_BOTS = {"Bob", "Alice", "Mrs Wong", "Personalisable"}

    if bot_name in BUILT_IN_BOTS:
        # handles Personalisable + custom_system_prompt
        system_prompt = get_system_prompt(bot_name, custom_system_prompt)
    else:
        # 2) Custom bots: try Redis first
        system_prompt = get_bot_from_cache(user_id, bot_name)

        # If client sends a new custom prompt, override + save to Redis
        if custom_system_prompt:
            system_prompt = custom_system_prompt

            log_entry = {
                "user_id": user_id,
                "bot_name": bot_name,
                "time_created": ts,
                "system_prompt": system_prompt,
            }

            redis_key = f"user:chatbots:{user_id}"
            raw = redis_client.get(redis_key)
            try:
                bots = json.loads(raw) if raw else {}
            except json.JSONDecodeError:
                bots = {}

            bots[bot_name] = log_entry
            redis_client.set(redis_key, json.dumps(bots))

        # Safety fallback if there is no prompt at all
        if system_prompt is None:
            system_prompt = (
                "You are a friendly, helpful assistant. "
                "Be polite, safe, and dominant."
            )

    # Calling the model
    completion = openai.chat.completions.create(
        model="gpt-4.1-mini",
        messages=[
            {"role": "system", "content": system_prompt},
            {"role": "user", "content": user_message},
        ],
    )

    reply = completion.choices[0].message.content

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
    redis_client.ltrim(redis_key, -100, -1)

    return jsonify({
        "userid": user_id,
        "timestamp": ts,
        "message": user_message,
        "reply": reply,
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
        return None

@app.get("/llm/chat/logs/<int:user_id>/<bot_name>")
def get_chat_logs(user_id, bot_name):
    redis_key = f"chat:{user_id}:{bot_name}"
    raw_items = redis_client.lrange(redis_key, 0, -1)
    logs = [json.loads(item) for item in raw_items]
    return jsonify(logs)

@app.get("/llm/users/bots/<int:user_id>")
def get_bots_logs(user_id):
    redis_key = f"user:chatbots:{user_id}"
    raw = redis_client.get(redis_key)
    if not raw:
        return jsonify({}), 200
    try:
        bots = json.loads(raw)  # dict: {bot_name: log_entry}
    except json.JSONDecodeError:
        bots = {}
    return jsonify(bots)

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

# For admin accounts (will create later)
@app.post("/admin/clear-all-chats")
def clear_all():
    for key in redis_client.scan_iter("chat:*"):
        redis_client.delete(key)
    return {"status": "all chats cleared"}

def get_bot_from_cache(userid, bot_name):
    redis_key = f"user:chatbots:{userid}"
    raw = redis_client.get(redis_key)
    if raw is None:
        return None

    try:
        bots = json.loads(raw)  # dict: {bot_name: log_entry}
    except json.JSONDecodeError:
        return None

    bot = bots.get(bot_name)
    if not bot:
        return None

    return bot.get("system_prompt")

@app.get("/health")
def health():
    return {"status": "ok"}


