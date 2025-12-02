from datetime import datetime
from api.extensions import db

class ChatMessage(db.Model):
    __tablename__ = "chat_messages"

    id = db.Column(db.Integer, primary_key=True)
    user_id = db.Column(db.Integer, db.ForeignKey("users.id"), nullable=False)
    message = db.Column(db.String, nullable=False)
    reply = db.Column(db.String, nullable=False)
    created_at = db.Column(db.DateTime, nullable=False, default=datetime.now, index=True)

    # Connects users -> chat_messages
    user = db.relationship("User", backref="chat_messages")