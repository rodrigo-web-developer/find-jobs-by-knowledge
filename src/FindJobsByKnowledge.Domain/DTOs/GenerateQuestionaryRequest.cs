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
