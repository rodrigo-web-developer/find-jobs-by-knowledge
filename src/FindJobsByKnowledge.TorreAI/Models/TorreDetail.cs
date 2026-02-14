using System.Text.Json.Serialization;

namespace FindJobsByKnowledge.TorreAI.Models;

/// <summary>
/// Torre.ai job detail/description content
/// </summary>
public class TorreDetail
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }
}
