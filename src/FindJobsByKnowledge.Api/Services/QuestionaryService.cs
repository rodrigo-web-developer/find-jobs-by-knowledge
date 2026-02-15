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

        return MapToDto(created, hideCorrectAnswers: true);
    }

    public async Task<QuestionaryDto?> GetByIdAsync(Guid id)
    {
        var questionary = await _questionaryRepository.GetByIdAsync(id);
        if (questionary == null) return null;

        return MapToDto(questionary, hideCorrectAnswers: !questionary.IsCompleted);
    }

    public async Task<IEnumerable<QuestionaryDto>> GetAllAsync()
    {
        var questionaries = await _questionaryRepository.GetAllAsync();
        return questionaries.Select(q => MapToDto(q, hideCorrectAnswers: !q.IsCompleted));
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
            return MapToAssessmentResult(questionary);
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
        questionary.Results = CalculateResults(questionary);
        questionary.IsCompleted = true;
        questionary.CompletedAt = DateTime.UtcNow;

        await _questionaryRepository.UpdateAsync(questionary);
        _logger.LogInformation("Questionary {Id} completed with {Count} tag results", questionaryId, questionary.Results.Count);

        return MapToAssessmentResult(questionary);
    }

    public async Task<AssessmentResultDto?> GetResultsAsync(Guid questionaryId)
    {
        var questionary = await _questionaryRepository.GetByIdAsync(questionaryId);
        if (questionary == null || !questionary.IsCompleted) return null;

        return MapToAssessmentResult(questionary);
    }

    /// <summary>
    /// Calculates the skill level for each tag based on correct answer percentages per level.
    /// The determined level is the highest level where the user scored >= 60%.
    /// </summary>
    private List<TagResult> CalculateResults(Questionary questionary)
    {
        var results = new List<TagResult>();

        foreach (var tag in questionary.Tags)
        {
            var tagItems = questionary.Items
                .Where(i => i.Question.Tag.Equals(tag, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (tagItems.Count == 0) continue;

            var percentagePerLevel = new Dictionary<int, double>();
            var determinedLevel = 1;

            for (int level = 1; level <= 5; level++)
            {
                var levelItems = tagItems.Where(i => i.Question.Level == level).ToList();
                if (levelItems.Count == 0) continue;

                var correctCount = levelItems.Count(i => i.IsCorrect == true);
                var percentage = (double)correctCount / levelItems.Count * 100;
                percentagePerLevel[level] = Math.Round(percentage, 1);

                // User passes a level if they score >= 60%
                if (percentage >= 60)
                {
                    determinedLevel = level;
                }
            }

            var totalCorrect = tagItems.Count(i => i.IsCorrect == true);
            var overallPercentage = (double)totalCorrect / tagItems.Count * 100;

            results.Add(new TagResult
            {
                Id = Guid.NewGuid(),
                QuestionaryId = questionary.Id,
                Tag = tag,
                DeterminedLevel = determinedLevel,
                CorrectPercentage = Math.Round(overallPercentage, 1),
                PercentagePerLevel = percentagePerLevel
            });
        }

        return results;
    }

    private static QuestionaryDto MapToDto(Questionary questionary, bool hideCorrectAnswers)
    {
        return new QuestionaryDto
        {
            Id = questionary.Id,
            Tags = questionary.Tags,
            IsCompleted = questionary.IsCompleted,
            CreatedAt = questionary.CreatedAt,
            CompletedAt = questionary.CompletedAt,
            Items = questionary.Items.Select(i => new QuestionaryItemDto
            {
                Id = i.Id,
                QuestionId = i.QuestionId,
                Tag = i.Question.Tag,
                Level = i.Question.Level,
                Text = i.Question.Text,
                Options = i.Question.Options,
                SelectedOptionIndex = i.SelectedOptionIndex,
                IsCorrect = hideCorrectAnswers ? null : i.IsCorrect
            }).ToList(),
            Results = questionary.IsCompleted
                ? questionary.Results.Select(r => new TagResultDto
                {
                    Tag = r.Tag,
                    DeterminedLevel = r.DeterminedLevel,
                    DeterminedLevelName = LevelName(r.DeterminedLevel),
                    CorrectPercentage = r.CorrectPercentage,
                    PercentagePerLevel = r.PercentagePerLevel
                }).ToList()
                : null
        };
    }

    private static AssessmentResultDto MapToAssessmentResult(Questionary questionary)
    {
        return new AssessmentResultDto
        {
            QuestionaryId = questionary.Id,
            Results = questionary.Results.Select(r => new TagResultDto
            {
                Tag = r.Tag,
                DeterminedLevel = r.DeterminedLevel,
                DeterminedLevelName = LevelName(r.DeterminedLevel),
                CorrectPercentage = r.CorrectPercentage,
                PercentagePerLevel = r.PercentagePerLevel
            }).ToList(),
            RecommendedSearchTags = questionary.Results.Select(r => new TagLevel
            {
                Tag = r.Tag,
                Level = r.DeterminedLevel
            }).ToList()
        };
    }

    private static string LevelName(int level) => level switch
    {
        1 => "Beginner",
        2 => "Intermediate",
        3 => "Self-sufficient",
        4 => "Expert",
        5 => "Proficient",
        _ => "Unknown"
    };
}
