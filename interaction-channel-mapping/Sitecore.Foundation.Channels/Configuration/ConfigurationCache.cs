using System;
using System.Runtime.Caching;

namespace Sitecore.Foundation.Channels.Configuration
{
    /// <summary>
    /// The configuration cache.
    /// </summary>
    public class ConfigurationCache : IConfigurationCache
    {
        /// <summary>
        /// The cache sliding expiration.
        /// </summary>
        private readonly TimeSpan slidingExpiration = new TimeSpan(0, 10, 0);

        /// <summary>
        /// Gets or sets the cache.
        /// </summary>
        protected ObjectCache Cache
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Social.Configuration.ConfigurationCache" /> class.
        /// </summary>
        public ConfigurationCache()
        {
            Cache = MemoryCache.Default;
        }

        /// <summary>
        /// Gets ConfigurationData from the cache.
        /// </summary>
        /// <typeparam name="T">
        /// The ConfigurationData type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:Sitecore.Social.Configuration.Model.ConfigurationData" />.
        /// </returns>
        public T Get<T>() where T : ConfigurationData
        {
            return Cache.Get(typeof(T).FullName) as T;
        }

        /// <summary>
        /// Sets ConfigurationData in the cache.
        /// </summary>
        /// <param name="data">
        /// The configuration data.
        /// </param>
        public void Set(ConfigurationData data)
        {
            CacheItemPolicy policy = new CacheItemPolicy
            {
                SlidingExpiration = slidingExpiration
            };
            Cache.Set(data.GetType().FullName, data, policy);
        }

        /// <summary>
        /// Checks if there is ConfigurationData in the cache.
        /// </summary>
        /// <typeparam name="T">
        /// The ConfigurationData type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:System.Boolean" />.
        /// </returns>
        public bool Exists<T>() where T : ConfigurationData
        {
            return Cache.Contains(typeof(T).FullName);
        }
    }
}
