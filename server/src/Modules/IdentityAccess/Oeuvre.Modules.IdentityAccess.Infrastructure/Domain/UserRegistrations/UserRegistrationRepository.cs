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

        public async Task AddAsync(Registration userRegistration)
        {

            try
            {
                //identityAccessContext.Entry(userRegistration).State = EntityState.Unchanged;

                await identityAccessContext.AddAsync(userRegistration);


                await identityAccessContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                int x = 1 + 5;
            }
        }


        public async Task<Registration> GetByIdAsync(UserRegistrationId userRegistrationId)
        {
                        
            return await identityAccessContext.UserRegistrations.FirstOrDefaultAsync(x => x.Id == userRegistrationId);

        }
    }
}