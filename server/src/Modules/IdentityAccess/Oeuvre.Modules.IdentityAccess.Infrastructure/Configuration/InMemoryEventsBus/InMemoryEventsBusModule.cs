using Autofac;
using Domaina.Infrastructure.EventBus;
using Domania.EventBus;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.InMemoryEventBus
{
    internal class InMemoryEventsBusModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InMemoryEventBusClient>()
                .As<IEventsBus>()
                .SingleInstance();
        }
    }
}