using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserSettings
{
    internal class UserSetting : Entity
    {
        public UserSettingId Id { get; private set; }

        private UserId userId;

        private readonly bool emailPublicVisibility;

        private readonly bool mobileNoPublicVisibility;

    }
}
