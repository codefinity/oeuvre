using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations
{

    public interface IUserRegistrationRepository
    {
        void Add(Registration userRegistration);
        Task AddAsync(Registration userRegistration);
        Task<Registration> GetByIdAsync(UserRegistrationId userRegistrationId);
    }

}