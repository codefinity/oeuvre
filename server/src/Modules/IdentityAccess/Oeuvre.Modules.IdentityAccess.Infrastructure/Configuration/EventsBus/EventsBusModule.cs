using Autofac;
using Domaina.Infrastructure.EventBus;
using Domania.EventBus;

namespace CompanyName.MyMeetings.Modules.UserAccess.Infrastructure.Configuration.EventsBus
{
    internal class EventsBusModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryEventBusClient>()
                .As<IEventsBus>()
                .SingleInstance();
        }
    }
}