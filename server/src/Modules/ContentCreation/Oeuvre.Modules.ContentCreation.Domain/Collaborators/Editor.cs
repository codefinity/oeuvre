using System;
using System.Collections.Generic;
using System.Text;
using Oeuvre.Modules.ContentCreation.Domain.Tenants;


namespace Oeuvre.Modules.ContentCreation.Domain.Collaborators
{
    public class Editor : Collaborator
    {

        public Editor(CollaboratorId id, TenantId tenantId, string name, string email) : base(id, tenantId, name, email)
        {

        }

    }
}
