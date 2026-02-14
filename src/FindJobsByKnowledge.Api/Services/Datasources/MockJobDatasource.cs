using FindJobsByKnowledge.Domain.DTOs;
using FindJobsByKnowledge.Domain.Services;

namespace FindJobsByKnowledge.Api.Services.Datasources;

/// <summary>
/// Mock job datasource for demonstration and testing purposes
/// </summary>
public class MockJobDatasource : IJobDatasource
{
    private readonly ILogger<MockJobDatasource> _logger;

    public string DatasourceName => "Mock API";
    public bool IsEnabled => true;

    public MockJobDatasource(ILogger<MockJobDatasource> logger)
    {
        _logger = logger;
    }

    public Task<IEnumerable<JobDto>> FindJobsByTagsAsync(string[] tags)
    {
        _logger.LogInformation("Fetching jobs from {Datasource} for tags: {Tags}", 
            DatasourceName, string.Join(", ", tags));

        var allJobs = GetMockJobs();
        
        // Filter by tags if provided
        if (tags.Length > 0)
        {
            var lowerTags = tags.Select(t => t.ToLowerInvariant()).ToArray();
            allJobs = allJobs.Where(j => 
                j.Tags.Any(tag => lowerTags.Contains(tag.ToLowerInvariant()))).ToList();
        }

        return Task.FromResult<IEnumerable<JobDto>>(allJobs);
    }

    public Task<JobDto?> GetJobByIdAsync(string id)
    {
        _logger.LogInformation("Fetching job {JobId} from {Datasource}", id, DatasourceName);
        
        var allJobs = GetMockJobs();
        var job = allJobs.FirstOrDefault(j => j.Id == id);
        
        return Task.FromResult(job);
    }

    private List<JobDto> GetMockJobs()
    {
        return new List<JobDto>
        {
            new JobDto
            {
                Id = "mock-1",
                Title = "Senior Full Stack Developer",
                Company = "TechCorp Solutions",
                Description = "We're looking for an experienced full stack developer to join our team. You'll work on cutting-edge web applications using modern technologies.",
                Location = "San Francisco, CA (Remote Available)",
                Salary = 150000,
                PostedDate = DateTime.UtcNow.AddDays(-5),
                Tags = new List<string> { "C#", "React", "TypeScript", "PostgreSQL", "Azure" },
                Source = DatasourceName
            },
            new JobDto
            {
                Id = "mock-2",
                Title = "Backend Developer",
                Company = "DataFlow Inc",
                Description = "Join our backend team to build scalable microservices and APIs that power our platform.",
                Location = "New York, NY",
                Salary = 130000,
                PostedDate = DateTime.UtcNow.AddDays(-3),
                Tags = new List<string> { "C#", "ASP.NET Core", "PostgreSQL", "Docker", "Kubernetes" },
                Source = DatasourceName
            },
            new JobDto
            {
                Id = "mock-3",
                Title = "Frontend Engineer",
                Company = "WebDesign Studio",
                Description = "Create beautiful and responsive user interfaces using modern frontend frameworks.",
                Location = "Austin, TX (Remote)",
                Salary = 120000,
                PostedDate = DateTime.UtcNow.AddDays(-7),
                Tags = new List<string> { "React", "TypeScript", "JavaScript", "CSS", "HTML" },
                Source = DatasourceName
            },
            new JobDto
            {
                Id = "mock-4",
                Title = "DevOps Engineer",
                Company = "CloudNative Systems",
                Description = "Help us build and maintain our cloud infrastructure using modern DevOps practices.",
                Location = "Seattle, WA (Remote)",
                Salary = 140000,
                PostedDate = DateTime.UtcNow.AddDays(-2),
                Tags = new List<string> { "Docker", "Kubernetes", "Azure", "CI/CD", "Terraform" },
                Source = DatasourceName
            },
            new JobDto
            {
                Id = "mock-5",
                Title = "React Developer",
                Company = "StartupHub",
                Description = "Join our fast-paced startup to build innovative web applications with React.",
                Location = "Remote",
                Salary = null,
                PostedDate = DateTime.UtcNow.AddDays(-1),
                Tags = new List<string> { "React", "JavaScript", "TypeScript", "Node.js", "MongoDB" },
                Source = DatasourceName
            },
            new JobDto
            {
                Id = "mock-6",
                Title = ".NET Developer",
                Company = "Enterprise Solutions Ltd",
                Description = "Work on large-scale enterprise applications using .NET technologies.",
                Location = "Chicago, IL",
                Salary = 125000,
                PostedDate = DateTime.UtcNow.AddDays(-10),
                Tags = new List<string> { "C#", "ASP.NET Core", "SQL Server", "Azure", "Microservices" },
                Source = DatasourceName
            }
        };
    }
}
