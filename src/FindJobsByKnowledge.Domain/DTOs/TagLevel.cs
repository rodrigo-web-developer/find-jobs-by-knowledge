namespace FindJobsByKnowledge.Domain.DTOs;

/// <summary>
/// Represents a technology tag with an associated proficiency level.
/// Used to search for jobs matching specific skills at specific levels.
/// </summary>
public class TagLevel
{
    /// <summary>
    /// The technology/skill tag (e.g., "React", "C#", "Docker")
    /// </summary>
    public string Tag { get; init; } = string.Empty;

    /// <summary>
    /// Proficiency level from 1 to 5:
    /// 1 = Beginner, 2 = Intermediate, 3 = Self-sufficient, 4 = Expert, 5 = Proficient
    /// </summary>
    public int Level { get; init; } = 1;

    /// <summary>
    /// Human-readable description of the level
    /// </summary>
    public string LevelName => Level switch
    {
        1 => "Beginner",
        2 => "Intermediate",
        3 => "Self-sufficient",
        4 => "Expert",
        5 => "Proficient",
        _ => "Unknown"
    };
}
