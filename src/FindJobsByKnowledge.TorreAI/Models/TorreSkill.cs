using System.Text.Json.Serialization;

namespace FindJobsByKnowledge.TorreAI.Models;

/// <summary>
/// Torre.ai skill information
/// </summary>
public class TorreSkill
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("experience")]
    public string? Experience { get; set; }

    [JsonPropertyName("proficiency")]
    public string? Proficiency { get; set; }
}
