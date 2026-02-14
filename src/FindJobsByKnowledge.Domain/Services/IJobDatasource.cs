using FindJobsByKnowledge.Domain.DTOs;

namespace FindJobsByKnowledge.Domain.Services;

/// <summary>
/// Interface for external job data sources.
/// Implement this interface for each external API or data source.
/// Multiple implementations will be injected via DI for aggregation.
/// </summary>
public interface IJobDatasource
{
    /// <summary>
    /// Gets the unique name/identifier of this datasource (e.g., "Mock API", "RemoteOK")
    /// </summary>
    string DatasourceName { get; }
    
    /// <summary>
    /// Indicates whether this datasource is currently enabled
    /// </summary>
    bool IsEnabled { get; }
    
    /// <summary>
    /// Searches for jobs matching the specified tags/keywords
    /// </summary>
    /// <param name="tags">Array of tags to search for (e.g., "React", "C#", "Remote")</param>
    /// <returns>Collection of jobs matching the tags</returns>
    Task<IEnumerable<JobDto>> FindJobsByTagsAsync(string[] tags);
    
    /// <summary>
    /// Gets a specific job by its ID from this datasource
    /// </summary>
    /// <param name="id">The job identifier</param>
    /// <returns>The job if found, null otherwise</returns>
    Task<JobDto?> GetJobByIdAsync(string id);
}
