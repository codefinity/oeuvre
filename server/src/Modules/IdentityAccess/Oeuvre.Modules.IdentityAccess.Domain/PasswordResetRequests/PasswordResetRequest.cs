using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests
{
    internal class PasswordResetRequest : Entity
    {
        public PasswordResetRequestId Id { get; private set; }

        private UserId userId;
    }
}
