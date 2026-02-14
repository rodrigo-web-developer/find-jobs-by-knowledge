# Find Jobs by Tags

A modern web application for finding jobs from external APIs based on technology tags. Built with .NET Aspire, ASP.NET Core 10, and React + TypeScript.

## Features

- 🔍 Search jobs by technology tags (e.g., React, C#, Docker)
- 📡 Fetches jobs from external APIs (currently using mock data)
- 🎯 Filter jobs based on specific technologies
- ☁️ .NET Aspire orchestration for cloud-native development
- ⚛️ React + TypeScript frontend with Axios
- 📊 DTOs for clean API contracts

## Architecture

This project follows a lightweight architecture optimized for querying external APIs:

- **API Layer**: RESTful endpoints with ASP.NET Core serving DTOs
- **Service Layer**: JobService to aggregate data from external job APIs
- **Frontend**: React + TypeScript SPA with tag-based search

Jobs are retrieved from external APIs (not stored locally). The system acts as an aggregator and search interface for multiple job sources.

For detailed architecture information, see [docs/Structure.md](docs/Structure.md)

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js 18+](https://nodejs.org/) and npm

## Quick Start

### Using .NET Aspire (Recommended)

```bash
# Clone the repository
git clone https://github.com/rodrigo-web-developer/find-jobs-by-knowledge.git
cd find-jobs-by-knowledge

# Run the AppHost
cd src/FindJobsByKnowledge.AppHost
dotnet run

# The Aspire dashboard will open automatically in your browser
# Access the API through the dashboard
```

### Running Individually

#### Backend API
```bash
cd src/FindJobsByKnowledge.Api
dotnet run

# API will be available at http://localhost:5034
```

#### Frontend
```bash
cd frontend
npm install
npm start

# Frontend will open at http://localhost:3000
```

## API Endpoints

- `GET /api/jobs` - Get all jobs from external APIs
- `GET /api/jobs/{id}` - Get job by ID
- `GET /api/jobs/search/{tag}` - Search jobs by single tag
- `POST /api/jobs/search` - Search jobs by multiple tags (body: string array)

### Example API Calls

```bash
# Get all jobs
curl http://localhost:5034/api/jobs

# Search by single tag
curl http://localhost:5034/api/jobs/search/React

# Search by multiple tags
curl -X POST http://localhost:5034/api/jobs/search \
  -H "Content-Type: application/json" \
  -d '["React", "TypeScript"]'
```

## Technologies

### Backend
- .NET 10
- ASP.NET Core Web API
- .NET Aspire
- HttpClient for external API calls

### Frontend
- React 18
- TypeScript
- Axios
- Create React App

## Integrating Real Job APIs

The current implementation uses mock data. To integrate with real job APIs, update `src/FindJobsByKnowledge.Api/Services/JobService.cs`:

### Suggested Job APIs
- **Adzuna API** - Free tier available with job postings
- **RemoteOK API** - Remote job listings
- **The Muse API** - Tech job listings
- **GitHub Jobs API** - (deprecated but can be used as reference)
- Custom web scraping with proper rate limiting

See the TODO comments in `JobService.cs` for integration points.

## License

MIT
