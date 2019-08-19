namespace Sitecore.Foundation.Channels.Configuration
{
    /// <summary>
    /// The ConfigurationCache interface.
    /// </summary>
    public interface IConfigurationCache
    {
        /// <summary>
        /// Gets ConfigurationData from the cache.
        /// </summary>
        /// <typeparam name="T">
        /// The ConfigurationData type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:Sitecore.Social.Configuration.Model.ConfigurationData" />.
        /// </returns>
        T Get<T>() where T : ConfigurationData;

        /// <summary>
        /// Sets ConfigurationData in the cache.
        /// </summary>
        /// <param name="data">
        /// The configuration data.
        /// </param>
        void Set(ConfigurationData data);

        /// <summary>
        /// Checks if there is ConfigurationData in the cache.
        /// </summary>
        /// <typeparam name="T">
        /// The ConfigurationData type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:System.Boolean" />.
        /// </returns>
        bool Exists<T>() where T : ConfigurationData;
    }
}
