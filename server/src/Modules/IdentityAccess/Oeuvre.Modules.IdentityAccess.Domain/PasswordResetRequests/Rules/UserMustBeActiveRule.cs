using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Rules
{
    public class UserMustBeActiveRule : IBusinessRule
    {
        private readonly IUserFinder userFinder;
        private readonly string eMailId;

        internal UserMustBeActiveRule(string eMailId, IUserFinder userFinder)
        {
            this.eMailId = eMailId;
            this.userFinder = userFinder;
        }

        public bool IsBroken()
        {
            bool userFoundBroken = userFinder.FindUser(eMailId).Active;

            return !userFoundBroken;
        }

        public string Message => "User must be active";
    }
}
