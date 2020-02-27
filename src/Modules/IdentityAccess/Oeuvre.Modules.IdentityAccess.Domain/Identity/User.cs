using System;
using System.Collections.Generic;
using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.Identity
{
    public class User: IAggregateRoot
    {
        public UserId id { get; private set; }

        private Name name;

        private string loginEmail;

        private string password;

        private bool isActive = true;

        private List<Role> roles;

        private User()
        {
            // Only for EF.
        }


        internal User(UserId id, Name name, string loginEmail, string password)
        {
            this.id = id;
            this.loginEmail = loginEmail;

            this.password = password;

            this.name = name;
        }

    }
}
