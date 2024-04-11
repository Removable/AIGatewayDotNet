namespace AIGatewayDotNet.Sdk.Models.Chat;

public class Choice
{
    [JsonPropertyName("finish_reason")] public string? FinishReason { get; set; }

    [JsonPropertyName("index")] public int Index { get; set; }

    [JsonPropertyName("message")] public ChatMessage? Message { get; set; }

    [JsonPropertyName("logprobs")] public Logprob? Logprobs { get; set; }
    
    [JsonPropertyName("delta")] public ChatMessage? Delta { get; set; }
}