using Microsoft.EntityFrameworkCore;
using Oeuvre.Modules.IdentityAccess.Domain.Tenants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.Tenants
{
    public class PasswordResetRequestsRepository : IPasswordResetRequestRepository
    {
        private readonly IdentityAccessContext identityAccessContext;

        public PasswordResetRequestsRepository(IdentityAccessContext identityAccessContext)
        {
            this.identityAccessContext = identityAccessContext;
        }

        public async Task AddAsync(PasswordResetRequest passwordResetRequest)
        {
            //string state = identityAccessContext.Entry(user).State.ToString();

            await identityAccessContext.PasswordResetRequest.AddAsync(passwordResetRequest);

            try
            {
                //string state1 = identityAccessContext.Entry(user).State.ToString();
                //identityAccessContext.Entry(user).State = EntityState.Modified;
                string state2 = identityAccessContext.Entry(passwordResetRequest).State.ToString();

                identityAccessContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task UpdateAsync(PasswordResetRequest passwordResetRequest)
        {
            await identityAccessContext.PasswordResetRequest.AddAsync(passwordResetRequest);

            try
            {
                identityAccessContext.Entry(passwordResetRequest).State = EntityState.Modified;

                //identityAccessContext.Entry(user);
                //identityAccessContext.

                identityAccessContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task<PasswordResetRequest> GetByIdAsync(PasswordResetRequestId passwordResetRequestId)
        {

            return await identityAccessContext.PasswordResetRequest.FirstOrDefaultAsync(x => x.Id == passwordResetRequestId);

        }

    }
}
