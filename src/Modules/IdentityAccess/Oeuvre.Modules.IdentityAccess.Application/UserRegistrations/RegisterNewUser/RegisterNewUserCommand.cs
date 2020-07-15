﻿using Domaina.CQRS;
using System;

namespace Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser
{
    public class RegisterNewUserCommand : CommandBase<long>
    {
        public RegisterNewUserCommand(string login, string password, string email, string firstName, string lastName)
        {
            Login = login;
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Login { get; }

        public string Password { get; }

        public string Email { get; }

        public string FirstName { get; }

        public string LastName { get; }
    }
}