namespace FindJobsByKnowledge.Domain.DTOs;

/// <summary>
/// DTO for creating/updating a question
/// </summary>
public class QuestionDto
{
    public Guid? Id { get; set; }
    public string Tag { get; set; } = string.Empty;
    public int Level { get; set; }
    public string Text { get; set; } = string.Empty;
    public List<string> Options { get; set; } = new();
    public int CorrectOptionIndex { get; set; }
}
