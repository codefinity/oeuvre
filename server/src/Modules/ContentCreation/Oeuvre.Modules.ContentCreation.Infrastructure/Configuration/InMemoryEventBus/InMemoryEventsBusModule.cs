using Autofac;
using Domaina.Infrastructure.EventBus;
using Domania.EventBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Infrastructure.Configuration.InMemoryEventBus
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
