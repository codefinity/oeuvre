using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Events
{
    public class NewPasswordReceivedDomainEvent : DomainEventBase
    {
        public NewPasswordReceivedDomainEvent(string eMailId, string newPassword)
        {
            EMailId = eMailId;
            NewPassword = newPassword;
        }

        public string EMailId { get; }

        public string NewPassword { get; }


    }
}
