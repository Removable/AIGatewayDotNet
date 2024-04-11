namespace AIGatewayDotNet.Sdk.Models.Chat;

public class Logprob
{
    [JsonPropertyName("content")]
    public LogprobContent[]? Content { get; set; }
}