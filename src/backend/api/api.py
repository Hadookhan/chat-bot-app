from flask import Flask, request, jsonify
from .config import POSTGRES_URI, REDIS_URL, Config
import openai
import os
from .extensions import db
from models.chat import ChatMessage

openai.api_key = os.environ["OPENAI_API_KEY"]

app = Flask(__name__)

app.config["SQLALCHEMY_DATABASE_URI"] = os.getenv(
    "DATABASE_URL",
    "postgresql+psycopg2://chatbot_user:super_secure_password@db:5432/chatbot_db",
)
app.config["SQLALCHEMY_TRACK_MODIFICATIONS"] = False

print("DB URI is:", app.config.get("SQLALCHEMY_DATABASE_URI"))

db.init_app(app)

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

    # Will create user in DB here

    return jsonify({"message": "user created"}), 201

@app.get("/login")
def login():
    return "login page"

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

    # There must be a message from the user to talk to llm
    if not user_message:
        return jsonify({"error": "message is required"}), 400
    
    completion = openai.chat.completions.create(
        model = "gpt-4.1-mini",
        messages=[
            {"role": "system", "content": "You are a friendly chatbot"}, # Will change content prompt later
            {"role": "user", "content": user_message},
        ],
    )

    reply = completion.choices[0].message.content
    return jsonify({
        "userid" : user_id,
        "timestamp" : timestamp,
        "message" : user_message,
        "reply": reply
        })

@app.get("/health")
def health():
    return {"status": "ok"}

