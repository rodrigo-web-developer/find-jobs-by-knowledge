using FindJobsByKnowledge.Domain.DTOs;

namespace FindJobsByKnowledge.Domain.Services;

/// <summary>
/// Service interface for question CRUD operations
/// </summary>
public interface IQuestionService
{
    Task<IEnumerable<QuestionDto>> GetAllAsync();
    Task<QuestionDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<QuestionDto>> GetByTagAsync(string tag);
    Task<IEnumerable<QuestionDto>> GetByTagAndLevelAsync(string tag, int level);
    Task<QuestionDto> CreateAsync(QuestionDto question);
    Task<QuestionDto?> UpdateAsync(Guid id, QuestionDto question);
    Task<bool> DeleteAsync(Guid id);
}
