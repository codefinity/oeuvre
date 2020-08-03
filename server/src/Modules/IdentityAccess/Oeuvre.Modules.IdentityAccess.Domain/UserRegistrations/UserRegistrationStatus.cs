using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public class UserRegistrationStatus : ValueObject
    {
        public static UserRegistrationStatus WaitingForConfirmation => new UserRegistrationStatus(nameof(WaitingForConfirmation));
        public static UserRegistrationStatus Confirmed => new UserRegistrationStatus(nameof(Confirmed));
        public static UserRegistrationStatus Expired => new UserRegistrationStatus(nameof(Expired));
        public string Value { get; }

        public UserRegistrationStatus(string value)
        {
            Value = value;
        }
    }
}