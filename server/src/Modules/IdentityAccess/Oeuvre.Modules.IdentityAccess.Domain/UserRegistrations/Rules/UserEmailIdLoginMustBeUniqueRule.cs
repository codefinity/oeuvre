

using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Rules
{
    public class UserEmailIdLoginMustBeUniqueRule : IBusinessRule
    {
        private readonly IUsersCounter usersCounter;
        private readonly string eMailId;

        internal UserEmailIdLoginMustBeUniqueRule(IUsersCounter usersCounter, string eMailId)
        {
            this.usersCounter = usersCounter;
            this.eMailId = eMailId;
        }

        public bool IsBroken()
        {
            int userCount = usersCounter.CountUsersWithLogin(eMailId);

            bool isUserCountGreaterThanZero = userCount > 0;

            return isUserCountGreaterThanZero;
        }

        public string Message => "User Login Email Id must be unique";
    }
}