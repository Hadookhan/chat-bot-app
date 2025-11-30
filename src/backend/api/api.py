from flask import Flask
from .config import POSTGRES_URI, REDIS_URL


app = Flask(__name__)

app.config["POSTGRES_URI"] = POSTGRES_URI
app.config["REDIS_URL"] = REDIS_URL

@app.get("/")
def home():
    return "Hello from Flask!"

@app.get("/signup")
def signup():
    return "signup page"

@app.get("/login")
def login():
    return "login page"

@app.get("/health")
def health():
    return {"status": "ok"}

