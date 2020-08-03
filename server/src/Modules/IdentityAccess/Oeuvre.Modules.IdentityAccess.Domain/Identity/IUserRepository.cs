using System;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Domain.Identity
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
    }
}
