using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public class FullName : ValueObject
    {
        private readonly string firstName;

        private readonly string lastName;

        public FullName(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName { get { return firstName; } }

        public string LastName { get { return lastName; } }

    }
}
