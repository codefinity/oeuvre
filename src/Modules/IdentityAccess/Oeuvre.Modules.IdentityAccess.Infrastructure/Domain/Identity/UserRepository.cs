using System;
using System.Threading.Tasks;
using Oeuvre.Modules.IdentityAccess.Domain.Identity;

namespace Oeuvre.Modules.IdentityAccess.Infrastructure.Domain.Identity
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
            }
        }

}
