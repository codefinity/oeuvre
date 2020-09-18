using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Events
{
    public class PasswordResetRequestedDomainEvent : DomainEventBase
    {
        public PasswordResetRequestedDomainEvent(string eMailId)
        {
            EMailId = eMailId;
        }

        public string EMailId { get; }

    }
}
