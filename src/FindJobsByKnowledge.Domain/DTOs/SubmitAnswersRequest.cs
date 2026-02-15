namespace FindJobsByKnowledge.Domain.DTOs;

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
