using FindJobsByKnowledge.Domain.DTOs;

namespace FindJobsByKnowledge.Domain.Services;

/// <summary>
/// Service interface for questionary generation and assessment
/// </summary>
public interface IQuestionaryService
{
    /// <summary>
    /// Generates a questionary with at least 5 questions per level for each tag
    /// </summary>
    Task<QuestionaryDto> GenerateAsync(GenerateQuestionaryRequest request);

    /// <summary>
    /// Gets a questionary by its ID
    /// </summary>
    Task<QuestionaryDto?> GetByIdAsync(Guid id);

    /// <summary>
    /// Gets all questionaries
    /// </summary>
    Task<IEnumerable<QuestionaryDto>> GetAllAsync();

    /// <summary>
    /// Submits answers for a questionary, calculates results, and returns the assessment
    /// </summary>
    Task<AssessmentResultDto?> SubmitAnswersAsync(Guid questionaryId, SubmitAnswersRequest request);

    /// <summary>
    /// Gets the assessment results for a completed questionary
    /// </summary>
    Task<AssessmentResultDto?> GetResultsAsync(Guid questionaryId);
}
