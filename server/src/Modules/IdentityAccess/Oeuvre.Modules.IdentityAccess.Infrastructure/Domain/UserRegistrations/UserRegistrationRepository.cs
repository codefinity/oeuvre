using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.UserRegistrations
{
    public class UserRegistrationRepository : IUserRegistrationRepository
    {
        private readonly IdentityAccessContext identityAccessContext;

        public UserRegistrationRepository(IdentityAccessContext identityAccessContext)
        {
            this.identityAccessContext = identityAccessContext;
        }

        public void Add(Registration userRegistration)
        {
            try
            {
                //string state = identityAccessContext.Entry(userRegistration).State.ToString();
                //Registration ur = await GetByIdAsync(new UserRegistrationId(System.Guid.Parse("f9a11236-5ed7-462c-8fb6-47cfa64d3d5f")));
                //ur.Confirm();
                //string state2 = identityAccessContext.Entry(ur).State.ToString();
                //identityAccessContext.Entry(userRegistration).State = EntityState.Unchanged;

                 identityAccessContext.Add(userRegistration);

                 identityAccessContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task AddAsync(Registration userRegistration)
        {
            try
            {
                //string state = identityAccessContext.Entry(userRegistration).State.ToString();
                //Registration ur = await GetByIdAsync(new UserRegistrationId(System.Guid.Parse("f9a11236-5ed7-462c-8fb6-47cfa64d3d5f")));
                //ur.Confirm();
                //string state2 = identityAccessContext.Entry(ur).State.ToString();
                //identityAccessContext.Entry(userRegistration).State = EntityState.Unchanged;

                await identityAccessContext.AddAsync(userRegistration);

                await identityAccessContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task UpdateAsync(Registration userRegistration)
        {
            try
            {
                await identityAccessContext.AddAsync(userRegistration);

                identityAccessContext.Entry(userRegistration).State = EntityState.Modified;

                await identityAccessContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }


        public async Task<Registration> GetByIdAsync(UserRegistrationId userRegistrationId)
        {
                        
            return await identityAccessContext.UserRegistrations.FirstOrDefaultAsync(x => x.Id == userRegistrationId);

        }
    }
}