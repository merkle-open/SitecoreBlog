using System;
using System.Linq;
using Sitecore.Abstractions;
using Sitecore.Analytics.OmniChannel.Pipelines.DetermineInteractionChannel;
using Sitecore.Data;
using Sitecore.Foundation.Channels.Configuration;

namespace Sitecore.Foundation.Channels.Pipelines.DetermineInteractionChannel
{
    /// <summary>
    /// Determines the social channels for the interaction.
    /// </summary>
    /// <remarks>
    /// The social channels to be determined are listed at the <see cref="T:Sitecore.Social.Configuration.Model.InteractionChannelMappingsConfiguration" />.
    /// </remarks>
    public class SocialChannels : DetermineChannelProcessorBase
    {
        private readonly IConfigurationFactory _configurationFactory;
        private readonly BaseLog _log;

        public SocialChannels(IConfigurationFactory configurationFactory, BaseLog log)
        {
            _configurationFactory = configurationFactory;
            _log = log;
        }

        /// <summary>
        /// Runs the processor.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public override void Process(DetermineChannelProcessorArgs args)
        {
            DoProcess(args);
        }

        /// <summary>
        /// Executes the process event.
        /// </summary>
        /// <param name="args">The arguments.</param>
        protected void DoProcess(DetermineChannelProcessorArgs args)
        {
            try
            {
                if (args.Interaction != null && !string.IsNullOrEmpty(args.Interaction.Referrer))
                {
                    InteractionChannelMappingsConfiguration interactionChannelMappingsConfiguration = _configurationFactory.Get<InteractionChannelMappingsConfiguration>();

                    if (interactionChannelMappingsConfiguration.IsEmpty)
                    {
                        _log.Warn("No InteractionChannelMappingsConfiguration found. Interaction-socialchannel-mapping only works properly if there is a <interactionChannelMappings> node present in the configuration.", this);
                    }

                    Uri interactionUrlReferrer = new Uri(args.Interaction.Referrer);
                    ChannelSettings channelSettings2 = (from channelSettings in interactionChannelMappingsConfiguration.Channels
                        where !string.IsNullOrEmpty(channelSettings.ChannelId)
                        select channelSettings).FirstOrDefault((ChannelSettings channelSettings) => channelSettings.ChannelMappings.Any((ChannelMappingSettings channelMappingSettings) => string.Compare(channelMappingSettings.UrlReferrerHost, interactionUrlReferrer.Host, StringComparison.InvariantCultureIgnoreCase) == 0));
                    if (channelSettings2 != null)
                    {
                        args.ChannelId = ID.Parse(channelSettings2.ChannelId);
                        _log.Debug($"Interaction has been mapped to channel '{args.ChannelId}' for referrer '{args.Interaction.Referrer}'");
                    }
                }
            }
            catch (Exception exception)
            {
                _log.Error("Couldn't determine the social channels for the interaction.", exception, this);
            }
        }
    }
}