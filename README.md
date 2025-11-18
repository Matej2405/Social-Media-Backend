# Social-Media-Backend

A social media backend application built with .NET 8 and PostgreSQL using Clean Architecture.

## Project Roadmap
1. Main clean-up - clean up the old project files so we have a fresh suite for starting out
2. Backend setup - Setup Clean-Architecture project (Domain, Application, Infrastructure, Web, Tests) that is using PostgreSQL.
3. Dockerizing the app - we want to enable Docker for our application so that anyone who works on our project has the same environment.
4. CI/CD setup

## Getting Started

### Prerequisites
- Docker and Docker Compose
- .NET 8 SDK (for local development)

### Running with Docker

1. **Set up secrets** (required for first-time setup):
   ```bash
   # Copy the example secrets directory
   cp -r secrets.example secrets
   
   # Edit the password file with a strong password
   nano secrets/db_password.txt
   ```

2. **Build and run the application**:
   ```bash
   # Build the Docker image
   docker build -t socialmediaapp:latest .
   
   # Start all services
   docker compose up -d
   ```

3. **Access the application**:
   - Application: http://localhost:8081
   - PostgreSQL: localhost:5432

4. **Stop the application**:
   ```bash
   docker compose down
   ```

### Security Notes

- Database credentials are managed using Docker secrets (see `secrets.example/README.md`)
- Never commit the `secrets/` directory to version control
- Use strong, randomly generated passwords for production environments
- The default password in `secrets.example/db_password.txt` is for demonstration only and must be changed