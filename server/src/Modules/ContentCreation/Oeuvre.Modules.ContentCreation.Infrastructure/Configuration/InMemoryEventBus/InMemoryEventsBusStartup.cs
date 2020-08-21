using Autofac;
using Domaina.Infrastructure.EventBus;
using Oeuvre.Modules.IdentityAccess.IntegrationEvents;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using Oeuvre.Modules.ContentCreation.Infrastructure.PortsAndAdapters.Listeners.InMemory;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.Configuration.InMemoryEventBus
{
    public static class InMemoryEventsBusStartup
    {
        public static void Initialize(ILogger logger)
        {
            SubscribeToIntegrationEvents(logger);
        }

        private static void SubscribeToIntegrationEvents(ILogger logger)
        {
            var eventBus = ContentCreationCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();

            eventBus.Subscribe(new UserCreatedIntegrationEventListener<UserCreatedIntegrationEvent>());

            //SubscribeToIntegrationEvent<NewUserRegisteredIntegrationEvent>(eventBus, logger);
            //SubscribeToIntegrationEvent<MeetingGroupProposalAcceptedIntegrationEvent>(eventBus, logger);
            //SubscribeToIntegrationEvent<SubscriptionExpirationDateChangedIntegrationEvent>(eventBus, logger);
            //SubscribeToIntegrationEvent<MeetingFeePaidIntegrationEvent>(eventBus, logger);
        }

    }

}
