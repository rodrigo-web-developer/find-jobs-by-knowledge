using FindJobsByKnowledge.Api.DTOs;

namespace FindJobsByKnowledge.Api.Services;

public interface IJobService
{
    Task<IEnumerable<JobDto>> FindJobsByTags(string[] tags);
    Task<JobDto?> GetJobById(string id);
}
