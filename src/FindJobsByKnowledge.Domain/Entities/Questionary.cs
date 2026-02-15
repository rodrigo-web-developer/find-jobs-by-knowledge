namespace FindJobsByKnowledge.Domain.Entities;

/// <summary>
/// A generated questionary (assessment test) based on selected tags.
/// Contains a set of questions and tracks user answers and results.
/// </summary>
public class Questionary
{
    public Guid Id { get; set; }

    /// <summary>
    /// Tags the user selected for this assessment
    /// </summary>
    public List<string> Tags { get; set; } = new();

    /// <summary>
    /// The questions included in this questionary
    /// </summary>
    public List<QuestionaryItem> Items { get; set; } = new();

    /// <summary>
    /// Whether the questionary has been completed
    /// </summary>
    public bool IsCompleted { get; set; }

    /// <summary>
    /// Results per tag after completion
    /// </summary>
    public List<TagResult> Results { get; set; } = new();

    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}

/// <summary>
/// A single question within a questionary, tracking the user's answer.
/// </summary>
public class QuestionaryItem
{
    public Guid Id { get; set; }

    public Guid QuestionaryId { get; set; }
    public Questionary Questionary { get; set; } = null!;

    public Guid QuestionId { get; set; }
    public Question Question { get; set; } = null!;

    /// <summary>
    /// The user's selected answer index (null if not yet answered)
    /// </summary>
    public int? SelectedOptionIndex { get; set; }

    /// <summary>
    /// Whether the answer was correct (null if not yet answered)
    /// </summary>
    public bool? IsCorrect { get; set; }
}

/// <summary>
/// Assessment result for a specific tag, storing the determined skill level.
/// </summary>
public class TagResult
{
    public Guid Id { get; set; }

    public Guid QuestionaryId { get; set; }
    public Questionary Questionary { get; set; } = null!;

    /// <summary>
    /// The tag evaluated
    /// </summary>
    public string Tag { get; set; } = string.Empty;

    /// <summary>
    /// Determined skill level (1-5) based on correct answers
    /// </summary>
    public int DeterminedLevel { get; set; }

    /// <summary>
    /// Overall percentage of correct answers for this tag
    /// </summary>
    public double CorrectPercentage { get; set; }

    /// <summary>
    /// Percentage correct per level (JSON: { "1": 80.0, "2": 60.0, ... })
    /// </summary>
    public Dictionary<int, double> PercentagePerLevel { get; set; } = new();
}
