import os
from dotenv import load_dotenv


load_dotenv()  # looks for .env in the current or parent dirs

# Going to use to configure the Flask app database
POSTGRES_URI = (
    f"postgresql://{os.environ['POSTGRES_USER']}:"
    f"{os.environ['POSTGRES_PASSWORD']}@"
    f"{os.environ['POSTGRES_HOST']}:"
    f"{os.environ['POSTGRES_PORT']}/"
    f"{os.environ['POSTGRES_DB']}"
)

REDIS_URL = f"redis://{os.environ['REDIS_HOST']}:{os.environ['REDIS_PORT']}/0"
