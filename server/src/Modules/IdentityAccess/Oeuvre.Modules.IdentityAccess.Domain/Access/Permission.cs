using System;
using System.Collections.Generic;
using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.Identity;

namespace Oeuvre.Modules.IdentityAccess.Domain.Access
{
    public class Permission : AggregateRoot
    {
        private string accessCode;

        private string accessName;

        private List<PermissionRole> permissionroles;

        public Permission()
        {

        }

        public Permission(Role role, string accessCode, string accessName)
        {
            this.accessCode = accessCode;
            this.accessName = accessName;
        }

        protected override void EnsureValidState()
        {
            throw new NotImplementedException();
        }

        protected override void When(object @event)
        {
            throw new NotImplementedException();
        }
    }
}
