namespace FindJobsByKnowledge.Domain.DTOs;

/// <summary>
/// Assessment result for a specific tag
/// </summary>
public class TagResultDto
{
    public string Tag { get; set; } = string.Empty;
    public int DeterminedLevel { get; set; }
    public string DeterminedLevelName { get; set; } = string.Empty;
    public double CorrectPercentage { get; set; }
    public Dictionary<int, double> PercentagePerLevel { get; set; } = new();
}
