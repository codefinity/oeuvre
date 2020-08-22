using Domania.Domain;
using Domania.EventBus;
using MediatR;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Events;
using Oeuvre.Modules.IdentityAccess.IntegrationEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser
{
    public class NewUserRegisteredPublishEventHandler 
                    : INotificationHandler<DomainEventNotification<NewUserRegisteredDomainEvent>>
    {

        private readonly IEventsBus eventsBus;

        public NewUserRegisteredPublishEventHandler(IEventsBus eventsBus)
        {
            this.eventsBus = eventsBus;
        }
        public Task Handle(DomainEventNotification<NewUserRegisteredDomainEvent> notification, CancellationToken cancellationToken)
        {
            //eventsBus.Publish(new NewUserCreatedIntegrationEvent(
            //                                    notification.DomainEvent.Id,
            //                                    notification.DomainEvent.OccurredOn,
            //                                    notification.DomainEvent.UserRegistrationId.Value,
            //                                    notification.DomainEvent.TenantId.Value,
            //                                    notification.DomainEvent.FirstName,
            //                                    notification.DomainEvent.LastName,
            //                                    notification.DomainEvent.EMail,
            //                                    notification.DomainEvent.MobileNumber));

            return Task.CompletedTask;
        }











        //Reference from: https://cfrenzel.com/domain-events-efcore-mediatr/
        //public Task Handle(DomainEventNotification<NewUserRegisteredDomainEvent> notification, CancellationToken cancellationToken)
        //{
        //    var domainEvent = notification.DomainEvent;
        //    try
        //    {
        //        //_log.LogDebug("Handling Domain Event. BacklogItemId: {itemId}  Type: {type}", domainEvent.BacklogItemId, notification.GetType());
        //        //from here you could 
        //        // - create/modify entities within the same transactions that committed the backlogItem
        //        // - trigger the publishing of an integrtion event on a servicebus (don't write it directly though, you need an outbox scoped to this transaction)

        //        //Remember NOT to call SaveChanges on dbcontext if making db changes when handling DomainEvents
        //        return Task.CompletedTask;
        //    }
        //    catch (Exception exc)
        //    {
        //        //_log.LogError(exc, "Error handling domain event {domainEvent}", domainEvent.GetType());
        //        throw;
        //    }
        //}
    }
}
