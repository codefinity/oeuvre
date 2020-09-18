using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Rules
{
    class PasswordCannotBeResetMoreThanOnceRule : IBusinessRule
    {
        private readonly PasswordRequestStatus actualRegistrationStatus;

        internal PasswordCannotBeResetMoreThanOnceRule(PasswordRequestStatus actualRegistrationStatus)
        {
            this.actualRegistrationStatus = actualRegistrationStatus;
        }

        public bool IsBroken() => actualRegistrationStatus == PasswordRequestStatus.NewPasswordReveived;

        public string Message => "Password cannot be reset more than once";
    }
}
