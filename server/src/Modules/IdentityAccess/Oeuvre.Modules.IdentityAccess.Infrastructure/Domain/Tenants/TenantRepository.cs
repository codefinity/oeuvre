using Microsoft.EntityFrameworkCore;
using Oeuvre.Modules.IdentityAccess.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.Tenants
{
    public class TenantRepository : ITenantRepository
    {
        private readonly IdentityAccessContext identityAccessContext;

        public TenantRepository(IdentityAccessContext identityAccessContext)
        {
            this.identityAccessContext = identityAccessContext;
        }

        public async Task AddAsync(Tenant tenant)
        {
            //string state = identityAccessContext.Entry(user).State.ToString();

            await identityAccessContext.Tenants.AddAsync(tenant);

            try
            {
                //string state1 = identityAccessContext.Entry(user).State.ToString();
                //identityAccessContext.Entry(user).State = EntityState.Modified;
                string state2 = identityAccessContext.Entry(tenant).State.ToString();

                identityAccessContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task UpdateAsync(Tenant tenant)
        {
            await identityAccessContext.Tenants.AddAsync(tenant);

            try
            {
                identityAccessContext.Entry(tenant).State = EntityState.Modified;

                //identityAccessContext.Entry(user);
                //identityAccessContext.

                identityAccessContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task<Tenant> GetByIdAsync(TenantId tenantId)
        {

            return await identityAccessContext.Tenants.FirstOrDefaultAsync(x => x.Id == tenantId);

        }

    }
}
