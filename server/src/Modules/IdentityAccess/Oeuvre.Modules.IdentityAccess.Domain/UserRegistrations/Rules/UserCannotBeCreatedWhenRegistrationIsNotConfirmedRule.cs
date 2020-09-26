using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Rules
{
    public class UserCannotBeCreatedWhenRegistrationIsNotConfirmedRule : IBusinessRule
    {
        private readonly UserRegistrationStatus actualRegistrationStatus;

        internal UserCannotBeCreatedWhenRegistrationIsNotConfirmedRule(UserRegistrationStatus actualRegistrationStatus)
        {
            this.actualRegistrationStatus = actualRegistrationStatus;
        }

        public bool IsBroken() => actualRegistrationStatus != UserRegistrationStatus.Confirmed;

        public string Message => "User cannot be created when registration is not confirmed";
    }
}