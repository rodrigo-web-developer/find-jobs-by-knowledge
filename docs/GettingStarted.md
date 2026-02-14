# Getting Started Guide

## Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js 18+](https://nodejs.org/) and npm
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (optional, for containerized deployment)

## Quick Start Options

### Option 1: Docker Compose (Recommended for Quick Testing)

The easiest way to run the entire application stack:

```bash
# Clone the repository
git clone https://github.com/rodrigo-web-developer/find-jobs-by-knowledge.git
cd find-jobs-by-knowledge

# Start all services
docker-compose up -d

# Wait for services to start (about 30 seconds)
# Then access:
# - Frontend: http://localhost:3000
# - API: http://localhost:5034
# - Database: localhost:5432

# View logs
docker-compose logs -f

# Stop all services
docker-compose down
```

### Option 2: .NET Aspire (Recommended for Development)

The best option for active development with full orchestration:

```bash
# Clone the repository
git clone https://github.com/rodrigo-web-developer/find-jobs-by-knowledge.git
cd find-jobs-by-knowledge

# Run the AppHost
cd src/FindJobsByKnowledge.AppHost
dotnet run

# The Aspire dashboard will open automatically in your browser
# It shows all running services, logs, and health status
# Access the API through the dashboard
```

### Option 3: Run Services Individually

For more control during development:

#### Start the Backend API

```bash
# Navigate to the API project
cd src/FindJobsByKnowledge.Api

# Ensure you have PostgreSQL running
# Update connection string in appsettings.json if needed

# Run the API
dotnet run

# API will be available at http://localhost:5034
```

#### Start the Frontend

```bash
# Open a new terminal
cd frontend

# Install dependencies (first time only)
npm install

# Start the development server
npm start

# Frontend will open at http://localhost:3000
```

## Database Setup

### Using Aspire or Docker Compose

The database is automatically created and managed. No manual setup required!

### Manual Setup

If running services individually:

1. Install PostgreSQL
2. Create a database named `jobsdb`
3. Update the connection string in `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "jobsdb": "Host=localhost;Database=jobsdb;Username=your_user;Password=your_password"
   }
   ```
4. Apply migrations:
   ```bash
   cd src/FindJobsByKnowledge.Repository
   dotnet ef database update --startup-project ../FindJobsByKnowledge.Api
   ```

## Testing the Application

### Add Sample Data

You can use the API to add sample jobs:

```bash
curl -X POST http://localhost:5034/api/jobs \
  -H "Content-Type: application/json" \
  -d '{
    "title": "Senior Software Engineer",
    "company": "Tech Corp",
    "description": "Looking for an experienced developer",
    "location": "San Francisco, CA",
    "salary": 150000,
    "postedDate": "2024-01-01T00:00:00Z",
    "requiredKnowledge": ["C#", "React", "PostgreSQL"]
  }'
```

### Search Jobs

1. Open http://localhost:3000
2. Enter a technology in the search box (e.g., "React", "C#", "PostgreSQL")
3. Click Search
4. View matching jobs

## Development Workflow

### Making Code Changes

1. **Backend Changes:**
   - Edit files in `src/FindJobsByKnowledge.Api`, `src/FindJobsByKnowledge.Domain`, or `src/FindJobsByKnowledge.Repository`
   - The API will automatically restart (if using `dotnet watch run`)
   
2. **Frontend Changes:**
   - Edit files in `frontend/src`
   - Changes are hot-reloaded automatically

3. **Database Changes:**
   - Add or modify entities in `FindJobsByKnowledge.Domain/Entities`
   - Update DbContext in `FindJobsByKnowledge.Repository/Data`
   - Create migration:
     ```bash
     cd src/FindJobsByKnowledge.Repository
     dotnet ef migrations add YourMigrationName --startup-project ../FindJobsByKnowledge.Api
     ```
   - Apply migration:
     ```bash
     dotnet ef database update --startup-project ../FindJobsByKnowledge.Api
     ```

### Building for Production

#### Backend
```bash
cd src/FindJobsByKnowledge.Api
dotnet publish -c Release -o ./publish
```

#### Frontend
```bash
cd frontend
npm run build
# Output will be in the 'build' folder
```

#### Docker Images
```bash
# Build API image
docker build -f Dockerfile.api -t findjobs-api:latest .

# Build Frontend image
docker build -f Dockerfile.frontend -t findjobs-frontend:latest .
```

## Troubleshooting

### Port Already in Use

If you get "port already in use" errors:

- **API (port 5034)**: Change in `src/FindJobsByKnowledge.Api/Properties/launchSettings.json`
- **Frontend (port 3000)**: Use `PORT=3001 npm start` to use a different port
- **Database (port 5432)**: Change in docker-compose.yml or your PostgreSQL config

### Database Connection Errors

1. Ensure PostgreSQL is running
2. Check connection string in appsettings.json
3. Verify database exists: `psql -U postgres -l`
4. Check migrations are applied: `dotnet ef database update`

### Frontend Can't Connect to API

1. Verify API is running: `curl http://localhost:5034/api/jobs`
2. Check CORS settings in API Program.cs
3. Update `REACT_APP_API_URL` environment variable if API is on different port

### Docker Issues

```bash
# View container logs
docker-compose logs api
docker-compose logs frontend
docker-compose logs postgres

# Rebuild containers
docker-compose build --no-cache

# Clean up
docker-compose down -v
docker system prune -a
```

## Environment Variables

### Backend (.env or environment)
```
ASPNETCORE_ENVIRONMENT=Development
ConnectionStrings__jobsdb=Host=localhost;Database=jobsdb;Username=postgres;Password=postgres
```

### Frontend (.env.local in frontend folder)
```
REACT_APP_API_URL=http://localhost:5034
```

## Next Steps

- Read [docs/Structure.md](Structure.md) for architecture details
- Check out the API documentation at http://localhost:5034/swagger (if enabled)
- Explore the Aspire dashboard for monitoring and diagnostics
- Add authentication and authorization
- Implement advanced filtering and search features
- Add unit and integration tests

## Getting Help

- Check [docs/Structure.md](Structure.md) for architecture information
- Review API endpoints in `src/FindJobsByKnowledge.Api/Controllers`
- Examine database schema in `src/FindJobsByKnowledge.Repository/Data/ApplicationDbContext.cs`
- Read component documentation in frontend source files

## Common Commands Reference

```bash
# .NET Commands
dotnet build                  # Build solution
dotnet test                   # Run tests
dotnet run                    # Run project
dotnet ef migrations add Name # Create migration
dotnet ef database update     # Apply migrations

# npm Commands
npm install                   # Install dependencies
npm start                     # Start dev server
npm run build                 # Build for production
npm test                      # Run tests

# Docker Commands
docker-compose up -d          # Start services
docker-compose down           # Stop services
docker-compose logs -f        # View logs
docker-compose ps             # List services
```
