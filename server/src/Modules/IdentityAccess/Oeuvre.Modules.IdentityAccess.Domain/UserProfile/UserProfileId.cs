using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserProfile
{
   public class UserProfileId : TypedIdValueBase
    {
        public UserProfileId(Guid value) : base(value)
        {
        }
    }
}
