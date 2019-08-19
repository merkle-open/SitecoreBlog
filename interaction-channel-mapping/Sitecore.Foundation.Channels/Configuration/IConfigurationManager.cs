namespace Sitecore.Foundation.Channels.Configuration
{
    /// <summary>
    /// The ConfigurationManager interface.
    /// </summary>
    public interface IConfigurationManager
    {
        /// <summary>
        /// The get configuration data.
        /// </summary>
        /// <returns>
        /// The <see cref="T:Sitecore.Social.Configuration.Model.ConfigurationData" />.
        /// </returns>
        ConfigurationData GetConfigurationData();
    }
}
