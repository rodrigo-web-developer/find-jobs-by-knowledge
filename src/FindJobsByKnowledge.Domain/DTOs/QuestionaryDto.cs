namespace FindJobsByKnowledge.Domain.DTOs;

/// <summary>
/// Request to generate a questionary based on selected tags
/// </summary>
public class GenerateQuestionaryRequest
{
    /// <summary>
    /// Tags to generate the assessment for
    /// </summary>
    public List<string> Tags { get; set; } = new();
}

/// <summary>
/// DTO representing a generated questionary (without correct answers for the client)
/// </summary>
public class QuestionaryDto
{
    public Guid Id { get; set; }
    public List<string> Tags { get; set; } = new();
    public List<QuestionaryItemDto> Items { get; set; } = new();
    public bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    /// <summary>
    /// Results (only populated after completion)
    /// </summary>
    public List<TagResultDto>? Results { get; set; }
}

/// <summary>
/// A question item within the questionary (no correct answer exposed)
/// </summary>
public class QuestionaryItemDto
{
    public Guid Id { get; set; }
    public Guid QuestionId { get; set; }
    public string Tag { get; set; } = string.Empty;
    public int Level { get; set; }
    public string Text { get; set; } = string.Empty;
    public List<string> Options { get; set; } = new();

    /// <summary>
    /// The user's selected answer (null if not yet answered)
    /// </summary>
    public int? SelectedOptionIndex { get; set; }

    /// <summary>
    /// Whether the answer was correct (null if not yet answered, shown after completion)
    /// </summary>
    public bool? IsCorrect { get; set; }
}

/// <summary>
/// Request to submit answers for a questionary
/// </summary>
public class SubmitAnswersRequest
{
    public List<AnswerItem> Answers { get; set; } = new();
}

/// <summary>
/// A single answer submission
/// </summary>
public class AnswerItem
{
    /// <summary>
    /// The QuestionaryItem Id
    /// </summary>
    public Guid ItemId { get; set; }

    /// <summary>
    /// The selected option index (0-based)
    /// </summary>
    public int SelectedOptionIndex { get; set; }
}

/// <summary>
/// Assessment result for a specific tag
/// </summary>
public class TagResultDto
{
    public string Tag { get; set; } = string.Empty;
    public int DeterminedLevel { get; set; }
    public string DeterminedLevelName { get; set; } = string.Empty;
    public double CorrectPercentage { get; set; }
    public Dictionary<int, double> PercentagePerLevel { get; set; } = new();
}

/// <summary>
/// Full assessment results including job recommendations
/// </summary>
public class AssessmentResultDto
{
    public Guid QuestionaryId { get; set; }
    public List<TagResultDto> Results { get; set; } = new();
    public List<TagLevel> RecommendedSearchTags { get; set; } = new();
}
