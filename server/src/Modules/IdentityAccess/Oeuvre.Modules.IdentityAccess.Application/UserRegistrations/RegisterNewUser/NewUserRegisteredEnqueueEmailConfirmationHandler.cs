using System;
using System.Threading;
using System.Threading.Tasks;
using Domania.Domain;
using MediatR;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Events;

namespace CompanyName.MyMeetings.Modules.UserAccess.Application.UserRegistrations.RegisterNewUser
{
    public class NewUserRegisteredEnqueueEmailConfirmationHandler 
         : INotificationHandler<DomainEventNotification<NewUserRegisteredDomainEvent>>
    {
        private readonly IIdentityAccessModule identityAccessModule;

        public NewUserRegisteredEnqueueEmailConfirmationHandler(IIdentityAccessModule identityAccessModule)
        {
            this.identityAccessModule = identityAccessModule;
        }

        public Task Handle(DomainEventNotification<NewUserRegisteredDomainEvent> notification, CancellationToken cancellationToken)
        {
             identityAccessModule.ExecuteCommandAsync(new SendUserRegistrationConfirmationEmailCommand(
                Guid.NewGuid(),
                notification.DomainEvent.UserRegistrationId,
                notification.DomainEvent.EMail));

            return Task.CompletedTask;
        }
    }
}