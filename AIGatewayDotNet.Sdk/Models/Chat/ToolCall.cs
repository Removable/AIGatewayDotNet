namespace AIGatewayDotNet.Sdk.Models.Chat;

public class ToolCall
{
    [JsonPropertyName("id")] public string? Id { get; set; }

    [JsonPropertyName("type")] public string Type { get; set; } = null!;

    [JsonPropertyName("function")] public ToolCallFunction? Function { get; set; }

    [JsonPropertyName("index")] public int Index { get; set; }
}

public class ToolCallFunction
{
    [JsonPropertyName("description")] public string? Description { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; } = null!;

    [JsonPropertyName("arguments")] public string? Arguments { get; set; }

    [JsonPropertyName("parameters")] public object? Parameters { get; set; }
}