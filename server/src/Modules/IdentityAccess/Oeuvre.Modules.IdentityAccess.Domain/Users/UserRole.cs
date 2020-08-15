using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.Users
{
    public class UserRole : ValueObject
    {
        public static UserRole Member => new UserRole(nameof(Member));
        public static UserRole User => new UserRole(nameof(User));
        public static UserRole Writer => new UserRole(nameof(Writer));
        public string Value { get; }

        private UserRole(string value)
        {
            this.Value = value;
        }
    }
}
