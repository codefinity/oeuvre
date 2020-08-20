using Autofac;
using Domaina.Infrastructure;
using Domania.Domain;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.Processing
{
    public class MediatrDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator mediator;
        private readonly ILogger log;
        public MediatrDomainEventDispatcher(IMediator mediator, ILogger log)
        {
            this.mediator = mediator;
            this.log = log;
        }

        public async Task Dispatch(IDomainEvent domainEvent)
        {
            var domainEventNotification = createDomainEventNotification(domainEvent);
            
            log.Information("Dispatching Domain Event as MediatR notification.  EventType: {eventType}", domainEvent.GetType());

            await mediator.Publish(domainEventNotification);
        }

        private INotification createDomainEventNotification(IDomainEvent domainEvent)
        {
            var genericDispatcherType = typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType());
            return (INotification)Activator.CreateInstance(genericDispatcherType, domainEvent);

        }
    }
}
