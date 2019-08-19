namespace Sitecore.Foundation.Channels.Configuration
{
    /// <summary>
    /// The ConfigurationFactory interface.
    /// </summary>
    public interface IConfigurationFactory
    {
        /// <summary>
        /// Gets ConfigurationData.
        /// </summary>
        /// <typeparam name="T">
        /// The ConfigurationData type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T:Sitecore.Social.Configuration.Model.ConfigurationData" />.
        /// </returns>
        T Get<T>() where T : ConfigurationData;
    }
}
