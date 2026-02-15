namespace FindJobsByKnowledge.Domain.DTOs;

/// <summary>
/// A question item within the questionary (no correct answer exposed to the client)
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
