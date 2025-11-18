# Docker Secrets Setup

This directory contains example files for Docker secrets. 

## Setup Instructions

1. Copy this directory to create your actual secrets directory:
   ```bash
   cp -r secrets.example secrets
   ```

2. Edit `secrets/db_password.txt` and replace `CHANGE_ME_IN_PRODUCTION` with a strong password.

3. **Important**: Never commit the `secrets/` directory to version control. It is already included in `.gitignore`.

## Security Best Practices

- Use strong, randomly generated passwords for production environments
- Consider using a password manager or secret management service for production deployments
- Rotate passwords regularly
- Never share passwords in plain text or commit them to version control

## Files

- `db_password.txt`: PostgreSQL database password used by both the database and the application
