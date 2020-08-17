using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public class FullName : ValueObject
    {
        //public string firstName;

        //public string lastName;

        public FullName(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName { get; }

        public string LastName { get; }

    }
}
