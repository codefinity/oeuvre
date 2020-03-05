using System;
using System.Collections.Generic;
using Domania.Domain;

namespace Oeuvre.Modules.IdentityAccess.Domain.Identity
{
    public class User: AggregateRoot
    {
        // Properties to handle the persistence
        public UserId UserId { get; private set; }

        //private Name name;

        private string loginEmail;

        private string password;

        private bool isActive = true;

        private List<UserRole> userroles;

        private User()
        {
            // Only for EF.
        }

        internal User(UserId id,
            //Name name,
            string loginEmail, string password)
        {
            this.Id = id;
            this.loginEmail = loginEmail;

            this.password = password;

            //this.name = name;
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }

        protected override void EnsureValidState()
        {
            throw new NotImplementedException();
        }
    }
}
