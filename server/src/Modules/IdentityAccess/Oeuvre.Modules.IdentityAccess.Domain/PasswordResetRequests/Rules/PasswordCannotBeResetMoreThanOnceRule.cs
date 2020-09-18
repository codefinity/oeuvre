using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Rules
{
    public class PasswordCannotBeResetMoreThanOnceRule : IBusinessRule
    {
        private readonly PasswordRequestStatus actualRegistrationStatus;

        public PasswordCannotBeResetMoreThanOnceRule(PasswordRequestStatus actualRegistrationStatus)
        {
            this.actualRegistrationStatus = actualRegistrationStatus;
        }

        public bool IsBroken() => actualRegistrationStatus == PasswordRequestStatus.NewPasswordReceived;

        public string Message => "Password cannot be reset more than once";
    }
}
