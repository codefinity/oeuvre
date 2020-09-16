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

        //Had to add async to the method and commented "return Task.CompletedTask;" 
        //because the integration test gave an error due to async/await issues
        //TesName - Patch_Confirm_User_Registration_Valid_Success()
        //Removed Async - Need to develop better stratergy for Integrating Testing
        //Business rule: 
        //this.CheckRule(new UserCannotBeCreatedWhenRegistrationIsNotConfirmedRule(status));
        //Not working because of this
        //Find Solution
        public Task Handle(DomainEventNotification<UserRegistrationConfirmedDomainEvent> notification, CancellationToken cancellationToken)
        {
             identityAccessModule.ExecuteCommandAsync(new CreateUserCommand(Guid.NewGuid(), notification.DomainEvent.UserRegistrationId));

            return Task.CompletedTask;
        }
    }
}