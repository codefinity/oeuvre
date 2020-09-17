using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.Users.Rules
{

    public class UserLoginEMailIdMustExistRule : IBusinessRule
    {
        private readonly IUserFinder userFinder;
        private readonly string eMailId;

        internal UserLoginEMailIdMustExistRule(IUserFinder userFinder, string eMailId)
        {
            this.userFinder = userFinder;
            this.eMailId = eMailId;
        }

        public bool IsBroken()
        {
            int userCount = userFinder.FindUser(eMailId);

            bool userFoundBroken = userCount == 1;

            return !userFoundBroken;
        }

        public string Message => "User with email Id must exist";
    }
}
