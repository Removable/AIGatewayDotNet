# AIGatewayDotNet

A .NET client of the CloudFlare AI Gateway.

## Installation

```
dotnet add package AIGatewayDotNet
```

or

```
Install-Package AIGatewayDotNet
```

## Usage

### Add single service

Add the configuration to your project:

```json
"AIGatewayOptions": {
  "CloudFlareAccountTag": "Your CloudFlare Account Tag goes here",
  "CloudFlareGateway": "CloudFlare Gateway name goes here",
  "CloudFlareGatewayVersion": "v1",
  "Provider": "Azure or OpenAI (case insensitive)",
  "ApiKey": "Your api key goes here",
  "AzureResourceName": "If you are using Azure, the resource name goes here",
  "AzureApiVersion": "If you are using Azure, the api version goes here",
  "OpenAiOrganization": "If you are using OpenAI, the organization id goes here (It's an optional field)."
}
```

Then, add the service to your project:

```csharp
services.AddAIGatewayService();
```

The service will bind the configuration automatically.

### Add multiple services

Add a separate configuration for each service with a different field name. For example:
```json
"AIGatewayOptions": {
  "OpenAI": {
    "CloudFlareAccountTag": "Your CloudFlare Account Tag goes here",
    // Other fields
  },
  "Azure": {
    "CloudFlareAccountTag": "Your CloudFlare Account Tag goes here",
    // Other fields
  }
}
```

Then, create a service for each configuration:
```csharp
public class OpenAIService : AIGatewayService
{
    public const string SettingKey = "OpenAI";
    [ActivatorUtilitiesConstructor]
    public AIGatewayService(HttpClient httpClient, IOptionsSnapshot<OpenAiOptions> settings) : base(settings.Get(SettingKey),httpClient){}
    public AIGatewayService(OpenAiOptions settings, HttpClient? httpClient = null) : base(settings, httpClient){}
}

public class AzureService : AIGatewayService
{
    public const string SettingKey = "Azure";
    [ActivatorUtilitiesConstructor]
    public AIGatewayService(HttpClient httpClient, IOptionsSnapshot<AzureOptions> settings) : base(settings.Get(SettingKey),httpClient){}
    public AIGatewayService(AzureOptions settings, HttpClient? httpClient = null) : base(settings, httpClient){}
}
```

Then, add the services to your project:
```csharp
services.AddAIGatewayService<OpenAIService>(OpenAIService.SettingKey);
services.AddAIGatewayService<AzureService>(AzureService.SettingKey);
```

### Use the service

Get the service from the DI container:

```csharp
// If you have a single service
var gatewayService = serviceProvider.GetRequiredService<IAIGatewayService>();
```

or

```csharp
// If you have multiple services
var openAiGateway = serviceProvider.GetRequiredService<OpenAIService>();
var azureGateway = serviceProvider.GetRequiredService<AzureService>();
```

Then, use the service to make requests:

```csharp
var chatCompletionCreateRequest = new ChatCompletionCreateRequest
{
    MaxTokens = 1000,
    Model = "gpt-3.5-turbo",
    Messages =
    [
        ChatMessage.FromSystem("You are a helpful assistant."),
        ChatMessage.FromUser("What is the meaning of life?")
    ]
};

var streamResponse = gatewayService.ChatCompletionCreateStream(chatCompletionCreateRequest);
await foreach (var res in streamResponse)
{
    Console.WriteLine($"Response: {res.Choices.FirstOrDefault()?.Delta?.Content}");
}
```

## Thanks

Part of the code is based on the [betalgo/openai](https://github.com/betalgo/openai) project.