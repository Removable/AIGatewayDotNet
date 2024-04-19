using System.Web;
using AIGatewayDotNet.Sdk.Interfaces;

namespace AIGatewayDotNet.Sdk.Services;

public class AzureEndpointProvider(string resourceName, string apiVersion)
    : IEndpointProvider
{
    public string ChatCompletionCreate()
    {
        return
            $"{StaticValues.GatewayStatics.ProviderAzure}/{resourceName}/{StaticValues.GatewayStatics.AzureModelPlacehoder}/chat/completions?api-version={apiVersion}";
    }
}