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
