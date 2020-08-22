using Domania.Domain;
using Domania.EventBus;
using MediatR;
using Oeuvre.Modules.IdentityAccess.Domain.Users.Events;
using Oeuvre.Modules.IdentityAccess.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.CreateUser
{
    public class UserCreatedPublishEventHandler 
                : INotificationHandler<DomainEventNotification<UserCreatedDomainEvent>>
    {

        private readonly IEventsBus eventsBus;

        public UserCreatedPublishEventHandler(IEventsBus eventsBus)
        {
            this.eventsBus = eventsBus;
        }

        public Task Handle(DomainEventNotification<UserCreatedDomainEvent> notification, CancellationToken cancellationToken)
        {

            eventsBus.Publish(new UserCreatedIntegrationEvent(
                                                notification.DomainEvent.Id,
                                                notification.DomainEvent.OccurredOn,
                                                notification.DomainEvent.UserId.Value,
                                                notification.DomainEvent.TenantId.Value,
                                                notification.DomainEvent.FirstName,
                                                notification.DomainEvent.LastName,
                                                notification.DomainEvent.EMail));

            return Task.CompletedTask;
        }
    }
}
