using System;
using Domaina.CQRS.Command;
using Newtonsoft.Json;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail
{
    public class SendUserRegistrationConfirmationEmailCommand : InternalCommandBase
    {
        public SendUserRegistrationConfirmationEmailCommand(Guid id, UserRegistrationId userRegistrationId, string email)
        : base(id)
        {
            UserRegistrationId = userRegistrationId;
            Email = email;
        }

        internal UserRegistrationId UserRegistrationId { get; }

        internal string Email { get; }
    }
}