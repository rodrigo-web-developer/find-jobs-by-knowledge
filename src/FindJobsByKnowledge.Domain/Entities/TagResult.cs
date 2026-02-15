namespace FindJobsByKnowledge.Domain.Entities;

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
