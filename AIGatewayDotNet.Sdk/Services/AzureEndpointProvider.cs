using System.Web;
using AIGatewayDotNet.Sdk.Interfaces;

namespace AIGatewayDotNet.Sdk.Services;

public class AzureEndpointProvider(string cfGateway, string resourceName, string apiVersion)
    : IEndpointProvider
{
    public string ChatCompletionCreate()
    {
        return
            $"{cfGateway}/{StaticValues.GatewayStatics.ProviderAzure}/{resourceName}/{StaticValues.GatewayStatics.AzureModelPlacehoder}/chat/completions?api-version={apiVersion}";
    }
}