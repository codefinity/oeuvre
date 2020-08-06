using Domaina.CQRS;
using System;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser
{
    public class RegisterNewUserCommand : CommandBase<long>
    {
        public RegisterNewUserCommand(string firstName, string lastName, string password, string mobileNumber, string email )
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            MobileNumber = mobileNumber;
            Email = email;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public string Password { get; }
        public string MobileNumber { get; }
        public string Email { get; }

    }
}