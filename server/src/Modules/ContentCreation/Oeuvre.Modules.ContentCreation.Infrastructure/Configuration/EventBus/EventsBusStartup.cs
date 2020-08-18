using Autofac;
using Domaina.Infrastructure.EventBus;
using Oeuvre.Modules.IdentityAccess.IntegrationEvents;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.Configuration.EventBus
{
    public static class EventsBusStartup
    {
        public static void Initialize(ILogger logger)
        {
            SubscribeToIntegrationEvents(logger);
        }

        private static void SubscribeToIntegrationEvents(ILogger logger)
        {
            var eventBus = ContentCreationCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();

            SubscribeToIntegrationEvent<NewUserRegisteredIntegrationEvent>(eventBus, logger);

            //SubscribeToIntegrationEvent<MeetingGroupProposalAcceptedIntegrationEvent>(eventBus, logger);
            //SubscribeToIntegrationEvent<SubscriptionExpirationDateChangedIntegrationEvent>(eventBus, logger);
            //SubscribeToIntegrationEvent<MeetingFeePaidIntegrationEvent>(eventBus, logger);
        }

        private static void SubscribeToIntegrationEvent<T>(IEventsBus eventBus, ILogger logger) where T : IntegrationEvent
        {
            logger.Information("Subscribe to {@IntegrationEvent}", typeof(T).FullName);

            eventBus.Subscribe(new IntegrationEventGenericHandler<T>());
        }
    }

}
