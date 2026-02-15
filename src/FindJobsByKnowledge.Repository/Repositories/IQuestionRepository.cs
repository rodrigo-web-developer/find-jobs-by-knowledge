using FindJobsByKnowledge.Domain.Entities;

namespace FindJobsByKnowledge.Repository.Repositories;

public interface IQuestionRepository
{
    Task<IEnumerable<Question>> GetAllAsync();
    Task<Question?> GetByIdAsync(Guid id);
    Task<IEnumerable<Question>> GetByTagAsync(string tag);
    Task<IEnumerable<Question>> GetByTagAndLevelAsync(string tag, int level);
    Task<Question> CreateAsync(Question question);
    Task<Question> UpdateAsync(Question question);
    Task DeleteAsync(Guid id);
}
