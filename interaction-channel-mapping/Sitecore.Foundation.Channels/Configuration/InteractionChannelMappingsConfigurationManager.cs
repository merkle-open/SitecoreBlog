using System.Xml;
using Sitecore.Configuration;

namespace Sitecore.Foundation.Channels.Configuration
{
    /// <summary>
    /// The interaction channel mappings configuration manager.
    /// </summary>
    public class InteractionChannelMappingsConfigurationManager : ConfigurationManager
    {
        /// <summary>
        /// Gets the interaction channel mappings configuration data.
        /// </summary>
        /// <returns>The interaction channel mappings configuration data.</returns>
        public override ConfigurationData GetConfigurationData()
        {
            XmlNode configNode = Factory.GetConfigNode("social/interactionChannelMappings", assert: false);
            if (configNode == null)
            {
                return InteractionChannelMappingsConfiguration.Empty;
            }
            InteractionChannelMappingsConfiguration interactionChannelMappingsConfiguration = new InteractionChannelMappingsConfiguration();
            XmlNodeList xmlNodeList = configNode.SelectNodes("channel");
            if (xmlNodeList == null || xmlNodeList.Count == 0)
            {
                return interactionChannelMappingsConfiguration;
            }
            foreach (object item in xmlNodeList)
            {
                interactionChannelMappingsConfiguration.Channels.Add(GetChannelSettings((XmlNode)item));
            }
            return interactionChannelMappingsConfiguration;
        }

        /// <summary>
        /// Gets the channel settings.
        /// </summary>
        /// <param name="channelNode">The channel node.</param>
        /// <returns>The channel settings.</returns>
        protected ChannelSettings GetChannelSettings(XmlNode channelNode)
        {
            ChannelSettings channelSettings = new ChannelSettings();
            if (channelNode.Attributes != null)
            {
                channelSettings.ChannelId = GetAttribute(channelNode, "channelId");
            }
            XmlNodeList xmlNodeList = channelNode.SelectNodes("channelMapping");
            if (xmlNodeList == null || xmlNodeList.Count == 0)
            {
                return channelSettings;
            }
            foreach (object item in xmlNodeList)
            {
                channelSettings.ChannelMappings.Add(GetChannelMappingSettings((XmlNode)item));
            }
            return channelSettings;
        }

        /// <summary>
        /// Gets the channel mapping settings.
        /// </summary>
        /// <param name="channelMappingNode">The channel mapping node.</param>
        /// <returns>The channel mapping settings.</returns>
        protected ChannelMappingSettings GetChannelMappingSettings(XmlNode channelMappingNode)
        {
            ChannelMappingSettings channelMappingSettings = new ChannelMappingSettings();
            if (channelMappingNode.Attributes != null)
            {
                channelMappingSettings.UrlReferrerHost = GetAttribute(channelMappingNode, "urlReferrerHost");
            }
            return channelMappingSettings;
        }
    }
}
