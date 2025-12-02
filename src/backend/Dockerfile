# src/backend/Dockerfile

FROM python:3.12-slim

# Install system deps (for psycopg2 etc.)
RUN apt-get update && apt-get install -y \
    build-essential \
    libpq-dev \
  && rm -rf /var/lib/apt/lists/*

# Create app directory
WORKDIR /app

# Install Python deps first (better cache)
COPY requirements.txt .
RUN pip install --no-cache-dir -r requirements.txt

# Copy backend source code into the image
COPY . /app/backend

# Don't buffer Python output
ENV PYTHONUNBUFFERED=1

# Expose the port Flask/Gunicorn will listen on
EXPOSE 8000

# Start the app with Gunicorn
# api.api:app -> /app/api/api.py must define app = Flask(__name__)`
CMD ["gunicorn", "-b", "0.0.0.0:8000", "api.api:app"]
