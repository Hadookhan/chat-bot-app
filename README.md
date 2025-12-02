# CHATBOT APP
A system that enables users to talk to a GPT AI, through a desktop **AND** mobile application!
Uses a C# Frontend application, talks to a Python backend service.


## DEVELOPMENT PROCESS (CURRENT WORK)
- Set up SQL for Relational databases for multiple users using PostgreSQL.
- Set up Flask to add URL endpoints for API.
- Configured Nginx, acting as a CDN to forward traffic to Flask API's.
- Configured Docker-compose to containerize: API, Database, Redis, Nginx.
- Created CI/CD pipeline, which automates testing and deployment.
- Hosted AWS EC2 server.
- Connected CD pipeline to auto-deploy docker containers on EC2 server.
- Hosted AWS CloudFront to front for Nginx as a CDN over web using HTTPS for secure API data.