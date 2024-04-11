using System.ComponentModel.DataAnnotations;

namespace AIGatewayDotNet.Sdk.Models.Chat;

public class ChatCompletionCreateRequest
{
    public enum ResponseFormats
    {
        Text,
        Json
    }

    [JsonPropertyName("messages")] public List<ChatMessage> Messages { get; set; } = [];

    [JsonPropertyName("model")] public string Model { get; set; } = null!;

    [JsonPropertyName("max_tokens")] public int MaxTokens { get; set; }

    [JsonPropertyName("temperature")] public double? Temperature { get; set; } = 1;

    [JsonPropertyName("top_p")] public double? TopP { get; set; } = 1;

    [JsonPropertyName("n")] public int? N { get; set; } = 1;

    [JsonPropertyName("frequency_penalty")]
    public double? FrequencyPenalty { get; set; } = 0;

    [JsonPropertyName("presence_penalty")] public double? PresencePenalty { get; set; } = 0;

    [JsonPropertyName("logit_bias")] public object? LogitBias { get; set; }

    [JsonPropertyName("logprobs")] public bool? Logprobs { get; set; } = false;

    [JsonPropertyName("top_logprobs")] public int? TopLogprobs { get; set; }

    [JsonPropertyName("response_format")] public ResponseFormats? ResponseFormat { get; set; }

    [JsonPropertyName("seed")] public int? Seed { get; set; }

    /// <summary>
    ///     Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop
    ///     sequence.
    /// </summary>
    [JsonIgnore]
    public string? Stop { get; set; }

    /// <summary>
    ///     Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop
    ///     sequence.
    /// </summary>
    [JsonIgnore]
    public IList<string>? StopAsList { get; set; }

    [JsonPropertyName("stop")]
    public IList<string>? StopCalculated
    {
        get
        {
            if (Stop != null && StopAsList != null)
            {
                throw new ValidationException(
                    "Stop and StopAsList can not be assigned at the same time. One of them is should be null.");
            }

            return Stop != null ? new List<string> { Stop } : StopAsList;
        }
    }

    [JsonPropertyName("stream")] public bool? Stream { get; set; } = false;

    [JsonPropertyName("tools")] public IList<ToolCall>? Tools { get; set; }

    /// <summary>
    ///     Controls which (if any) function is called by the model. none means the model will not call a function and instead
    ///     generates a message. auto means the model can pick between generating a message or calling a function. Specifying
    ///     a particular function via {"type: "function", "function": {"name": "my_function"}} forces the model to call that
    ///     function.
    ///     none is the default when no functions are present. auto is the default if functions are present.
    /// </summary>
    [JsonIgnore]
    public ToolChoice? ToolChoice { get; set; }

    [JsonPropertyName("tool_choice")]
    public object? ToolChoiceCalculated
    {
        get
        {
            if (ToolChoice != null && ToolChoice.Type != StaticValues.CompletionStatics.ToolChoiceType.Function &&
                ToolChoice.Function != null)
            {
                throw new ValidationException(
                    "You cannot choose another type besides \"function\" while ToolChoice.Function is not null.");
            }

            if (ToolChoice?.Type == StaticValues.CompletionStatics.ToolChoiceType.Function)
            {
                return ToolChoice;
            }

            return ToolChoice?.Type;
        }
    }

    [JsonPropertyName("user")] public string? User { get; set; }
}