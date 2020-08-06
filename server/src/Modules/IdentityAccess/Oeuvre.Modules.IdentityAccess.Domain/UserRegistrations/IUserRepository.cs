using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public interface IUserRegistrationRepository
    {
        Task AddAsync(Registration userRegistration);

        Task<Registration> GetByIdAsync(long userRegistrationId);
    }
}