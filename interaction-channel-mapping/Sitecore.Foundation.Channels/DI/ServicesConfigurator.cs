using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Foundation.Channels.Configuration;

namespace Sitecore.Foundation.Channels.DI
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IConfigurationCache, ConfigurationCache>();
            serviceCollection.AddSingleton<IConfigurationFactory, ConfigurationFactory>();
        }
    }
}
