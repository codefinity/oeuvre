using Domania.Domain;
using Oeuvre.Modules.ContentCreation.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Domain.Collaborators
{
    public class Collaborator : Entity
    {
        public CollaboratorId id;

        private TenantId tenantId;

        private string name;

        private string email;

        public Collaborator(CollaboratorId id, TenantId tenantId, string name, string email)
        {
            this.id = id;
            this.tenantId = tenantId;
            this.name = name;
            this.email = email;
        }

    }
}
