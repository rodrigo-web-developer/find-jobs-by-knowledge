namespace FindJobsByKnowledge.Domain.Entities;

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
