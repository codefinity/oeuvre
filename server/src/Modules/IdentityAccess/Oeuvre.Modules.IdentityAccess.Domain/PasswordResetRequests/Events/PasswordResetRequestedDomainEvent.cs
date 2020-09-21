using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Events
{
    public class PasswordResetRequestedDomainEvent : DomainEventBase
    {
        public PasswordResetRequestedDomainEvent(PasswordResetRequestId passwordResetRequestId, 
            string eMailId)
        {
            EMailId = eMailId;
            PasswordResetRequestId = passwordResetRequestId;
        }

        public string EMailId { get; }

        public PasswordResetRequestId PasswordResetRequestId { get; private set; }

    }
}
