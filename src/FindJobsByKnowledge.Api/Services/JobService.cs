using FindJobsByKnowledge.Domain.DTOs;
using FindJobsByKnowledge.Domain.Services;

namespace FindJobsByKnowledge.Api.Services;

/// <summary>
/// Aggregates job data from multiple external datasources
/// </summary>
public class JobService : IJobService
{
    private readonly IEnumerable<IJobDatasource> _datasources;
    private readonly ILogger<JobService> _logger;

    public JobService(
        IEnumerable<IJobDatasource> datasources,
        ILogger<JobService> logger)
    {
        _datasources = datasources;
        _logger = logger;
    }

    public async Task<IEnumerable<JobDto>> FindJobsByTags(TagLevel[] tags)
    {
        var jobs = new List<JobDto>();

        try
        {
            _logger.LogInformation("Searching for jobs with {Count} tags across {DsCount} datasources", 
                tags.Length, _datasources.Count());

            // Query all enabled datasources in parallel
            var tasks = _datasources
                .Where(ds => ds.IsEnabled)
                .Select(ds => FetchFromDatasource(ds, tags));

            var results = await Task.WhenAll(tasks);
            
            // Flatten and deduplicate results
            jobs = results
                .SelectMany(r => r)
                .GroupBy(j => j.Id)
                .Select(g => g.First()) // Take first occurrence of each unique ID
                .OrderByDescending(j => j.PostedDate)
                .ToList();
            
            _logger.LogInformation("Found {Count} total jobs (after deduplication)", 
                jobs.Count);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error aggregating jobs from datasources");
        }

        return jobs;
    }

    public async Task<JobDto?> GetJobById(string id)
    {
        try
        {
            _logger.LogInformation("Searching for job {JobId} across datasources", id);
            
            // Try each datasource until we find the job
            foreach (var datasource in _datasources.Where(ds => ds.IsEnabled))
            {
                var job = await datasource.GetJobByIdAsync(id);
                if (job != null)
                {
                    _logger.LogInformation("Found job {JobId} in datasource {Datasource}", 
                        id, datasource.DatasourceName);
                    return job;
                }
            }
            
            _logger.LogWarning("Job {JobId} not found in any datasource", id);
            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching job {JobId} from datasources", id);
            return null;
        }
    }

    private async Task<IEnumerable<JobDto>> FetchFromDatasource(IJobDatasource datasource, TagLevel[] tags)
    {
        try
        {
            var jobs = await datasource.FindJobsByTagsAsync(tags);
            _logger.LogInformation("Retrieved {Count} jobs from {Datasource}", 
                jobs.Count(), datasource.DatasourceName);
            return jobs;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching from datasource {Datasource}", datasource.DatasourceName);
            return Enumerable.Empty<JobDto>();
        }
    }
}
