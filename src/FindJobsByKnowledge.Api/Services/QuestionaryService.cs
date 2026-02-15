using FindJobsByKnowledge.Api.Mappers;
using FindJobsByKnowledge.Domain.DTOs;
using FindJobsByKnowledge.Domain.Entities;
using FindJobsByKnowledge.Domain.Services;
using FindJobsByKnowledge.Repository.Repositories;

namespace FindJobsByKnowledge.Api.Services;

/// <summary>
/// Service for generating questionaries, submitting answers, and calculating results
/// </summary>
public class QuestionaryService : IQuestionaryService
{
    private readonly IQuestionaryRepository _questionaryRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly ILogger<QuestionaryService> _logger;

    public QuestionaryService(
        IQuestionaryRepository questionaryRepository,
        IQuestionRepository questionRepository,
        ILogger<QuestionaryService> logger)
    {
        _questionaryRepository = questionaryRepository;
        _questionRepository = questionRepository;
        _logger = logger;
    }

    public async Task<QuestionaryDto> GenerateAsync(GenerateQuestionaryRequest request)
    {
        _logger.LogInformation("Generating questionary for tags: {Tags}", string.Join(", ", request.Tags));

        var items = new List<QuestionaryItem>();

        foreach (var tag in request.Tags)
        {
            // Get at least 5 questions per level (1-5) for this tag
            for (int level = 1; level <= 5; level++)
            {
                var questions = (await _questionRepository.GetByTagAndLevelAsync(tag, level)).ToList();

                if (questions.Count == 0)
                {
                    _logger.LogWarning("No questions found for tag '{Tag}' level {Level}", tag, level);
                    continue;
                }

                // Take up to 5 random questions per level
                var selected = questions
                    .OrderBy(_ => Random.Shared.Next())
                    .Take(5)
                    .ToList();

                foreach (var question in selected)
                {
                    items.Add(new QuestionaryItem
                    {
                        QuestionId = question.Id,
                        Question = question
                    });
                }
            }
        }

        var questionary = new Questionary
        {
            Tags = request.Tags,
            Items = items,
            IsCompleted = false
        };

        var created = await _questionaryRepository.CreateAsync(questionary);
        _logger.LogInformation("Generated questionary {Id} with {Count} questions", created.Id, items.Count);

        return QuestionaryMapper.MapToDto(created, hideCorrectAnswers: true);
    }

    public async Task<QuestionaryDto?> GetByIdAsync(Guid id)
    {
        var questionary = await _questionaryRepository.GetByIdAsync(id);
        if (questionary == null) return null;

        return QuestionaryMapper.MapToDto(questionary, hideCorrectAnswers: !questionary.IsCompleted);
    }

    public async Task<IEnumerable<QuestionaryDto>> GetAllAsync()
    {
        var questionaries = await _questionaryRepository.GetAllAsync();
        return questionaries.Select(q => QuestionaryMapper.MapToDto(q, hideCorrectAnswers: !q.IsCompleted));
    }

    public async Task<AssessmentResultDto?> SubmitAnswersAsync(Guid questionaryId, SubmitAnswersRequest request)
    {
        var questionary = await _questionaryRepository.GetByIdAsync(questionaryId);
        if (questionary == null)
        {
            _logger.LogWarning("Questionary {Id} not found", questionaryId);
            return null;
        }

        if (questionary.IsCompleted)
        {
            _logger.LogWarning("Questionary {Id} has already been completed", questionaryId);
            return QuestionaryMapper.MapToAssessmentResult(questionary);
        }

        // Apply answers
        foreach (var answer in request.Answers)
        {
            var item = questionary.Items.FirstOrDefault(i => i.Id == answer.ItemId);
            if (item != null)
            {
                item.SelectedOptionIndex = answer.SelectedOptionIndex;
                item.IsCorrect = answer.SelectedOptionIndex == item.Question.CorrectOptionIndex;
            }
        }

        // Calculate results per tag
        questionary.Results = AssessmentCalculator.CalculateResults(questionary);
        questionary.IsCompleted = true;
        questionary.CompletedAt = DateTime.UtcNow;

        await _questionaryRepository.UpdateAsync(questionary);
        _logger.LogInformation("Questionary {Id} completed with {Count} tag results", questionaryId, questionary.Results.Count);

        return QuestionaryMapper.MapToAssessmentResult(questionary);
    }

    public async Task<AssessmentResultDto?> GetResultsAsync(Guid questionaryId)
    {
        var questionary = await _questionaryRepository.GetByIdAsync(questionaryId);
        if (questionary == null || !questionary.IsCompleted) return null;

        return QuestionaryMapper.MapToAssessmentResult(questionary);
    }
}
