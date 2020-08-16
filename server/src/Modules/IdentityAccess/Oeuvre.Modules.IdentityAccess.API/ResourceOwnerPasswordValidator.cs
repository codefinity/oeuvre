using IdentityServer4.Models;
using IdentityServer4.Validation;
using Oeuvre.Modules.IdentityAccess.Application.Authentication.Authenticate;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.API
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IIdentityAccessModule identityAccessModule;

        public ResourceOwnerPasswordValidator(IIdentityAccessModule identityAccessModule)
        {
            this.identityAccessModule = identityAccessModule;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var authenticationResult = await identityAccessModule.ExecuteCommandAsync(new AuthenticateCommand(context.UserName, context.Password));
            if (!authenticationResult.IsAuthenticated)
            {
                context.Result = new GrantValidationResult(
                                            TokenRequestErrors.InvalidGrant,
                                            authenticationResult.AuthenticationError);
                return;
            }
            context.Result = new GrantValidationResult(
                authenticationResult.User.Id.ToString(),
                "forms",
                authenticationResult.User.Claims);
        }
    }
}
