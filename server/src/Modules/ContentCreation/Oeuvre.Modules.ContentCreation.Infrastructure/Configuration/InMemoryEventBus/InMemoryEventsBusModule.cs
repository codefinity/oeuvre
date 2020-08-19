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
        private readonly IEventsBus _eventsBus;

        public InMemoryEventsBusModule(IEventsBus eventsBus)
        {
            _eventsBus = eventsBus;
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_eventsBus != null)
            {
                builder.RegisterInstance(_eventsBus).SingleInstance();
            }
            else
            {
                builder.RegisterType<InMemoryEventBusClient>()
                .As<IEventsBus>()
                .SingleInstance();

            }
        }
    }
}
