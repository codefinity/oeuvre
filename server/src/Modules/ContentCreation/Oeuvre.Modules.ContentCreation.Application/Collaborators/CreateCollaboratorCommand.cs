using Domaina.CQRS.Command;
using Oeuvre.Modules.ContentCreation.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.ContentCreation.Application.Collaborators
{
    public class CreateCollaboratorCommand : InternalCommandBase
    {
        public CreateCollaboratorCommand(
                        Guid id,
                        Guid collabaratorId,
                        Guid tenantId,
                        string name,
                        string email)
                        : base(id)
        {
            CollabaratorId = collabaratorId;
            TenantId = tenantId;
            Name = name;
            EMail = email;
        }

        internal Guid CollabaratorId { get; }
        internal Guid TenantId { get; }
        internal string Name { get; }
        internal string EMail { get; }

    }
}
