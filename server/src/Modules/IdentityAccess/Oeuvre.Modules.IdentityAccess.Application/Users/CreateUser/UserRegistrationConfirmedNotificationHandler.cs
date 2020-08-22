using System;
using System.Threading;
using System.Threading.Tasks;
using Domania.Domain;
using MediatR;
using Domaina.CQRS;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Events;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.CreateUser
{
    public class UserRegistrationConfirmedNotificationHandler 
                : INotificationHandler<DomainEventNotification<UserRegistrationConfirmedDomainEvent>>
    {
        private readonly IIdentityAccessModule identityAccessModule;

        public UserRegistrationConfirmedNotificationHandler(IIdentityAccessModule identityAccessModule)
        {
            this.identityAccessModule = identityAccessModule;
        }

        public Task Handle(DomainEventNotification<UserRegistrationConfirmedDomainEvent> notification, CancellationToken cancellationToken)
        {
            identityAccessModule.ExecuteCommandAsync(new CreateUserCommand(Guid.NewGuid(), notification.DomainEvent.UserRegistrationId));

            return Task.CompletedTask;
        }
    }
}