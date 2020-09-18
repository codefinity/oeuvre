using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Rules
{
    public class PasswordCannotBeResetAfterRequestExpirationRule : IBusinessRule
    {
        private readonly IPasswordResetExpirationCalculator expirationCalculator;
        private readonly DateTime registrationDate;
        internal PasswordCannotBeResetAfterRequestExpirationRule(
                                IPasswordResetExpirationCalculator expirationCalculator,
                                DateTime registrationDate)
        {
            this.expirationCalculator = expirationCalculator;
            this.registrationDate = registrationDate;
        }

        public bool IsBroken()
        {
            DateTime expirationDate = expirationCalculator.Calculate(registrationDate);

            bool isBroken = SystemClock.Now > expirationDate;

            return isBroken;
        }

        public string Message => "Password Cannot be reset because the request is expired";
    }
}
