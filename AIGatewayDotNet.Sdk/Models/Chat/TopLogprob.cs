namespace AIGatewayDotNet.Sdk.Models.Chat;

public class TopLogprob
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = null!;
    
    [JsonPropertyName("logprob")]
    public double Logprob { get; set; }
    
    [JsonPropertyName("bytes")]
    public int[]? Bytes { get; set; }
}