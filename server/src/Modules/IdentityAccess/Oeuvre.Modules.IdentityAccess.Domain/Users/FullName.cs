using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.Users
{
    internal class FullName
    {
        private readonly string firstName;

        private readonly string lastName;

        public FullName(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
