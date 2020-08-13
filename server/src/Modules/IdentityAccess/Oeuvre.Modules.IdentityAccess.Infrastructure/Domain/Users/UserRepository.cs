using Oeuvre.Modules.IdentityAccess.Domain.Users;
using Oeuvre.Modules.IdentityAccess.Infrastructure;
using System;
using System.Threading.Tasks;

namespace CompanyName.MyMeetings.Modules.UserAccess.Infrastructure.Domain.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityAccessContext identityAccessContext;

        public UserRepository(IdentityAccessContext identityAccessContext)
        {
            this.identityAccessContext = identityAccessContext;
        }

        public async Task AddAsync(User user)
        {
            await identityAccessContext.Users.AddAsync(user);

            //identityAccessContext.Users.up

            try
            {
                identityAccessContext.SaveChanges();
            }
            catch(Exception ex)
            {
                int x = 1 + 1;
            }
        }
    }
}