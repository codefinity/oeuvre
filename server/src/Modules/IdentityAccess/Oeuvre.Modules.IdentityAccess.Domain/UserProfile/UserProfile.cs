using Oeuvre.Modules.IdentityAccess.Domain.Tenants;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserProfile
{
    internal class UserProfile
    {
        public UserProfileId Id { get; private set; }

        private UserId userId;
    }
}
