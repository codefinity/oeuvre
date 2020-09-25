using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domaina.Application;
using Domania.Security.Authorization;
using Microsoft.AspNetCore.Authorization;
using Oeuvre.Modules.IdentityAccess.Application.Authorization.GetUserPermissions;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;

namespace Oeuvre.Modules.IdentityAccess.Application.Authorization
{
    public class HasPermissionAuthorizationHandler : AttributeAuthorizationHandler<HasPermissionAuthorizationRequirement, HasPermissionAttribute>
    {
        private readonly IIdentityAccessModule identityAccessModule;
        private readonly IExecutionContextAccessor executionContextAccessor;
        public HasPermissionAuthorizationHandler(
            IExecutionContextAccessor executionContextAccessor,
            IIdentityAccessModule identityAccessModule)
        {
            this.executionContextAccessor = executionContextAccessor;
            this.identityAccessModule = identityAccessModule;
        }

        protected override async Task HandleRequirementAsync(
                                        AuthorizationHandlerContext context,
                                        HasPermissionAuthorizationRequirement requirement,
                                        HasPermissionAttribute attribute)
        {

            
            if (executionContextAccessor.UserId == Guid.Empty)
            {
                context.Fail();
                return;
            }

            var permissions = await identityAccessModule
                                        .ExecuteQueryAsync(new GetUserPermissionsQuery(executionContextAccessor.UserId));

            if (!await AuthorizeAsync(attribute.Name, permissions))
            {
                context.Fail();
                return;
            }

            context.Succeed(requirement);
        }

        private Task<bool> AuthorizeAsync(string permission, List<UserPermissionDto> permissions)
        {
            //#if !DEBUG
            //return Task.FromResult(true);
            //#endif

            if (permissions.Any(x => x.Code == permission))
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}