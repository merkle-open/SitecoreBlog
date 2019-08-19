using System;

namespace Sitecore.Foundation.Channels.Configuration
{
    /// <summary>
    /// Represents a channel mapping settings.
    /// </summary>
    [Serializable]
    public class ChannelMappingSettings : IEmptyable
    {
        /// <summary>
        /// A read-only instance of the <see cref="T:Sitecore.Social.Configuration.Model.InteractionChannelMappings.ChannelMappingSettings" /> class whose value represents a not defined channel mapping settings.
        /// </summary>
        public static readonly ChannelMappingSettings Empty = new ChannelMappingSettings();

        /// <summary>
        /// Gets the value that indicates whether this instance is empty or not.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </value>
        public bool IsEmpty => this == Empty;

        /// <summary>
        /// Gets or sets the URL referrer host.
        /// </summary>
        /// <value>
        /// The URL referrer host.
        /// </value>
        public string UrlReferrerHost
        {
            get;
            set;
        }
    }
}
