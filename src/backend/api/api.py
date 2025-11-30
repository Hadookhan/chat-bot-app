from flask import Flask, request, jsonify
from .config import POSTGRES_URI, REDIS_URL
import openai
import os

openai.api_key = os.environ["OPENAI_API_KEY"]

app = Flask(__name__)

app.config["POSTGRES_URI"] = POSTGRES_URI
app.config["REDIS_URL"] = REDIS_URL

# Pages will store API data entered from the frontend and 

@app.get("/")
def home():
    return "Hello from Flask!"

# Will handle one JSON request each time signup API is called
@app.get("/signup")
def signup():
    data = request.get_json(force=True)

    username = data.get("username")
    email = data.get("email")
    password = data.get("password")

    if not username or not email or not password:
        return jsonify({"error": "Username, email or password is blank"}), 400

    return "signup page"

@app.get("/login")
def login():
    return "login page"

@app.post("/api/llm/chat")
def llm_chat():
    data = request.get_json(force=True)
    user_message = data.get("message")

    # There must be a message from the user to talk to llm
    if not user_message:
        return jsonify({"error": "message is required"}), 400
    
    completion = openai.ChatCompletion.create(
        model = "gpt-4.1-mini",
        messages=[
            {"role": "system", "content": "You are a friendly chatbot"}, # Will change content prompt later
            {"role": "user", "content": user_message},
        ],
    )

    reply = completion.choices[0].message["content"]
    return jsonify({"reply": reply})

@app.get("/health")
def health():
    return {"status": "ok"}

