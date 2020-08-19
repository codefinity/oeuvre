using Autofac;
using Domaina.Infrastructure.EventBus;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration;
using Serilog;

namespace CompanyName.MyMeetings.Modules.UserAccess.Infrastructure.Configuration.EventsBus
{
    public static class EventsBusStartup
    {
        public static void Initialize(
            ILogger logger)
        {
            SubscribeToIntegrationEvents(logger);
        }

        private static void SubscribeToIntegrationEvents(ILogger logger)
        {
            //var eventBus = IdentityAccessCompositionRoot.BeginLifetimeScope().Resolve<IEventsBus>();

            //SubscribeToIntegrationEvent<MemberCreatedIntegrationEvent>(eventBus, logger);
        }

    }
}