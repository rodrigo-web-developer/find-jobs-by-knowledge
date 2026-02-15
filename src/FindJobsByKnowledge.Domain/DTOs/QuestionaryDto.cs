namespace FindJobsByKnowledge.Domain.DTOs;

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
