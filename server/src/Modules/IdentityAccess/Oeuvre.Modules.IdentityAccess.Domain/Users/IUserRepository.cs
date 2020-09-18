using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Domain.Users
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        Task UpdateAsync(User user);

        Task<User> GetByIdAsync(UserId userId);

        Task<User> GetByEMailIdAsync(string eMailId);
    }
}
