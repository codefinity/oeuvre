using System;
using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.Access
{
    public class PermissionRole : Value<PermissionRole>
    {
        public string Code { get; }

        private PermissionRole(string code)
        {
            this.Code = code;
        }
    }
}
