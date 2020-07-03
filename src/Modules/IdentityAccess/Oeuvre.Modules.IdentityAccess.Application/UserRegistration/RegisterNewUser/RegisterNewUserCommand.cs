using System;
using Oeuvre.Modules.IdentityAccess.Application.CQRS;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistration.RegisterNewUser
{
    public class RegisterNewUserCommand : ICommand
    {
        public RegisterNewUserCommand(string firstName, string lastName, string email, string password)
        {
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Password { get; }

        public string Email { get; }

        public string FirstName { get; }

        public string LastName { get; }
    }
}
