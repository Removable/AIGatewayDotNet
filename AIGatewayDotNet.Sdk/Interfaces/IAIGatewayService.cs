using AIGatewayDotNet.Sdk.Models.Chat;

namespace AIGatewayDotNet.Sdk.Interfaces
{
    public interface IAIGatewayService
    {
        Task<ChatCompletionResponse> ChatCompletionCreate(ChatCompletionCreateRequest chatCompletionCreateRequest,
            CancellationToken cancellationToken = default);

        IAsyncEnumerable<ChatCompletionResponse> ChatCompletionCreateStream(
            ChatCompletionCreateRequest chatCompletionCreateRequest, CancellationToken cancellationToken = default);
    }
}