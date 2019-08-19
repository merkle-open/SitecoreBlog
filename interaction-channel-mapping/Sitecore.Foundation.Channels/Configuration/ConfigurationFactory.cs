using System;
using System.Linq;

namespace Sitecore.Foundation.Channels.Configuration
{
    /// <summary>
    /// The configuration factory.
    /// </summary>
    public class ConfigurationFactory : IConfigurationFactory
    {
        /// <summary>
        /// Gets or sets the configuration cache.
        /// </summary>
        protected IConfigurationCache ConfigurationCache
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Social.Configuration.ConfigurationFactory" /> class.
        /// </summary>
        /// <param name="configurationCache">
        /// The configuration cache.
        /// </param>
        public ConfigurationFactory(IConfigurationCache configurationCache)
        {
            ConfigurationCache = configurationCache;
        }

        /// <summary>
        /// Gets ConfigurationData.
        /// </summary>
        /// <typeparam name="T">
        /// The ConfigurationData type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:Sitecore.Social.Configuration.Model.ConfigurationData" />.
        /// </returns>
        /// <example>
        /// <code>
        /// var networksConfiguration = ExecutingContext.Current.IoC.Get&lt;IConfigurationFactory&gt;().Get&lt;NetworksConfiguration&gt;();
        ///
        /// foreach (var networkSettings in networksConfiguration.Networks)
        /// {
        ///   Console.WriteLine("network: {0}, itemId: {1}", networkSettings.Name, networkSettings.ItemId);
        /// }
        /// </code>
        /// </example>
        public T Get<T>() where T : ConfigurationData
        {
            T val;
            if (ConfigurationCache.Exists<T>())
            {
                val = ConfigurationCache.Get<T>();
            }
            else
            {
                val = GetConfigurationFromManager<T>();
                if (val != null)
                {
                    ConfigurationCache.Set(val);
                }
            }
            return val;
        }

        /// <summary>
        /// Gets configuration from manager.
        /// </summary>
        /// <typeparam name="T">
        /// The ConfigurationData type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:Sitecore.Social.Configuration.Model.ConfigurationData" />.
        /// </returns>
        private T GetConfigurationFromManager<T>() where T : ConfigurationData
        {
            return ((IConfigurationManager)Activator.CreateInstance(((ConfigurationManagerAttribute)typeof(T).GetCustomAttributes(typeof(ConfigurationManagerAttribute), inherit: false).First()).ManagerType)).GetConfigurationData() as T;
        }
    }
}
