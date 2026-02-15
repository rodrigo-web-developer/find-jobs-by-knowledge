using FindJobsByKnowledge.Domain.DTOs;
using FindJobsByKnowledge.Domain.Entities;
using FindJobsByKnowledge.Domain.Services;
using FindJobsByKnowledge.Repository.Repositories;

namespace FindJobsByKnowledge.Api.Services;

/// <summary>
/// Service implementation for question CRUD operations
/// </summary>
public class QuestionService : IQuestionService
{
    private readonly IQuestionRepository _repository;
    private readonly ILogger<QuestionService> _logger;

    public QuestionService(IQuestionRepository repository, ILogger<QuestionService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<QuestionDto>> GetAllAsync()
    {
        var questions = await _repository.GetAllAsync();
        return questions.Select(MapToDto);
    }

    public async Task<QuestionDto?> GetByIdAsync(Guid id)
    {
        var question = await _repository.GetByIdAsync(id);
        return question == null ? null : MapToDto(question);
    }

    public async Task<IEnumerable<QuestionDto>> GetByTagAsync(string tag)
    {
        var questions = await _repository.GetByTagAsync(tag);
        return questions.Select(MapToDto);
    }

    public async Task<IEnumerable<QuestionDto>> GetByTagAndLevelAsync(string tag, int level)
    {
        var questions = await _repository.GetByTagAndLevelAsync(tag, level);
        return questions.Select(MapToDto);
    }

    public async Task<QuestionDto> CreateAsync(QuestionDto dto)
    {
        var entity = new Question
        {
            Tag = dto.Tag,
            Level = Math.Clamp(dto.Level, 1, 5),
            Text = dto.Text,
            Options = dto.Options,
            CorrectOptionIndex = dto.CorrectOptionIndex
        };

        var created = await _repository.CreateAsync(entity);
        _logger.LogInformation("Created question {Id} for tag '{Tag}' level {Level}", created.Id, created.Tag, created.Level);
        return MapToDto(created);
    }

    public async Task<QuestionDto?> UpdateAsync(Guid id, QuestionDto dto)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null || !existing.IsActive) return null;

        existing.Tag = dto.Tag;
        existing.Level = Math.Clamp(dto.Level, 1, 5);
        existing.Text = dto.Text;
        existing.Options = dto.Options;
        existing.CorrectOptionIndex = dto.CorrectOptionIndex;

        var updated = await _repository.UpdateAsync(existing);
        _logger.LogInformation("Updated question {Id}", id);
        return MapToDto(updated);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existing = await _repository.GetByIdAsync(id);
        if (existing == null || !existing.IsActive) return false;

        await _repository.DeleteAsync(id);
        _logger.LogInformation("Deleted question {Id}", id);
        return true;
    }

    private static QuestionDto MapToDto(Question q) => new()
    {
        Id = q.Id,
        Tag = q.Tag,
        Level = q.Level,
        Text = q.Text,
        Options = q.Options,
        CorrectOptionIndex = q.CorrectOptionIndex
    };
}
