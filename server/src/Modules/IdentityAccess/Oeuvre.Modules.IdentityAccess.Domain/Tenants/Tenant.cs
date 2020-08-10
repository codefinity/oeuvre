using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.Tenants
{
    internal class Tenant : Entity, IAggregateRoot
    {
        public TenantId Id { get; private set; }

        private string Name;

        private Tenant()
        {

        }
  
    }
}
