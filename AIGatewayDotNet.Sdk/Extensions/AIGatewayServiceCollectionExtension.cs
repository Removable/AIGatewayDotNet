using AIGatewayDotNet.Sdk.Interfaces;
using AIGatewayDotNet.Sdk.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AIGatewayDotNet.Sdk.Extensions
{
    public static class AIGatewayServiceCollectionExtension
    {
        public static IHttpClientBuilder AddAIGatewayService(this IServiceCollection services,
            Action<AIGatewayOptions>? setupAction = null)
        {
            var optionsBuilder = services.AddOptions<AIGatewayOptions>();
            if (setupAction != null)
            {
                optionsBuilder.Configure(setupAction);
            }
            else
            {
                optionsBuilder.BindConfiguration(AIGatewayOptions.SettingKey);
            }

            return services.AddHttpClient<IAIGatewayService, AIGatewayService>();
        }

        public static IHttpClientBuilder AddAIGatewayService<TServiceInterface>(this IServiceCollection services,
            string name, Action<AIGatewayOptions>? setupAction = null)
            where TServiceInterface : class, IAIGatewayService
        {
            var optionsBuilder = services.AddOptions<AIGatewayOptions>(name);
            if (setupAction != null)
            {
                optionsBuilder.Configure(setupAction);
            }
            else
            {
                optionsBuilder.BindConfiguration($"{AIGatewayOptions.SettingKey}:{name}");
            }

            return services.AddHttpClient<TServiceInterface>();
        }
    }
}