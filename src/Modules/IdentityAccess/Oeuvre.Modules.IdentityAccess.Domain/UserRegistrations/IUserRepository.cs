using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{
    public interface IUserRegistrationRepository
    {
        Task AddAsync(UserRegistrations.UserRegistration userRegistration);

        Task<UserRegistrations.UserRegistration> GetByIdAsync(UserRegistrationId userRegistrationId);
    }
}