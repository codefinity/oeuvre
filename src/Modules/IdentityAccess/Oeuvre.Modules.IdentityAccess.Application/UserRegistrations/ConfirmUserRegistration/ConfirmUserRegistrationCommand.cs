using System;
using Domaina.CQRS;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.ConfirmUserRegistration
{
    public class ConfirmUserRegistrationCommand : CommandBase
    {
        public ConfirmUserRegistrationCommand(long userRegistrationId)
        {
            UserRegistrationId = userRegistrationId;
        }

        public long UserRegistrationId { get; }
    }
}