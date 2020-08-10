using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.Users
{
    public class User : Entity, IAggregateRoot
    {
        public UserId Id { get; private set; }

        private TenantId userId;

        private FullName fullName;

        private MobileNumber mobileNumber;

        private string eMailId;

        private string password;

        private List<UserRole> roles;

        private User()
        {

        }
    }
}
