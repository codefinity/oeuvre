using Domania.Domain;
using MediatR;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.Users.ResetPassword
{
    public class NewPasswordReceivedEventHandler
         : INotificationHandler<DomainEventNotification<NewPasswordReceivedDomainEvent>>
    {
        private readonly IIdentityAccessModule identityAccessModule;
        private readonly ILogger logger;

        public NewPasswordReceivedEventHandler(
            IIdentityAccessModule identityAccessModule,
            ILogger logger)
        {
            this.identityAccessModule = identityAccessModule;
            this.logger = logger;
        }

        public Task Handle(DomainEventNotification<NewPasswordReceivedDomainEvent> notification, CancellationToken cancellationToken)
        {
            logger.Information("Domain Event - New User Registered");

            identityAccessModule.ExecuteCommandAsync(new ResetPasswordCommand(
                Guid.NewGuid(),
                notification.DomainEvent.EMailId,
                notification.DomainEvent.NewPassword));

            return Task.CompletedTask;
        }
    }
}
