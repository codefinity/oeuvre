using System;
using System.Collections.Generic;
using System.Text;
using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.Users
{
    internal class FullName : ValueObject
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
