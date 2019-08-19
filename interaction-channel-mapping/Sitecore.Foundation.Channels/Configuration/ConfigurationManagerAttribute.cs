using System;

namespace Sitecore.Foundation.Channels.Configuration
{
    /// <summary>
    /// The config manager attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ConfigurationManagerAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the manager type.
        /// </summary>
        public Type ManagerType
        {
            get;
            set;
        }
    }
}
