using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using FindJobsByKnowledge.Domain.DTOs;
using FindJobsByKnowledge.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FindJobsByKnowledge.TorreAI;

/// <summary>
/// Job datasource for Torre.ai API (https://torre.ai)
/// Maps generic proficiency levels (1-5) to Torre.ai-specific proficiency values.
/// </summary>
public class TorreAIJobDatasource : IJobDatasource
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<TorreAIJobDatasource> _logger;
    private readonly IConfiguration _configuration;
    private const string SearchUrl = "https://search.torre.co/opportunities/_search";

    public string DatasourceName => "Torre.ai";

    public bool IsEnabled =>
        _configuration.GetValue<bool>("ExternalApis:TorreAI:Enabled", false);

    public TorreAIJobDatasource(
        IHttpClientFactory httpClientFactory,
        ILogger<TorreAIJobDatasource> logger,
        IConfiguration configuration)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _configuration = configuration;
    }

    /// <summary>
    /// Torre.ai level mapping (1-5 generic → Torre proficiency string):
    ///   1 (Beginner)        → "novice"
    ///   2 (Intermediate)    → "proficient"  (Torre's "proficient" ≈ our intermediate)
    ///   3 (Self-sufficient) → "proficient"
    ///   4 (Expert)          → "expert"
    ///   5 (Proficient)      → "master"
    /// </summary>
    private static string MapLevelToTorreProficiency(int level) => level switch
    {
        1 => "novice",
        2 => "proficient",
        3 => "proficient",
        4 => "expert",
        5 => "master",
        _ => "proficient"
    };

    public async Task<IEnumerable<JobDto>> FindJobsByTagsAsync(TagLevel[] tags)
    {
        if (!IsEnabled)
        {
            _logger.LogInformation("{Datasource} is disabled", DatasourceName);
            return Enumerable.Empty<JobDto>();
        }

        try
        {
            _logger.LogInformation("Fetching jobs from {Datasource} for {Count} tags",
                DatasourceName, tags.Length);

            var client = _httpClientFactory.CreateClient();

            var size = _configuration.GetValue<int>("ExternalApis:TorreAI:PageSize", 20);

            var url = $"{SearchUrl}?currency=USD&periodicity=hourly&lang=en&size={size}&contextFeature=job_feed";

            // Build request body
            var andClauses = new List<object>();

            // Add open-status filter
            andClauses.Add(new { status = new { code = "open" } });

            // Add each tag as a skill/role with its mapped proficiency
            foreach (var tag in tags)
            {
                var proficiency = MapLevelToTorreProficiency(tag.Level);
                andClauses.Add(new
                {
                    // Use "skill/role" key via a dictionary to keep the slash
                    skill_role = new { text = tag.Tag, proficiency }
                });
            }

            // Torre expects { "and": [ ... ] } with "skill/role" keys
            // We need to build the JSON manually because of the slash in the key
            var requestBody = BuildRequestBody(tags);

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(requestBody, System.Text.Encoding.UTF8, "application/json")
            };

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var searchResult = JsonSerializer.Deserialize<TorreSearchResult>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (searchResult?.Results == null || searchResult.Results.Count == 0)
                return Enumerable.Empty<JobDto>();

            var jobs = searchResult.Results
                .Select(MapToJobDto)
                .Where(j => j != null)
                .Cast<JobDto>()
                .ToList();

            _logger.LogInformation("Found {Count} jobs from {Datasource}", jobs.Count, DatasourceName);
            return jobs;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching jobs from {Datasource}", DatasourceName);
            return Enumerable.Empty<JobDto>();
        }
    }

    public async Task<JobDto?> GetJobByIdAsync(string id)
    {
        if (!IsEnabled) return null;

        try
        {
            _logger.LogInformation("Fetching job {JobId} from {Datasource}", id, DatasourceName);

            var opportunityId = id.StartsWith("torre-") ? id[6..] : id;

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://torre.co/api/opportunities/{opportunityId}");

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            var opp = JsonSerializer.Deserialize<TorreOpportunity>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (opp == null) return null;

            return new JobDto
            {
                Id = $"torre-{opp.Id}",
                Title = opp.Objective ?? "Untitled",
                Company = opp.Organizations?.FirstOrDefault()?.Name ?? "Unknown",
                Description = opp.Details?.FirstOrDefault()?.Content ?? "",
                Location = opp.Locations?.FirstOrDefault() ?? "Remote",
                Salary = null,
                PostedDate = opp.Created ?? DateTime.UtcNow,
                Tags = opp.Strengths?.Select(s => s.Name ?? "").Where(n => n != "").ToList() ?? new(),
                Source = DatasourceName
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching job {JobId} from {Datasource}", id, DatasourceName);
            return null;
        }
    }

    private string BuildRequestBody(TagLevel[] tags)
    {
        // Build the JSON manually to use "skill/role" key (with slash)
        var andItems = new List<string>();

        // Status filter
        andItems.Add("""{"status":{"code":"open"}}""");

        foreach (var tag in tags)
        {
            var proficiency = MapLevelToTorreProficiency(tag.Level);
            var escapedTag = JsonSerializer.Serialize(tag.Tag);   // handles escaping
            var escapedProf = JsonSerializer.Serialize(proficiency);
            andItems.Add($$$"""{"skill/role":{"text":{{{escapedTag}}},"proficiency":{{{escapedProf}}}}}""");
        }

        return $$$"""{"and":[{{{string.Join(",", andItems)}}}]}""";
    }

    private JobDto? MapToJobDto(TorreResult result)
    {
        try
        {
            return new JobDto
            {
                Id = $"torre-{result.Id}",
                Title = result.Objective ?? "Untitled",
                Company = result.Organizations?.FirstOrDefault()?.Name ?? "Unknown",
                Description = result.Details?.FirstOrDefault()?.Content ?? "",
                Location = result.Remote == true ? "Remote" : (result.Locations?.FirstOrDefault() ?? "Unknown"),
                Salary = result.CompensationMin,
                PostedDate = result.Created ?? DateTime.UtcNow,
                Tags = result.Skills?.Select(s => s.Name ?? "").Where(n => n != "").ToList() ?? new(),
                Source = DatasourceName
            };
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Error mapping Torre.ai result to JobDto");
            return null;
        }
    }
}

#region Torre API Response Models

internal class TorreSearchResult
{
    public List<TorreResult>? Results { get; set; }
    public int? Total { get; set; }
}

internal class TorreResult
{
    public string? Id { get; set; }
    public string? Objective { get; set; }
    public List<TorreOrganization>? Organizations { get; set; }
    public List<TorreDetail>? Details { get; set; }
    public List<string>? Locations { get; set; }
    public bool? Remote { get; set; }
    public decimal? CompensationMin { get; set; }
    public decimal? CompensationMax { get; set; }
    public DateTime? Created { get; set; }
    public List<TorreSkill>? Skills { get; set; }
}

internal class TorreOpportunity
{
    public string? Id { get; set; }
    public string? Objective { get; set; }
    public List<TorreOrganization>? Organizations { get; set; }
    public List<TorreDetail>? Details { get; set; }
    public List<string>? Locations { get; set; }
    public DateTime? Created { get; set; }
    public List<TorreSkill>? Strengths { get; set; }
}

internal class TorreOrganization
{
    public string? Name { get; set; }
}

internal class TorreDetail
{
    public string? Content { get; set; }
}

internal class TorreSkill
{
    public string? Name { get; set; }
}

#endregion
