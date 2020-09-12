using System;
using System.Threading;
using System.Threading.Tasks;
using Domaina.CQRS.Command;
using Domaina.Infrastructure.EMails;
using MediatR;
using Serilog;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail
{
    internal class SendUserRegistrationConfirmationEmailCommandHandler : ICommandHandler<SendUserRegistrationConfirmationEmailCommand>
    {
        private readonly IEmailSender emailSender;
        private readonly ILogger logger;

        public SendUserRegistrationConfirmationEmailCommandHandler(IEmailSender emailSender,
                                                                    ILogger logger)
        {
            this.emailSender = emailSender;
            this.logger = logger;
        }

        public Task<Unit> Handle(SendUserRegistrationConfirmationEmailCommand command, CancellationToken cancellationToken)
        {
            logger.Information("Command - Send user verification link in the EMail");

            var emailMessage = new EmailMessage(
                command.Email,
                "Oeuvre - Please confirm your registration",
                $"Please click on this link to confirm your Registration http://localhost:5000/identityaccess/{command.UserRegistrationId.Value}/confirm");

            emailSender.SendEmail(emailMessage);

            return Unit.Task;
        }
    }
}