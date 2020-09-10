using System.Threading;
using System.Threading.Tasks;
using Domaina.CQRS.Command;
using Domaina.Infrastructure.EMails;
using MediatR;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail
{
    internal class SendUserRegistrationConfirmationEmailCommandHandler : ICommandHandler<SendUserRegistrationConfirmationEmailCommand>
    {
        private readonly IEmailSender emailSender;

        public SendUserRegistrationConfirmationEmailCommandHandler(IEmailSender emailSender)
        {
            this.emailSender = emailSender;
        }

        public Task<Unit> Handle(SendUserRegistrationConfirmationEmailCommand command, CancellationToken cancellationToken)
        {
            var emailMessage = new EmailMessage(
                command.Email,
                "Oeuvre - Please confirm your registration",
                $"Please click on this link to confirm your Registration http://localhost:5000/identityaccess/{command.UserRegistrationId.Value}/confirm");

            emailSender.SendEmail(emailMessage);

            return Unit.Task;
        }
    }
}