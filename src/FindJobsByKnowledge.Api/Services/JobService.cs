using FindJobsByKnowledge.Api.DTOs;

namespace FindJobsByKnowledge.Api.Services;

public class JobService : IJobService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<JobService> _logger;
    private readonly IConfiguration _configuration;

    public JobService(
        IHttpClientFactory httpClientFactory,
        ILogger<JobService> logger,
        IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _configuration = configuration;
    }

    public Task<IEnumerable<JobDto>> FindJobsByTags(string[] tags)
    {
        var jobs = new List<JobDto>();

        try
        {
            // TODO: Replace with actual external API calls
            // Example: GitHub Jobs, RemoteOK, Stack Overflow Jobs, etc.
            
            // For now, returning mock data for demonstration
            jobs = GetMockJobs(tags);
            
            _logger.LogInformation("Found {Count} jobs for tags: {Tags}", jobs.Count, string.Join(", ", tags));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching jobs from external APIs");
        }

        return Task.FromResult<IEnumerable<JobDto>>(jobs);
    }

    public Task<JobDto?> GetJobById(string id)
    {
        try
        {
            // TODO: Replace with actual external API call
            // This would typically query the specific API that provided this job
            
            var allJobs = GetMockJobs(Array.Empty<string>());
            var job = allJobs.FirstOrDefault(j => j.Id == id);
            return Task.FromResult(job);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching job {JobId} from external API", id);
            return Task.FromResult<JobDto?>(null);
        }
    }

    private List<JobDto> GetMockJobs(string[] tags)
    {
        // Mock data - Replace with actual API integration
        var allJobs = new List<JobDto>
        {
            new JobDto
            {
                Id = "1",
                Title = "Senior Full Stack Developer",
                Company = "TechCorp Solutions",
                Description = "We're looking for an experienced full stack developer to join our team. You'll work on cutting-edge web applications using modern technologies.",
                Location = "San Francisco, CA (Remote Available)",
                Salary = 150000,
                PostedDate = DateTime.UtcNow.AddDays(-5),
                Tags = new List<string> { "C#", "React", "TypeScript", "PostgreSQL", "Azure" },
                Source = "Mock API"
            },
            new JobDto
            {
                Id = "2",
                Title = "Backend Developer",
                Company = "DataFlow Inc",
                Description = "Join our backend team to build scalable microservices and APIs that power our platform.",
                Location = "New York, NY",
                Salary = 130000,
                PostedDate = DateTime.UtcNow.AddDays(-3),
                Tags = new List<string> { "C#", "ASP.NET Core", "PostgreSQL", "Docker", "Kubernetes" },
                Source = "Mock API"
            },
            new JobDto
            {
                Id = "3",
                Title = "Frontend Engineer",
                Company = "WebDesign Studio",
                Description = "Create beautiful and responsive user interfaces using modern frontend frameworks.",
                Location = "Austin, TX (Remote)",
                Salary = 120000,
                PostedDate = DateTime.UtcNow.AddDays(-7),
                Tags = new List<string> { "React", "TypeScript", "JavaScript", "CSS", "HTML" },
                Source = "Mock API"
            },
            new JobDto
            {
                Id = "4",
                Title = "DevOps Engineer",
                Company = "CloudTech Systems",
                Description = "Help us build and maintain our cloud infrastructure and CI/CD pipelines.",
                Location = "Seattle, WA",
                Salary = 140000,
                PostedDate = DateTime.UtcNow.AddDays(-2),
                Tags = new List<string> { "Docker", "Kubernetes", "AWS", "Azure", "Terraform" },
                Source = "Mock API"
            },
            new JobDto
            {
                Id = "5",
                Title = ".NET Developer",
                Company = "Enterprise Solutions Ltd",
                Description = "Work on enterprise applications using .NET stack and modern development practices.",
                Location = "Chicago, IL",
                Salary = 125000,
                PostedDate = DateTime.UtcNow.AddDays(-10),
                Tags = new List<string> { "C#", "ASP.NET Core", ".NET", "SQL Server", "Azure" },
                Source = "Mock API"
            },
            new JobDto
            {
                Id = "6",
                Title = "React Developer",
                Company = "StartupHub",
                Description = "Build innovative web applications for our growing startup using React and modern JavaScript.",
                Location = "Remote",
                Salary = 110000,
                PostedDate = DateTime.UtcNow.AddDays(-1),
                Tags = new List<string> { "React", "JavaScript", "TypeScript", "Node.js", "MongoDB" },
                Source = "Mock API"
            }
        };

        // Filter by tags if provided
        if (tags != null && tags.Length > 0)
        {
            var lowerTags = tags.Select(t => t.ToLower()).ToArray();
            return allJobs
                .Where(job => job.Tags.Any(tag => lowerTags.Any(searchTag => tag.ToLower().Contains(searchTag))))
                .ToList();
        }

        return allJobs;
    }

    // TODO: Add methods to integrate with real job APIs:
    // - GitHub Jobs API (deprecated, but can use as reference)
    // - RemoteOK API
    // - Adzuna API
    // - The Muse API
    // - Stack Overflow Jobs API (if available)
    // - Custom scraping with proper rate limiting and respect for robots.txt
}
