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

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Provider))
        {
            throw new ArgumentNullException(nameof(Provider));
        }

        if (string.IsNullOrWhiteSpace(ApiKey))
        {
            throw new ArgumentNullException(nameof(ApiKey));
        }

        if (string.IsNullOrWhiteSpace(CloudFlareAccountTag))
        {
            throw new ArgumentNullException(nameof(CloudFlareAccountTag));
        }

        if (string.IsNullOrWhiteSpace(CloudFlareGateway))
        {
            throw new ArgumentNullException(nameof(CloudFlareGateway));
        }

        if (string.IsNullOrWhiteSpace(CloudFlareGatewayVersion))
        {
            throw new ArgumentNullException(nameof(CloudFlareGatewayVersion));
        }

        if (Provider.Equals(StaticValues.Providers.Azure, StringComparison.OrdinalIgnoreCase))
        {
            if (string.IsNullOrWhiteSpace(AzureResourceName))
            {
                throw new ArgumentNullException(nameof(AzureResourceName));
            }

            if (string.IsNullOrWhiteSpace(AzureApiVersion))
            {
                throw new ArgumentNullException(nameof(AzureApiVersion));
            }
        }
        else if (Provider.Equals(StaticValues.Providers.OpenAi, StringComparison.OrdinalIgnoreCase))
        {
        }
        else
        {
            throw new ArgumentException($"Provider {Provider} is not supported");
        }
    }
}

public enum Provider
{
    Azure,
    OpenAi
}