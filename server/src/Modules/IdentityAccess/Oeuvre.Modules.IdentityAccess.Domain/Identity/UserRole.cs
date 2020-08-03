using System;
using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.Identity
{
    public class UserRole : Value<UserRole>
    {
        public string Code { get; }

        private UserRole(string code)
        {
            this.Code = code;
        }
    }
}
