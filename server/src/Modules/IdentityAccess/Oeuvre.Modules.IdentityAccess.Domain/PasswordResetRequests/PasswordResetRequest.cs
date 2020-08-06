using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests
{
    internal class PasswordResetRequest
    {
        public PasswordResetRequestId Id { get; private set; }

        private UserId userId;
    }
}
