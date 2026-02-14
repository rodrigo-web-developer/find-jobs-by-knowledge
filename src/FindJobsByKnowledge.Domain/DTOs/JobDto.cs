namespace FindJobsByKnowledge.Domain.DTOs;

/// <summary>
/// Data transfer object for job information from external APIs
/// </summary>
public class JobDto
{
    public string Id { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string Company { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Location { get; init; } = string.Empty;
    public decimal? Salary { get; init; }
    public DateTime PostedDate { get; init; }
    public List<string> Tags { get; init; } = new();
    
    /// <summary>
    /// Source API identifier (e.g., "RemoteOK", "Adzuna", "The Muse", "Mock API")
    /// </summary>
    public string Source { get; init; } = string.Empty;
}
