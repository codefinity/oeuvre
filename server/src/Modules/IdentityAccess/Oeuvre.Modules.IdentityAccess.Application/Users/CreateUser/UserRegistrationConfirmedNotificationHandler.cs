using System;
using System.Threading;
using System.Threading.Tasks;
using Domania.Domain;
using MediatR;
using Oeuvre.Modules.IdentityAccess.Application.Configuration.Commands;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Events;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.CreateUser
{
    public class UserRegistrationConfirmedNotificationHandler : INotificationHandler<DomainEventNotification<UserRegistrationConfirmedDomainEvent>>
    {
        private readonly ICommandsScheduler commandsScheduler;

        public UserRegistrationConfirmedNotificationHandler(ICommandsScheduler commandsScheduler)
        {
            this.commandsScheduler = commandsScheduler;
        }

        public Task Handle(DomainEventNotification<UserRegistrationConfirmedDomainEvent> notification, CancellationToken cancellationToken)
        {
            commandsScheduler.EnqueueAsync(new CreateUserCommand(Guid.NewGuid(), notification.DomainEvent.UserRegistrationId));

            //await CommandsExecutor.Execute(command);

            return Task.CompletedTask;
        }
    }
}