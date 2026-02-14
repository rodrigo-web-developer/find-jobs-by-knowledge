# Find Jobs by Tags - Project Structure

## Overview
This is a modern web application for finding jobs from external APIs based on technology tags. The solution uses .NET Aspire for orchestration, ASP.NET Core 10 for the backend API, and React with TypeScript for the frontend.

## Architecture

### Service-Oriented Architecture

The application follows a lightweight service-oriented architecture optimized for aggregating data from external job APIs:

1. **API Layer** (`FindJobsByKnowledge.Api`)
   - RESTful API endpoints
   - Controllers for handling HTTP requests
   - DTOs for response models
   - No database dependencies

2. **Service Layer** (`FindJobsByKnowledge.Api/Services`)
   - JobService for querying external APIs
   - Aggregates data from multiple sources
   - Mock implementation included for demonstration

3. **Service Defaults** (`FindJobsByKnowledge.ServiceDefaults`)
   - Common Aspire service configurations
   - Shared settings across services

4. **AppHost** (`FindJobsByKnowledge.AppHost`)
   - .NET Aspire orchestration
   - Service discovery and configuration

### Frontend

- **React + TypeScript**
  - Modern React hooks-based components
  - Type-safe with TypeScript
  - Axios for HTTP communication
  - Tag-based search interface

## Technology Stack

### Backend
- **.NET 10** - Modern .NET platform
- **ASP.NET Core Web API** - RESTful API framework
- **.NET Aspire** - Cloud-native orchestration
- **HttpClient** - For external API integration

### Frontend
- **React 18** - UI library
- **TypeScript** - Type-safe JavaScript
- **Axios** - HTTP client
- **Create React App** - Build tooling

## Project Structure

```
find-jobs-by-knowledge/
├── src/
│   ├── FindJobsByKnowledge.Api/               # Web API
│   │   ├── Controllers/
│   │   │   └── JobsController.cs              # Jobs API endpoints
│   │   ├── DTOs/
│   │   │   └── JobDto.cs                      # Data transfer objects
│   │   ├── Services/
│   │   │   ├── IJobService.cs                 # Service interface
│   │   │   └── JobService.cs                  # External API integration
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
│   ├── Structure.md                           # This file
│   └── GettingStarted.md                      # Setup guide
├── Dockerfile.api                              # API container (deprecated)
├── Dockerfile.frontend                         # Frontend container (deprecated)
└── FindJobsByKnowledge.sln                    # Solution file
```

## Data Model

### JobDto
- `Id` (string) - Unique identifier from external API
- `Title` (string) - Job title
- `Company` (string) - Company name
- `Description` (string) - Job description
- `Location` (string) - Job location
- `Salary` (decimal, nullable) - Salary amount
- `PostedDate` (DateTime) - When job was posted
- `Tags` (string array) - Technology tags (e.g., "React", "C#", "Docker")
- `Source` (string) - API source identifier

## API Endpoints

### Jobs Controller (`/api/jobs`)

- `GET /api/jobs` - Get all jobs from external APIs
- `GET /api/jobs/{id}` - Get job by ID from cache or external API
- `GET /api/jobs/search/{tag}` - Search jobs by single tag
- `POST /api/jobs/search` - Search jobs by multiple tags (array in body)

### Examples

```bash
# Get all jobs
curl http://localhost:5034/api/jobs

# Search by tag
curl http://localhost:5034/api/jobs/search/React

# Search by multiple tags
curl -X POST http://localhost:5034/api/jobs/search \
  -H "Content-Type: application/json" \
  -d '["React", "TypeScript", "C#"]'
```

## Aspire Configuration

The AppHost configures:
- API project with service discovery
- Health checks and monitoring
- Environment-specific configurations
- No database required (jobs from external APIs)

## Running the Application

### Using Aspire (Recommended)
```bash
cd src/FindJobsByKnowledge.AppHost
dotnet run
```
This starts the API and provides a dashboard for monitoring.

### API Only
```bash
cd src/FindJobsByKnowledge.Api
dotnet run
```

### Frontend Only
```bash
cd frontend
npm install
npm start
```

## External API Integration

### Current Implementation
The application currently uses mock data in `JobService.cs`. This provides a working demonstration without requiring external API keys.

### Integrating Real APIs

To integrate with real job APIs, modify `src/FindJobsByKnowledge.Api/Services/JobService.cs`:

#### Suggested APIs
1. **Adzuna API** (https://developer.adzuna.com/)
   - Free tier available
   - Good documentation
   - Multiple countries supported

2. **RemoteOK API** (https://remoteok.com/api)
   - Free, no API key required
   - Remote jobs focused
   - JSON format

3. **The Muse API** (https://www.themuse.com/developers/api/v2)
   - Free tier available
   - Tech-focused jobs
   - Good filtering options

4. **Arbeitnow API** (https://www.arbeitnow.com/api)
   - Free, no authentication
   - Tech jobs in Europe

#### Implementation Steps
1. Add API keys to configuration (appsettings.json)
2. Implement HTTP client calls in JobService
3. Map external API responses to JobDto
4. Add error handling and retry logic
5. Implement caching for better performance
6. Add rate limiting to respect API limits

#### Example Integration
```csharp
public async Task<IEnumerable<JobDto>> FindJobsByTags(string[] tags)
{
    var jobs = new List<JobDto>();
    
    // Call Adzuna API
    var adzunaJobs = await FetchFromAdzuna(tags);
    jobs.AddRange(adzunaJobs);
    
    // Call RemoteOK API
    var remoteJobs = await FetchFromRemoteOK(tags);
    jobs.AddRange(remoteJobs);
    
    return jobs.DistinctBy(j => j.Id);
}
```

## Environment Variables

### API
- `ExternalApis__Adzuna__ApiKey` - Adzuna API key
- `ExternalApis__Adzuna__AppId` - Adzuna App ID
- `ExternalApis__RemoteOK__BaseUrl` - RemoteOK base URL (default: https://remoteok.com/api)

### Frontend
- `REACT_APP_API_URL` - API base URL (default: http://localhost:5034)

## Design Patterns

1. **Service Pattern** - Encapsulates external API calls
2. **DTO Pattern** - Clean separation between external and internal models
3. **Dependency Injection** - Services registered in DI container
4. **Async/Await** - Non-blocking I/O operations

## CORS Configuration

The API is configured to allow cross-origin requests from any origin for development. In production, this should be restricted to specific origins.

## Performance Considerations

1. **Caching** - Consider implementing response caching for frequently accessed data
2. **Rate Limiting** - Respect external API rate limits
3. **Parallel Requests** - Query multiple APIs concurrently
4. **Error Handling** - Gracefully handle external API failures

## Future Enhancements

- Authentication and Authorization
- User profiles and saved searches
- Job application tracking
- Email notifications for new matching jobs
- Advanced filtering (salary range, location, remote options)
- Pagination for large result sets
- Real-time updates with SignalR
- API response caching with Redis
- Unit and integration tests
- CI/CD pipeline

## Testing

### Manual Testing
```bash
# Start the API
cd src/FindJobsByKnowledge.Api
dotnet run

# Test endpoints
curl http://localhost:5034/api/jobs
curl http://localhost:5034/api/jobs/search/React
```

### Frontend Testing
```bash
cd frontend
npm test
```

## Troubleshooting

### API Issues
- Check that the API is running on port 5034
- Verify CORS settings if getting cross-origin errors
- Check logs for external API errors

### Frontend Issues
- Ensure API URL is correctly configured
- Check browser console for errors
- Verify npm dependencies are installed

## Contributing

When adding new external APIs:
1. Add configuration in appsettings.json
2. Create a method in JobService to fetch from the API
3. Map the response to JobDto
4. Update documentation
5. Add appropriate error handling
