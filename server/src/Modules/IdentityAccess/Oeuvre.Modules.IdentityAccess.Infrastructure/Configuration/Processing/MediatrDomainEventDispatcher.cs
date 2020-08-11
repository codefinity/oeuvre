using Autofac;
using Domaina.Infrastructure;
using Domania.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration.Processing
{
    public class MediatrDomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator mediator;
        //private readonly ILogger<MediatrDomainEventDispatcher> _log;
        public MediatrDomainEventDispatcher(IMediator mediator
            //, ILogger<MediatrDomainEventDispatcher> log
            )
        {
            this.mediator = mediator;
            //_log = log;
        }

        public async Task Dispatch(IDomainEvent devent)
        {

            var domainEventNotification = _createDomainEventNotification(devent);
            //_log.LogDebug("Dispatching Domain Event as MediatR notification.  EventType: {eventType}", devent.GetType());


            await mediator.Publish(domainEventNotification);

        }

        private INotification _createDomainEventNotification(IDomainEvent domainEvent)
        {
            var genericDispatcherType = typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType());
            return (INotification)Activator.CreateInstance(genericDispatcherType, domainEvent);

        }
    }
}
