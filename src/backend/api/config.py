import os
from dotenv import load_dotenv


load_dotenv()  # looks for .env in the current or parent dirs

# Use to configure the database Flask will use
POSTGRES_URI = (
    f"postgresql://{os.environ['POSTGRES_USER']}:"
    f"{os.environ['POSTGRES_PASSWORD']}@"
    f"{os.environ['POSTGRES_HOST']}:"
    f"{os.environ['POSTGRES_PORT']}/"
    f"{os.environ['POSTGRES_DB']}"
)

# Same thing as database above but for caching with redis
REDIS_URL = f"redis://{os.environ['REDIS_HOST']}:{os.environ['REDIS_PORT']}/0"

class Config:

    SQLALCHEMY_DATABASE_URI = os.getenv(
        "DATABASE_URL",
        "postgresql+psycopg2://chatbot:chatbot_password@db:5432/chatbot_db"
        )
    SQLALCHEMY_TRACK_MODIFICATIONS = False
