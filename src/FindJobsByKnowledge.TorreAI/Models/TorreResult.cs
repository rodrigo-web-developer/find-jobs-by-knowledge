using System.Text.Json.Serialization;

namespace FindJobsByKnowledge.TorreAI.Models;

/// <summary>
/// Torre.ai opportunity result from search
/// </summary>
public class TorreResult
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("objective")]
    public string? Objective { get; set; }

    [JsonPropertyName("slug")]
    public string? Slug { get; set; }

    [JsonPropertyName("tagline")]
    public string? Tagline { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("opportunity")]
    public string? OpportunityType { get; set; }

    [JsonPropertyName("organizations")]
    public List<TorreOrganization>? Organizations { get; set; }

    [JsonPropertyName("locations")]
    public List<string>? Locations { get; set; }

    [JsonPropertyName("remote")]
    public bool? Remote { get; set; }

    [JsonPropertyName("external")]
    public bool? External { get; set; }

    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("commitment")]
    public string? Commitment { get; set; }

    [JsonPropertyName("externalApplicationUrl")]
    public string? ExternalApplicationUrl { get; set; }

    [JsonPropertyName("compensation")]
    public TorreCompensation? Compensation { get; set; }

    [JsonPropertyName("skills")]
    public List<TorreSkill>? Skills { get; set; }

    [JsonPropertyName("details")]
    public List<TorreDetail>? Details { get; set; }
}
