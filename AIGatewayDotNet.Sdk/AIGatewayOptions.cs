namespace AIGatewayDotNet.Sdk;

public record AIGatewayOptions
{
    public static readonly string SettingKey = nameof(AIGatewayOptions);

    public string CloudFlareAccountTag { get; set; } = "";
    public string CloudFlareGateway { get; set; } = "";
    public string CloudFlareGatewayVersion { get; set; } = "v1";
    public string Provider { get; set; } = StaticValues.GatewayStatics.ProviderOpenAi;
    public string ApiKey { get; set; } = "";
    public string? AzureResourceName { get; set; }
    public string? AzureApiVersion { get; set; }
    public string? OpenAiOrganization { get; set; }
}

public enum Provider
{
    Azure,
    OpenAi
}