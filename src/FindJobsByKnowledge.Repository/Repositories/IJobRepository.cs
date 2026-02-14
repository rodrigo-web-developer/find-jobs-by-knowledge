using FindJobsByKnowledge.Domain.Entities;

namespace FindJobsByKnowledge.Repository.Repositories;

public interface IJobRepository
{
    Task<IEnumerable<Job>> GetAllAsync();
    Task<Job?> GetByIdAsync(Guid id);
    Task<IEnumerable<Job>> GetByKnowledgeAsync(string knowledge);
    Task<Job> CreateAsync(Job job);
    Task<Job> UpdateAsync(Job job);
    Task DeleteAsync(Guid id);
}
