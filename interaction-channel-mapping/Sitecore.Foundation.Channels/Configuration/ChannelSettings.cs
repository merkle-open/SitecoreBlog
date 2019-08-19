using System;
using System.Collections.Generic;

namespace Sitecore.Foundation.Channels.Configuration
{
    /// <summary>
    /// Represents a channel settings.
    /// </summary>
    [Serializable]
    public class ChannelSettings : IEmptyable
    {
        /// <summary>
        /// A read-only instance of the <see cref="T:Sitecore.Social.Configuration.Model.InteractionChannelMappings.ChannelSettings" /> class whose value represents a not defined channel settings.
        /// </summary>
        public static readonly ChannelSettings Empty = new ChannelSettings();

        /// <summary>
        /// Gets the value that indicates whether this instance is empty or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Gets or sets the channel identifier.
        /// </summary>
        /// <value>
        /// The channel identifier.
        /// </value>
        public string ChannelId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the channel mappings.
        /// </summary>
        /// <value>
        /// The channel mappings.
        /// </value>
        public List<ChannelMappingSettings> ChannelMappings
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Social.Configuration.Model.InteractionChannelMappings.ChannelSettings" /> class.
        /// </summary>
        public ChannelSettings()
        {
            ChannelMappings = new List<ChannelMappingSettings>();
        }
    }
}
