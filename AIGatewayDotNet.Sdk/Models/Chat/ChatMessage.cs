namespace AIGatewayDotNet.Sdk.Models.Chat;

public class ChatMessage
{
    public ChatMessage()
    {
    }

    public ChatMessage(string role, string content, string? name = null, IList<ToolCall>? toolCalls = null,
        string? toolCallId = null)
    {
        Role = role;
        Content = content;
        Name = name;
        ToolCalls = toolCalls;
        ToolCallId = toolCallId;
    }

    [JsonPropertyName("role")] public string Role { get; set; } = null!;

    [JsonPropertyName("content")] public string? Content { get; set; }

    [JsonPropertyName("name")] public string? Name { get; set; }

    [JsonPropertyName("tool_calls")] public IList<ToolCall>? ToolCalls { get; set; }

    [JsonPropertyName("tool_call_id")] public string? ToolCallId { get; set; }

    public static ChatMessage FromAssistant(string content, string? name = null, IList<ToolCall>? toolCalls = null)
    {
        return new(StaticValues.ChatMessageRoles.Assistant, content, name, toolCalls);
    }

    public static ChatMessage FromUser(string content, string? name = null)
    {
        return new(StaticValues.ChatMessageRoles.User, content, name);
    }

    public static ChatMessage FromSystem(string content, string? name = null)
    {
        return new(StaticValues.ChatMessageRoles.System, content, name);
    }
}