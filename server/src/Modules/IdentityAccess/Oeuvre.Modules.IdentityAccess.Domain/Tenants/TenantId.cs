using Domania.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.Domain.Tenants
{
    public class TenantId : TypedIdValueBase
    {
        public TenantId(Guid value) : base(value)
        {
        }
    }
}
