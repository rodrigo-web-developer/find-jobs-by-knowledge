using System.Text.Json.Serialization;

namespace FindJobsByKnowledge.TorreAI.Models;

/// <summary>
/// Torre.ai opportunity detail (from direct ID lookup)
/// </summary>
public class TorreOpportunity
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("objective")]
    public string? Objective { get; set; }

    [JsonPropertyName("organizations")]
    public List<TorreOrganization>? Organizations { get; set; }

    [JsonPropertyName("locations")]
    public List<string>? Locations { get; set; }

    [JsonPropertyName("remote")]
    public bool? Remote { get; set; }

    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("compensation")]
    public TorreCompensation? Compensation { get; set; }

    [JsonPropertyName("details")]
    public List<TorreDetail>? Details { get; set; }

    [JsonPropertyName("strengths")]
    public List<TorreSkill>? Strengths { get; set; }

    [JsonPropertyName("skills")]
    public List<TorreSkill>? Skills { get; set; }
}
