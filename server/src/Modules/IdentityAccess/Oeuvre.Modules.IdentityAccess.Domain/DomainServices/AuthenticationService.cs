using Oeuvre.Modules.IdentityAccess.Domain.Contracts;
using Oeuvre.Modules.IdentityAccess.Domain.Tenants;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.Domain.DomainServices
{

    //Under Review and Development.
    //Unable to proceed because the repositories do not allow full LINQ queries
    //because entities have private properties.
    public class AuthenticationService
    {

        private EncryptionService encryptionService;
        private ITenantRepository tenantRepository;
        private IUserRepository userRepository;

        public AuthenticationService(
                        EncryptionService encryptionService,
                        ITenantRepository tenantRepository,
                        IUserRepository userRepository)
        {
            this.encryptionService = encryptionService;
            this.tenantRepository = tenantRepository;
            this.userRepository = userRepository;

        }

        public async Task<User> Authenticate(TenantId tenantId, string userName, string password)
        {

            Tenant tenant = await tenantRepository.GetByIdAsync(tenantId);

            //if(tenant != null && tenant.IsActive)
            //{

                String encryptedPassword = encryptionService.encryptedValue(password);

                //User user = userRepository.GetByIdAsync()

            //}

            return null;
        }

    }
}
