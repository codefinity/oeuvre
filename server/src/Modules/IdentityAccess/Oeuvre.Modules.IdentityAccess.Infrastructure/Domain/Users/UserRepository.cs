using Microsoft.EntityFrameworkCore;
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
            //string state = identityAccessContext.Entry(user).State.ToString();

            await identityAccessContext.Users.AddAsync(user);

            try
            {
                //string state1 = identityAccessContext.Entry(user).State.ToString();
                //identityAccessContext.Entry(user).State = EntityState.Modified;
                string state2 = identityAccessContext.Entry(user).State.ToString();

                identityAccessContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task UpdateAsync(User user)
        {
            await identityAccessContext.Users.AddAsync(user);

            try
            {
                identityAccessContext.Entry(user).State = EntityState.Modified;

                //identityAccessContext.Entry(user);
                //identityAccessContext.

                identityAccessContext.SaveChanges();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        public async Task<User> GetByIdAsync(UserId userId)
        {

            return await identityAccessContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

        }
    }
}