using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public interface IUserRegistrationRepository
    {
        Task AddAsync(UserRegistration userRegistration);

        Task<UserRegistrations.UserRegistration> GetByIdAsync(long userRegistrationId);
    }
}