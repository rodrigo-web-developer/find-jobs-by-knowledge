using FindJobsByKnowledge.Domain.DTOs;

namespace FindJobsByKnowledge.Domain.Services;

/// <summary>
/// Service interface for job operations
/// </summary>
public interface IJobService
{
    Task<IEnumerable<JobDto>> FindJobsByTags(TagLevel[] tags);
    Task<JobDto?> GetJobById(string id);
}
