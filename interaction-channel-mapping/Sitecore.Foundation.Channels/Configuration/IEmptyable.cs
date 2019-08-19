namespace Sitecore.Foundation.Channels.Configuration
{
    // IEmptyable
    /// <summary>
    /// Defines the property that is used to check if an entity is empty.
    /// </summary>
    public interface IEmptyable
    {
        /// <summary>
        /// Returns a Boolean value indicating if the specified instance is empty.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is empty; otherwise, <c>false</c>.
        /// </value>
        bool IsEmpty
        {
            get;
        }
    }
}
