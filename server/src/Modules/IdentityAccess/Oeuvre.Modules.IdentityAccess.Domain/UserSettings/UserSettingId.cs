using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserSettings
{
    public class UserSettingId : TypedIdValueBase
    {
        public UserSettingId(Guid value) : base(value)
        {
        }
    }
}
