using Domania.Domain;
using Oeuvre.Modules.ContentCreation.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Domain.Collaborators
{
    public class Collaborator : Entity
    {
        public CollaboratorId Id { get; private set; }

        private TenantId tenantId;

        private string name;

        private string email;

        private DateTime createdDate;

        private Collaborator()
        {
            // Only for EF.
        }

        public Collaborator(Guid id, Guid tenantId, string name, string email)
        {
            this.Id = new CollaboratorId(id);
            this.tenantId = new TenantId(tenantId);
            this.name = name;
            this.email = email;
            this.createdDate = DateTime.Now;
        }

        public static Collaborator Create(Guid id, Guid tenantId, string name, string email)
        {
            return new Collaborator(id, tenantId, name, email);
        }


    }
}
