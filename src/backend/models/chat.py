from datetime import datetime
from backend.api.extensions import db

class ChatMessage(db.Model):
    __tablename__ = "chat_messages"

    id = db.Column(db.Integer, primary_key=True)
    user_id = db.Column(db.String, index=True, nullable=False)
    message = db.Column(db.String, nullable=False)
    reply = db.Column(db.String, nullable=False)
    created_at = db.Column(db.DateTime, nullable=False, default=datetime.utcnow, index=True)