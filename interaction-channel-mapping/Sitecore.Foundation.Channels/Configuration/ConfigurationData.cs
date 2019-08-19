using System;

namespace Sitecore.Foundation.Channels.Configuration
{
    /// <summary>
    /// The configuration data.
    /// </summary>
    [Serializable]
    public abstract class ConfigurationData : IEmptyable
    {
        /// <summary>
        /// Returns a Boolean value indicating if the specified instance is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </value>
        public abstract bool IsEmpty
        {
            get;
        }
    }
}
