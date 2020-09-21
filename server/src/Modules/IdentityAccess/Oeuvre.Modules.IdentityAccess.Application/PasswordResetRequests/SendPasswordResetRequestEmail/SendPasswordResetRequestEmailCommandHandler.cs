using Domaina.CQRS.Command;
using Domaina.Infrastructure.EMails;
using MediatR;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.SendPasswordResetRequestEmail
{
    internal class SendPasswordResetRequestEmailCommandHandler : ICommandHandler<SendPasswordResetRequestEmailCommand>
    {
        private readonly IEmailSender emailSender;
        private readonly ILogger logger;

        public SendPasswordResetRequestEmailCommandHandler(IEmailSender emailSender,
                                                                    ILogger logger)
        {
            this.emailSender = emailSender;
            this.logger = logger;
        }

        public Task<Unit> Handle(SendPasswordResetRequestEmailCommand command, CancellationToken cancellationToken)
        {
            logger.Information("Command - Send password reset link in the EMail");

            var emailMessage = new EmailMessage(
                command.Email,
                "Oeuvre - Please Reset Your Password",
                $"Please click on this link to reset your password http://localhost:5000/identityaccess/{command.PasswordResetRequestId.Value}/resetpassword");

            emailSender.SendEmail(emailMessage);

            return Unit.Task;
        }
    }
}
