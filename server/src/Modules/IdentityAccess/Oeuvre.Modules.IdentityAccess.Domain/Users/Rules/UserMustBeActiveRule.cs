using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.Users.Rules
{
    public class UserMustBeActiveRule : IBusinessRule
    {
        private readonly bool active;

        internal UserMustBeActiveRule(bool active)
        {
            this.active = active;
        }

        public bool IsBroken() => active == false;

        public string Message => "User is not active";
    }
}
