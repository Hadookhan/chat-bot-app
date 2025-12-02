# CHATBOT APP
A system that enables users to talk to a GPT AI, through a desktop **AND** mobile application!
Uses a C# Frontend application, talks to a Python backend service.


## DEVELOPMENT PROCESS (CURRENT WORK)
- Set up SQL for Relational databases for multiple users using **PostgreSQL**.
- Set up **Flask** to add URL endpoints for API.
- Configured **Nginx**, acting as a CDN to forward traffic to Flask API's.
- Uses **Docker** to run backend instance on **gunicorn**.
- Uses **SQLAlchemy** to configure pythonic written databases.
- Configured **Docker-compose** to containerize: API, Database, Redis, Nginx.
- Created **CI/CD pipeline**, which automates testing and deployment.
- Hosted **AWS EC2** server.
- Connected CD pipeline to **auto-deploy docker containers on EC2 server**.
- Hosted **AWS CloudFront** to front for Nginx as a CDN over web using *HTTPS* for secure API data.

| Category | Skills |
|---|---|
| Backend & APIs | ![Python](https://img.shields.io/badge/Python-3670A0?style=for-the-badge&logo=python&logoColor=ffdd54) ![Flask](https://img.shields.io/badge/Flask-%23000?style=for-the-badge&logo=flask&logoColor=white) ![NGINX](https://img.shields.io/badge/Nginx-009639?logo=nginx&logoColor=white&style=for-the-badge) |
| Frontend | ![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white) |
| Databases | ![SQL](https://img.shields.io/badge/SQL-%23007ACC?style=for-the-badge&logo=sqlite&logoColor=white) ![Redis](https://img.shields.io/badge/Redis-DC382D?style=for-the-badge&logo=redis&logoColor=white) ![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white) ![SQLAlchemy](https://img.shields.io/badge/SQLAlchemy-306998?logo=python&logoColor=white) |
| Cloud |  ![AWS EC2](https://img.shields.io/badge/AWS%20EC2-FF9900?style=for-the-badge&logo=amazonwebservices&logoColor=white) ![AWS CloudFront](https://img.shields.io/badge/AWS%20CloudFront-FF9900?style=for-the-badge&logo=amazonwebservices&logoColor=white) |
| AI |  ![OpenAI](https://img.shields.io/badge/GPT-412991?style=for-the-badge&logo=openai&logoColor=white) |
| Workflow Tools | ![Git](https://img.shields.io/badge/Git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white) ![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white) ![Docker](https://img.shields.io/badge/Docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white) ![Docker Compose](https://img.shields.io/badge/Docker%20Compose-2496ED?style=for-the-badge&logo=docker&logoColor=pink) ![Linux](https://img.shields.io/badge/Linux-FCC624?style=for-the-badge&logo=linux&logoColor=black) |