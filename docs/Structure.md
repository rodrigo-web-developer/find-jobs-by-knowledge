# Find Jobs by Tags - Project Structure

## Overview
This is a modern web application for finding jobs from external APIs based on technology tags. The solution uses .NET Aspire for orchestration, ASP.NET Core 10 for the backend API, and React with TypeScript for the frontend.

## Architecture

### Service-Oriented Architecture

The application follows a clean layered architecture with domain-driven design principles:

1. **Domain Layer** (`FindJobsByKnowledge.Domain`)
   - Core business entities and models
   - Service interfaces (`IJobService`, `IJobDatasource`)
   - DTOs for data transfer
   - No dependencies on other layers

2. **API Layer** (`FindJobsByKnowledge.Api`)
   - RESTful API endpoints
   - Controllers for handling HTTP requests
   - Service implementations
   - Datasources folder containing data source implementations:
     - `MockJobDatasource` - Mock data for demonstration (dev only)
   - References Domain and TorreAI layers

3. **TorreAI Layer** (`FindJobsByKnowledge.TorreAI`)
   - Torre.ai external API integration
   - `TorreAIJobDatasource` implements `IJobDatasource`
   - Own proficiency-level mapping (generic 1-5 → Torre-specific values)
   - References Domain layer only

4. **Service Defaults** (`FindJobsByKnowledge.ServiceDefaults`)
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
│   ├── FindJobsByKnowledge.Domain/           # Domain layer
│   │   ├── DTOs/
│   │   │   ├── JobDto.cs                    # Job data transfer object
│   │   │   └── TagLevel.cs                  # Tag + proficiency level (1-5)
│   │   ├── Entities/
│   │   │   └── Job.cs                       # Job entity
│   │   └── Services/
│   │       ├── IJobService.cs               # Service interface
│   │       └── IJobDatasource.cs            # Datasource interface
│   ├── FindJobsByKnowledge.Api/             # Web API
│   │   ├── Controllers/
│   │   │   └── JobsController.cs            # Jobs API endpoints
│   │   ├── Services/
│   │   │   ├── JobService.cs                # Service implementation
│   │   │   └── Datasources/                 # Data source implementations
│   │   │       └── MockJobDatasource.cs     # Mock data source (dev only)
│   │   └── Program.cs                       # API configuration & DI setup
│   ├── FindJobsByKnowledge.TorreAI/         # Torre.ai integration
│   │   ├── TorreAIJobDatasource.cs          # Torre API datasource
│   │   └── FindJobsByKnowledge.TorreAI.csproj
│   ├── FindJobsByKnowledge.ServiceDefaults/ # Aspire defaults
│   │   └── Extensions.cs                    # Service extensions
│   └── FindJobsByKnowledge.AppHost/         # Aspire host
│       └── AppHost.cs                       # Orchestration setup
├── frontend/                                 # React frontend
│   ├── src/
│   │   ├── components/
│   │   │   └── JobCard.tsx                  # Job display component
│   │   ├── services/
│   │   │   └── jobService.ts                # API client
│   │   └── App.tsx                          # Main app component
│   └── package.json
├── docs/
│   ├── Structure.md                         # This file
│   └── GettingStarted.md                    # Setup guide
├── Dockerfile.api                            # API container (deprecated)
├── Dockerfile.frontend                       # Frontend container (deprecated)
└── FindJobsByKnowledge.sln                  # Solution file
```

## Data Model

### Domain Layer

#### TagLevel (FindJobsByKnowledge.Domain.DTOs)
Compound type for searching by skill and proficiency:
- `Tag` (string) - Technology/skill name (e.g., "React", "C#")
- `Level` (int, 1-5) - Proficiency level:
  - 1 = Beginner
  - 2 = Intermediate
  - 3 = Self-sufficient
  - 4 = Expert
  - 5 = Proficient
- `LevelName` (string, computed) - Human-readable level description

Each datasource maps the generic 1-5 levels to its own API-specific values. For example, Torre.ai maps:
  - 1 → "novice"
  - 2 → "proficient"
  - 3 → "proficient"
  - 4 → "expert"
  - 5 → "master"

#### JobDto (FindJobsByKnowledge.Domain.DTOs)
- `Id` (string) - Unique identifier
- `Title` (string) - Job title
- `Company` (string) - Company name
- `Description` (string) - Job description
- `Location` (string) - Job location
- `Salary` (decimal, nullable) - Salary amount
- `PostedDate` (DateTime) - When job was posted
- `Tags` (string array) - Technology tags (e.g., "React", "C#", "Docker")
- `Source` (string) - Datasource identifier

#### Job Entity (FindJobsByKnowledge.Domain.Entities)
- `Id` (Guid) - Unique identifier
- `Title` (string) - Job title
- `Company` (string) - Company name
- `Description` (string) - Job description
- `Location` (string) - Job location
- `Salary` (decimal, nullable) - Salary amount
- `PostedDate` (DateTime) - When job was posted
- `RequiredKnowledge` (string array) - Required skills/knowledge
- `IsActive` (bool) - Whether job is active
- `CreatedAt` (DateTime) - Creation timestamp
- `UpdatedAt` (DateTime, nullable) - Last update timestamp

## API Endpoints

### Jobs Controller (`/api/jobs`)

- `GET /api/jobs` - Get all jobs from external APIs
- `GET /api/jobs/{id}` - Get job by ID from cache or external API
- `GET /api/jobs/search/{tag}?level=3` - Search jobs by single tag with optional level (1-5, default 3)
- `POST /api/jobs/search` - Search jobs by multiple tags with levels (array of TagLevel in body)

### Examples

```bash
# Get all jobs
curl http://localhost:5034/api/jobs

# Search by tag (defaults to level 3 = Self-sufficient)
curl http://localhost:5034/api/jobs/search/React

# Search by tag with explicit level
curl http://localhost:5034/api/jobs/search/React?level=4

# Search by multiple tags with levels
curl -X POST http://localhost:5034/api/jobs/search \
  -H "Content-Type: application/json" \
  -d '[{"tag":"React","level":4},{"tag":"C#","level":3},{"tag":"Docker","level":2}]'
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

## Data Sources

### Current Implementation

The application uses multiple data sources via the Multi-DI pattern:
- `MockJobDatasource` - Mock data for development/testing (dev environment only)
- `TorreAIJobDatasource` - Torre.ai external API integration (all environments)

### IJobDatasource Interface

Located in `FindJobsByKnowledge.Domain.Services`, this interface defines the contract for all data sources:

```csharp
public interface IJobDatasource
{
    string DatasourceName { get; }           // e.g., "Torre.ai"
    bool IsEnabled { get; }                  // Control via configuration
    Task<IEnumerable<JobDto>> FindJobsByTagsAsync(TagLevel[] tags);
    Task<JobDto?> GetJobByIdAsync(string id);
}
```

Each datasource must map the generic `TagLevel.Level` (1-5) to its own API-specific proficiency format.

### Adding External Data Sources

To integrate with external job APIs:

1. **Create Implementation Class** in `FindJobsByKnowledge.Api/Services/Datasources/`:
   ```csharp
   using FindJobsByKnowledge.Domain.DTOs;
   using FindJobsByKnowledge.Domain.Services;
   
   namespace FindJobsByKnowledge.Api.Services.Datasources;
   
   public class MyJobDatasource : IJobDatasource
   {
       public string DatasourceName => "MyAPI";
       public bool IsEnabled => true;
       
       // Implement interface methods...
   }
   ```

2. **Register in Program.cs**:
   ```csharp
   builder.Services.AddScoped<IJobDatasource, MyJobDatasource>();
   ```

3. **No Other Changes Required**: The `JobService` automatically aggregates from all registered datasources via Multi-DI pattern.

### Suggested External APIs

1. **Torre.ai API** (https://torre.ai) — **Already Integrated**
   - Free, no API key required
   - Skill/role-based search with proficiency levels
   - See `docs/External_Jobs_API.md` for details

2. **RemoteOK API** (https://remoteok.com/api)
   - Free, no API key required
   - Remote jobs focused
   - JSON format

2. **Adzuna API** (https://developer.adzuna.com/)
   - Free tier available
   - Good documentation
   - Multiple countries supported

3. **The Muse API** (https://www.themuse.com/developers/api/v2)
   - Free tier available
   - Tech-focused jobs
   - Good filtering options

## Environment Variables

### API Configuration

Configuration can be set via `appsettings.json`, `appsettings.Development.json`, or environment variables.

#### Current Configuration (appsettings.json)
```json
{
  "ExternalApis": {
    "TorreAI": {
      "Enabled": true,
      "PageSize": 20
    }
  }
}
```

#### Environment Variable Format
- `ExternalApis__TorreAI__Enabled` - Enable/disable Torre.ai datasource (true/false)
- `ExternalApis__TorreAI__PageSize` - Number of results per query (default: 20)

### Frontend
- `REACT_APP_API_URL` - API base URL (default: http://localhost:5034)

## Design Patterns

1. **Layered Architecture** - Clear separation between Domain, API, and Infrastructure layers
2. **Domain-Driven Design** - Core interfaces and models in Domain layer
3. **Multi-DI Pattern** - Multiple implementations of IJobDatasource injected as IEnumerable<IJobDatasource>
4. **Service Pattern** - Encapsulates business logic in service classes
5. **Strategy Pattern** - Each datasource is a different strategy for fetching job data
6. **DTO Pattern** - Clean separation between domain entities and data transfer objects
7. **Dependency Injection** - Services and datasources registered in DI container
8. **Async/Await** - Non-blocking I/O operations for all data access

## CORS Configuration

The API is configured to allow cross-origin requests from any origin for development. In production, this should be restricted to specific origins.

## Performance Considerations

1. **Parallel Datasource Querying** - All enabled datasources are queried concurrently using Task.WhenAll()
2. **Deduplication** - Results are deduplicated by job ID to prevent duplicate listings
3. **Caching** - Consider implementing response caching for frequently accessed data
4. **Error Isolation** - If one datasource fails, others continue to work
5. **Graceful Degradation** - Datasources can be individually disabled without affecting the service

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
1. Create a new project (e.g., `FindJobsByKnowledge.MyApi`) referencing Domain
2. Implement `IJobDatasource` with its own level mapping
3. Add project reference in Api `.csproj`
4. Register in `Program.cs`
5. Add configuration in `appsettings.json`
6. Update `Structure.md` and `External_Jobs_API.md` documentation
