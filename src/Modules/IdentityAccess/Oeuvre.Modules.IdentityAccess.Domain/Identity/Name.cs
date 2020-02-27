using System;
using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.Identity
{
    public class Name : Value<Name>
    {
        private string firstName;

        private string lastName;

        public Name(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

    }
}
