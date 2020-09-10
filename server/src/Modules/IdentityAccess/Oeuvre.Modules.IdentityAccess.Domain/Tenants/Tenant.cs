using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.Tenants
{
    public class Tenant : Entity, IAggregateRoot
    {
        public TenantId Id { get; private set; }

        private string name;

        private bool isActive;

        private Tenant()
        {
            // Only EF.
        }

        private Tenant(TenantId tenantId, 
                        string name,
                        bool isActive)
        {
            this.Id = tenantId;
            this.name = name;
            this.isActive = isActive;
        }

        //public User ProvisionAdministrator()
        //{


        //}

        public void Activate()
        {
            isActive = true;
        }

        public void Deactivate()
        {
            isActive = false;
        }

    }
}
