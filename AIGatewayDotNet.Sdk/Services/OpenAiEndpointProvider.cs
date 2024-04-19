using AIGatewayDotNet.Sdk.Interfaces;

namespace AIGatewayDotNet.Sdk.Services;

public class OpenAiEndpointProvider() : IEndpointProvider
{
    public string ChatCompletionCreate()
    {
        return
            $"{StaticValues.GatewayStatics.ProviderOpenAi}/chat/completions";
    }
}