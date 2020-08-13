using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Domain.Users
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
    }
}
