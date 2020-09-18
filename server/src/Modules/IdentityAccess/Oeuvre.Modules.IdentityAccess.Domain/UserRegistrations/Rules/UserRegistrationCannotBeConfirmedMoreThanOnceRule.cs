using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Rules
{
    public class UserRegistrationCannotBeConfirmedMoreThanOnceRule : IBusinessRule
    {
        private readonly UserRegistrationStatus actualRegistrationStatus;

        internal UserRegistrationCannotBeConfirmedMoreThanOnceRule(UserRegistrationStatus actualRegistrationStatus)
        {
            this.actualRegistrationStatus = actualRegistrationStatus;
        }

        public bool IsBroken() => actualRegistrationStatus == UserRegistrationStatus.Confirmed;

        public string Message => "User Registration cannot be confirmed more than once";
    }
}