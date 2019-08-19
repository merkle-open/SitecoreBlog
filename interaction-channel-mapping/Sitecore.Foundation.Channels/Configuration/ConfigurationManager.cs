using System.Xml;

namespace Sitecore.Foundation.Channels.Configuration
{
    /// <summary>
    /// The configuration manager.
    /// </summary>
    public abstract class ConfigurationManager : IConfigurationManager
    {
        /// <summary>
        /// The get configuration data.
        /// </summary>
        /// <returns>
        /// The <see cref="T:Sitecore.Social.Configuration.Model.ConfigurationData" />.
        /// </returns>
        public abstract ConfigurationData GetConfigurationData();

        /// <summary>
        /// Gets the attribute value.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="attribute">The attribute.</param>
        /// <returns>The attribute value.</returns>
        protected string GetAttribute(XmlNode node, string attribute)
        {
            if (node.Attributes == null || node.Attributes[attribute] == null)
            {
                return string.Empty;
            }
            return node.Attributes[attribute].Value;
        }
    }
}
