namespace AIGatewayDotNet.Sdk.Models.Chat;

public record ChatCompletionResponse : BaseResponse
{
    [JsonPropertyName("id")] public string Id { get; set; } = null!;

    [JsonPropertyName("choices")] public IList<Choice> Choices { get; set; } = null!;

    /// <summary>
    /// Timestamp of when the choice was created (in seconds)
    /// </summary>
    [JsonPropertyName("created")]
    public int? Created { get; set; }

    [JsonPropertyName("model")] public string Model { get; set; } = null!;

    [JsonPropertyName("system_fingerprint")]
    public string SystemFingerprint { get; set; } = null!;

    [JsonPropertyName("usage")] public TokenUsage Usage { get; set; } = null!;
}