using AIGatewayDotNet.Sdk.Extensions;
using AIGatewayDotNet.Sdk.Interfaces;
using AIGatewayDotNet.Sdk.Models;
using AIGatewayDotNet.Sdk.Models.Chat;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddAIGatewayService(options =>
{
    options.Provider = StaticValues.Providers.Azure;
    options.CloudFlareAccountTag = "xxx";
    options.CloudFlareGateway = "xxx";
    options.CloudFlareGatewayVersion = "v1";
    options.ApiKey = "xxx";
    options.AzureApiVersion = "xxx";
    options.AzureResourceName = "xxx";
});

var serviceProvider = serviceCollection.BuildServiceProvider();
var gatewayService = serviceProvider.GetRequiredService<IAIGatewayService>();

var chatCompletionCreateRequest = new ChatCompletionCreateRequest
{
    MaxTokens = 4000,
    Model = "xxx",
    Messages =
    [
        ChatMessage.FromSystem("You are a helpful assistant."),
        ChatMessage.FromUser("What is the meaning of life?")
    ]
};

var streamResponse = gatewayService.ChatCompletionCreateStream(chatCompletionCreateRequest);
await foreach (var res in streamResponse)
{
    if (res.Error != null)
    {
        Console.WriteLine($"Error: {res.Error.Message}");
        break;
    }
    Console.WriteLine($"Response: {res.Choices.FirstOrDefault()?.Delta?.Content}");
}


// var chatCompletionResponse = await gatewayService.ChatCompletionCreate(chatCompletionCreateRequest);
//
// if (!chatCompletionResponse.Successful)
// {
//     Console.WriteLine("Failed to get chat completion");
//     return;
// }

// Console.WriteLine($"Print: {chatCompletionResponse.Choices.FirstOrDefault()?.Message?.Content}");