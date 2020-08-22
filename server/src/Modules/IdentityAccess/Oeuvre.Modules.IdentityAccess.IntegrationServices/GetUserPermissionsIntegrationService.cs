using Domania.IntegrationServices;
using Oeuvre.Modules.IdentityAccess.Application.Authorization.GetUserPermissions;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration;
using Autofac;

namespace Oeuvre.Modules.IdentityAccess.IntegrationServices
{
    public class GetUserPermissionsIntegrationService : IIntegrationService
    {
        public async Task<List<GetUserPermissionIntegrationDto>> GetPermissions(Guid userId)
        {

            using (var scope = IdentityAccessCompositionRoot.BeginLifetimeScope())
            {
                var identityAccessModule = scope.Resolve<IIdentityAccessModule>();

                var permissions = await identityAccessModule
                                        .ExecuteQueryAsync(new GetUserPermissionsQuery(userId));

                List<GetUserPermissionIntegrationDto> permissionsDto = new List<GetUserPermissionIntegrationDto>();

                foreach (UserPermissionDto dto in permissions)
                {
                    permissionsDto.Add(new GetUserPermissionIntegrationDto() { Code = dto.Code });

                }


                return permissionsDto;

            }

        }

    }
}
