using Domania.Domain;
using MediatR;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.SendPasswordResetRequestEmail;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.RequestPassswordReset
{
    public class PasswordResetRequestedEnqueResetEmailHandler
                                : INotificationHandler<DomainEventNotification<PasswordResetRequestedDomainEvent>>
    {
        private readonly IIdentityAccessModule identityAccessModule;
        private readonly ILogger logger;

        public PasswordResetRequestedEnqueResetEmailHandler(
            IIdentityAccessModule identityAccessModule,
            ILogger logger)
        {
            this.identityAccessModule = identityAccessModule;
            this.logger = logger;
        }

        public Task Handle(DomainEventNotification<PasswordResetRequestedDomainEvent> notification, CancellationToken cancellationToken)
        {
            logger.Information("Domain Event - New User Registered");

            identityAccessModule.ExecuteCommandAsync(new SendPasswordResetRequestEmailCommand(
                Guid.NewGuid(),
                notification.DomainEvent.PasswordResetRequestId,
                notification.DomainEvent.EMailId));

            return Task.CompletedTask;
        }
    }
}
