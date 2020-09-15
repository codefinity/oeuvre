
using Domania.Domain;
using System;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Rules
{
    public class UserRegistrationCannotBeConfirmedAfterExpirationRule : IBusinessRule
    {
        private readonly IUserRegistrationConfirmationExpirationCalculator expirationCalculator;
        private readonly DateTime registrationDate;
        internal UserRegistrationCannotBeConfirmedAfterExpirationRule(
                                IUserRegistrationConfirmationExpirationCalculator expirationCalculator,
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

        public string Message => "User Registration cannot be confirmed because it is expired";
    }
}