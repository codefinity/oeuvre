using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.UserRegistrations
{
    public class UserRegistrationRepository : IUserRegistrationRepository
    {
        private readonly IdentityAccessContext userAccessContext;

        public UserRegistrationRepository(IdentityAccessContext userAccessContext)
        {
            this.userAccessContext = userAccessContext;
        }

        public async Task AddAsync(Registration userRegistration)
        {
            await userAccessContext.AddAsync(userRegistration);
            userAccessContext.SaveChanges();
        }

        public async Task<Registration> GetByIdAsync(UserRegistrationId userRegistrationId)
        {
            return await userAccessContext.UserRegistrations.FirstOrDefaultAsync(x => x.Id == userRegistrationId);
        }
    }
}