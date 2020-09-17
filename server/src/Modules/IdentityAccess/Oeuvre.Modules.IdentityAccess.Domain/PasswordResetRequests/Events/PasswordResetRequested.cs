using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Events
{
    public class PasswordResetRequested : DomainEventBase
    {
        public PasswordResetRequested(UserId userId)
        {
            UserId = userId;
        }

        public UserId UserId { get; }


    }
}
