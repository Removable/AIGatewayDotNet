namespace AIGatewayDotNet.Sdk.Models.Chat;

public class LogprobContent : TopLogprob
{
    [JsonPropertyName("top_logprobs")] public TopLogprob[] TopLogprobs { get; set; } = [];
}