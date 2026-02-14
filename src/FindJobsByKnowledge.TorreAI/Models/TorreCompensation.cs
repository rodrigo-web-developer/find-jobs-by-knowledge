using System.Text.Json.Serialization;

namespace FindJobsByKnowledge.TorreAI.Models;

/// <summary>
/// Torre.ai compensation information
/// </summary>
public class TorreCompensation
{
    [JsonPropertyName("data")]
    public TorreCompensationData? Data { get; set; }

    [JsonPropertyName("visible")]
    public bool? Visible { get; set; }
}

public class TorreCompensationData
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("currency")]
    public string? Currency { get; set; }

    [JsonPropertyName("minAmount")]
    public decimal? MinAmount { get; set; }

    [JsonPropertyName("maxAmount")]
    public decimal? MaxAmount { get; set; }

    [JsonPropertyName("periodicity")]
    public string? Periodicity { get; set; }

    [JsonPropertyName("minHourlyUSD")]
    public decimal? MinHourlyUSD { get; set; }

    [JsonPropertyName("maxHourlyUSD")]
    public decimal? MaxHourlyUSD { get; set; }

    [JsonPropertyName("negotiable")]
    public bool? Negotiable { get; set; }

    [JsonPropertyName("conversionRateUSD")]
    public decimal? ConversionRateUSD { get; set; }
}
