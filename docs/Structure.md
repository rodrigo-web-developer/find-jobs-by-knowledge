# Find Jobs by Knowledge - Project Structure

## Overview
This is a modern web application for finding jobs based on required knowledge/skills. The solution uses .NET Aspire for orchestration, ASP.NET Core 10 for the backend API, and React with TypeScript for the frontend.

## Architecture

### Clean Architecture Layers

The backend follows Clean Architecture principles with clear separation of concerns:

1. **Domain Layer** (`FindJobsByKnowledge.Domain`)
   - Contains business entities and core domain models
   - No dependencies on other layers
   - Pure business logic

2. **Repository Layer** (`FindJobsByKnowledge.Repository`)
   - Data access layer using Entity Framework Core
   - Implements repository pattern
   - Manages database context and migrations
   - Depends on Domain layer

3. **API Layer** (`FindJobsByKnowledge.Api`)
   - RESTful API endpoints
   - Controllers for handling HTTP requests
   - Request/Response models
   - Depends on Repository and Domain layers

4. **Service Defaults** (`FindJobsByKnowledge.ServiceDefaults`)
   - Common Aspire service configurations
   - Shared settings across services

5. **AppHost** (`FindJobsByKnowledge.AppHost`)
   - .NET Aspire orchestration
   - Service discovery and configuration
   - PostgreSQL database setup

### Frontend

- **React + TypeScript**
  - Modern React hooks-based components
  - Type-safe with TypeScript
  - Axios for HTTP communication
  - Component-based architecture

## Technology Stack

### Backend
- **.NET 10** - Modern .NET platform
- **ASP.NET Core Web API** - RESTful API framework
- **Entity Framework Core** - ORM for database access
- **PostgreSQL** - Database server
- **.NET Aspire** - Cloud-native orchestration
- **Npgsql** - PostgreSQL data provider

### Frontend
- **React 18** - UI library
- **TypeScript** - Type-safe JavaScript
- **Axios** - HTTP client
- **Create React App** - Build tooling

### Infrastructure
- **Docker** - Containerization
- **PostgreSQL** - Database (via Aspire)
- **PgAdmin** - Database administration (via Aspire)

## Project Structure

```
find-jobs-by-knowledge/
├── src/
│   ├── FindJobsByKnowledge.Domain/           # Domain entities
│   │   └── Entities/
│   │       └── Job.cs                         # Job entity
│   ├── FindJobsByKnowledge.Repository/        # Data access
│   │   ├── Data/
│   │   │   └── ApplicationDbContext.cs        # EF Core DbContext
│   │   ├── Repositories/
│   │   │   ├── IJobRepository.cs              # Repository interface
│   │   │   └── JobRepository.cs               # Repository implementation
│   │   └── Migrations/                        # EF Core migrations
│   ├── FindJobsByKnowledge.Api/               # Web API
│   │   ├── Controllers/
│   │   │   └── JobsController.cs              # Jobs API endpoints
│   │   ├── Models/
│   │   │   └── JobModels.cs                   # Request/Response models
│   │   └── Program.cs                         # API configuration
│   ├── FindJobsByKnowledge.ServiceDefaults/   # Aspire defaults
│   │   └── Extensions.cs                      # Service extensions
│   └── FindJobsByKnowledge.AppHost/           # Aspire host
│       └── AppHost.cs                         # Orchestration setup
├── frontend/                                   # React frontend
│   ├── src/
│   │   ├── components/
│   │   │   └── JobCard.tsx                    # Job display component
│   │   ├── services/
│   │   │   └── jobService.ts                  # API client
│   │   └── App.tsx                            # Main app component
│   └── package.json
├── docs/
│   └── Structure.md                           # This file
├── Dockerfile.api                              # API container
├── Dockerfile.frontend                         # Frontend container
└── FindJobsByKnowledge.sln                    # Solution file
```

## Database Schema

### Jobs Table
- `Id` (UUID) - Primary key
- `Title` (string) - Job title
- `Company` (string) - Company name
- `Description` (string) - Job description
- `Location` (string) - Job location
- `Salary` (decimal, nullable) - Salary amount
- `PostedDate` (DateTime) - When job was posted
- `RequiredKnowledge` (string array) - Required skills (stored as CSV)
- `IsActive` (bool) - Soft delete flag
- `CreatedAt` (DateTime) - Record creation time
- `UpdatedAt` (DateTime, nullable) - Last update time

## API Endpoints

### Jobs Controller (`/api/jobs`)

- `GET /api/jobs` - Get all active jobs
- `GET /api/jobs/{id}` - Get job by ID
- `GET /api/jobs/search/{knowledge}` - Search jobs by required knowledge
- `POST /api/jobs` - Create new job
- `PUT /api/jobs/{id}` - Update existing job
- `DELETE /api/jobs/{id}` - Soft delete job (sets IsActive to false)

## Aspire Configuration

The AppHost configures:
- PostgreSQL database server with PgAdmin
- API project with database connection
- Service discovery and health checks
- Environment-specific configurations

## Running the Application

### Using Aspire (Recommended)
```bash
cd src/FindJobsByKnowledge.AppHost
dotnet run
```
This starts the entire solution including PostgreSQL, API, and provides a dashboard.

### API Only
```bash
cd src/FindJobsByKnowledge.Api
dotnet run
```

### Frontend Only
```bash
cd frontend
npm start
```

### Using Docker

Build and run API:
```bash
docker build -f Dockerfile.api -t findjobs-api .
docker run -p 8080:8080 findjobs-api
```

Build and run Frontend:
```bash
docker build -f Dockerfile.frontend -t findjobs-frontend .
docker run -p 80:80 findjobs-frontend
```

## Database Migrations

Create new migration:
```bash
cd src/FindJobsByKnowledge.Repository
dotnet ef migrations add MigrationName --startup-project ../FindJobsByKnowledge.Api
```

Update database:
```bash
cd src/FindJobsByKnowledge.Repository
dotnet ef database update --startup-project ../FindJobsByKnowledge.Api
```

## Environment Variables

### API
- `ConnectionStrings:jobsdb` - PostgreSQL connection string (automatically configured by Aspire)

### Frontend
- `REACT_APP_API_URL` - API base URL (default: http://localhost:5000)

## Design Patterns

1. **Repository Pattern** - Abstraction over data access
2. **Dependency Injection** - Services registered in DI container
3. **Clean Architecture** - Separation of concerns
4. **Service Layer** - Business logic abstraction (via repositories)

## CORS Configuration

The API is configured to allow cross-origin requests from any origin for development. In production, this should be restricted to specific origins.

## Future Enhancements

- Authentication and Authorization
- Advanced search with filters
- Job application tracking
- User profiles and resume management
- Email notifications
- Admin dashboard
- Unit and integration tests
- CI/CD pipeline
