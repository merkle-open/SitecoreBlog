using System;
using System.Collections.Generic;

namespace Sitecore.Foundation.Channels.Configuration
{
    /// <summary>
    /// The interaction channel mappings configuration.
    /// </summary>
    [Serializable]
    [ConfigurationManager(ManagerType = typeof(InteractionChannelMappingsConfigurationManager))]
    public class InteractionChannelMappingsConfiguration : ConfigurationData
    {
        /// <summary>
        /// A read-only instance of the <see cref="T:Sitecore.Social.Configuration.Model.InteractionChannelMappingsConfiguration" /> class whose value represents a not defined configuration.
        /// </summary>
        public static readonly InteractionChannelMappingsConfiguration Empty = new InteractionChannelMappingsConfiguration();

        /// <summary>
        /// Gets the value that indicates whether this instance is empty or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </value>
        public override bool IsEmpty => this == Empty;

        /// <summary>
        /// Gets or sets the channels.
        /// </summary>
        /// <value>
        /// The channels.
        /// </value>
        public List<ChannelSettings> Channels
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Social.Configuration.Model.InteractionChannelMappingsConfiguration" /> class.
        /// </summary>
        public InteractionChannelMappingsConfiguration()
        {
            Channels = new List<ChannelSettings>();
        }
    }
}
