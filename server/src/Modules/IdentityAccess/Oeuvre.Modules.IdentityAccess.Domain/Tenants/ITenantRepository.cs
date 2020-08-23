using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Domain.Tenants
{
    public interface ITenantRepository
    {
        Task AddAsync(Tenant tenant);

        Task UpdateAsync(Tenant tenant);

        Task<Tenant> GetByIdAsync(TenantId tenantId);
    }
}
