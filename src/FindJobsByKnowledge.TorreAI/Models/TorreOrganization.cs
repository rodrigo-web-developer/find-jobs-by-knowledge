using System.Text.Json.Serialization;

namespace FindJobsByKnowledge.TorreAI.Models;

/// <summary>
/// Torre.ai organization information
/// </summary>
public class TorreOrganization
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("hashedId")]
    public string? HashedId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("publicId")]
    public string? PublicId { get; set; }

    [JsonPropertyName("picture")]
    public string? Picture { get; set; }

    [JsonPropertyName("theme")]
    public string? Theme { get; set; }
}
