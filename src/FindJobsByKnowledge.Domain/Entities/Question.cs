namespace FindJobsByKnowledge.Domain.Entities;

/// <summary>
/// A question associated with a specific tag and proficiency level.
/// </summary>
public class Question
{
    public Guid Id { get; set; }

    /// <summary>
    /// The technology/skill tag this question belongs to (e.g., "C#", "React")
    /// </summary>
    public string Tag { get; set; } = string.Empty;

    /// <summary>
    /// Proficiency level 1-5 (1=Beginner, 2=Intermediate, 3=Self-sufficient, 4=Expert, 5=Proficient)
    /// </summary>
    public int Level { get; set; }

    /// <summary>
    /// The question text
    /// </summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Possible answers (typically 4 options)
    /// </summary>
    public List<string> Options { get; set; } = new();

    /// <summary>
    /// Zero-based index of the correct answer in the Options list
    /// </summary>
    public int CorrectOptionIndex { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
