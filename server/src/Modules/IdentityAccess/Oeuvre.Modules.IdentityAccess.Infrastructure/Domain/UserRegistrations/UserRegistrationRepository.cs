using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.UserRegistrations
{
    public class UserRegistrationRepository : IUserRegistrationRepository
    {
        private readonly UserAccessContext userAccessContext;

        public UserRegistrationRepository(UserAccessContext userAccessContext)
        {
            this.userAccessContext = userAccessContext;
        }

        public async Task AddAsync(Registration userRegistration)
        {
            await userAccessContext.AddAsync(userRegistration);
            userAccessContext.SaveChanges();
        }

        public async Task<Registration> GetByIdAsync(long userRegistrationId)
        {
            return await userAccessContext.UserRegistrations.FirstOrDefaultAsync(x => x.Id == userRegistrationId);

            //throw new NotImplementedException();
        }
    }
}