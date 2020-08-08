

using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Rules
{
    public class UserLoginMustBeUniqueRule : IBusinessRule
    {
        private readonly IUsersCounter usersCounter;
        private readonly string eMailId;

        internal UserLoginMustBeUniqueRule(IUsersCounter usersCounter, string eMailId)
        {
            this.usersCounter = usersCounter;
            this.eMailId = eMailId;
        }

        public bool IsBroken() => usersCounter.CountUsersWithLogin(eMailId) > 0;

        public string Message => "User Login must be unique";
    }
}