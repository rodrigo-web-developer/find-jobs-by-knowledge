# Find Jobs by Knowledge

A modern full-stack web application for finding jobs based on required knowledge and skills. Built with .NET Aspire, ASP.NET Core 10, React, TypeScript, and PostgreSQL.

## Features

- 🔍 Search jobs by required knowledge/skills
- 📝 Create and manage job listings
- 🎯 Filter jobs based on specific technologies
- 🗃️ PostgreSQL database with Entity Framework Core
- 🐳 Docker support for containerized deployment
- ☁️ .NET Aspire orchestration for cloud-native development
- ⚛️ React + TypeScript frontend with Axios

## Architecture

This project follows Clean Architecture principles with separated concerns:

- **Domain Layer**: Core business entities
- **Repository Layer**: Data access with EF Core
- **API Layer**: RESTful endpoints with ASP.NET Core
- **Frontend**: React + TypeScript SPA

For detailed architecture information, see [docs/Structure.md](docs/Structure.md)

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js 18+](https://nodejs.org/)
- [Docker](https://www.docker.com/) (optional, for containerized deployment)

## Quick Start

### Using .NET Aspire (Recommended)

1. Clone the repository
2. Run the AppHost:
   ```bash
   cd src/FindJobsByKnowledge.AppHost
   dotnet run
   ```
3. Access the Aspire dashboard (URL shown in console output)
4. The API and database will be automatically started

### Running Individually

#### Backend API
```bash
cd src/FindJobsByKnowledge.Api
dotnet run
```

#### Frontend
```bash
cd frontend
npm install
npm start
```

### Using Docker

#### Build and run API
```bash
docker build -f Dockerfile.api -t findjobs-api .
docker run -p 8080:8080 findjobs-api
```

#### Build and run Frontend
```bash
docker build -f Dockerfile.frontend -t findjobs-frontend .
docker run -p 80:80 findjobs-frontend
```

## Project Structure

See [docs/Structure.md](docs/Structure.md) for detailed project structure and architecture documentation.

## Technologies

### Backend
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- .NET Aspire
- Npgsql

### Frontend
- React 18
- TypeScript
- Axios
- Create React App

## API Endpoints

- `GET /api/jobs` - Get all jobs
- `GET /api/jobs/{id}` - Get job by ID
- `GET /api/jobs/search/{knowledge}` - Search by knowledge
- `POST /api/jobs` - Create new job
- `PUT /api/jobs/{id}` - Update job
- `DELETE /api/jobs/{id}` - Delete job

## License

MIT