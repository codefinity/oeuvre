using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Rules
{
    public class UserLoginEMailIdMustExistRule : IBusinessRule
    {
        private readonly IUserFinder userFinder;
        private readonly string eMailId;

        internal UserLoginEMailIdMustExistRule(string eMailId, IUserFinder userFinder)
        {
            this.eMailId = eMailId;
            this.userFinder = userFinder;
        }

        public bool IsBroken()
        {
            bool userFoundBroken = userFinder.FindUser(eMailId).UserExists;

            return !userFoundBroken;
        }

        public string Message => "User with email Id must exist";
    }
}
