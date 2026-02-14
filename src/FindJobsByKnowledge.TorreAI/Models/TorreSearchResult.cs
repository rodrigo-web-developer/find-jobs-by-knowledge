using System.Text.Json.Serialization;

namespace FindJobsByKnowledge.TorreAI.Models;

/// <summary>
/// Torre.ai search results wrapper
/// </summary>
public class TorreSearchResult
{
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonPropertyName("size")]
    public int? Size { get; set; }

    [JsonPropertyName("results")]
    public List<TorreResult>? Results { get; set; }
}
