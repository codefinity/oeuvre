using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public class FullName
    {
        private string firstName;

        private string lastName;

        public FullName(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

    }
}
