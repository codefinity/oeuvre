using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oeuvre.Modules.IdentityAccess.API.Configuration.Authorization;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.ConfirmUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.GetUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser;
using Oeuvre.Modules.IdentityAccess.Application.Users.AddRole;
using Oeuvre.Modules.IdentityAccess.Application.Users.DeactivateUser;

namespace Oeuvre.Modules.IdentityAccess.API.Controller
{
    [Route("identityaccess/[controller]")]
    [ApiController]
    public class UserRegistrationsController : ControllerBase
    {
        private readonly IIdentityAccessModule userAccessModule;

        public UserRegistrationsController(IIdentityAccessModule userAccessModule)
        {
            this.userAccessModule = userAccessModule;
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPost("/identityaccess/register")]
        public async Task<IActionResult> RegisterNewUser(RegisterNewUserRequest request)
        {
            try
            {
                await userAccessModule.ExecuteCommandAsync(new RegisterNewUserCommand(
                                                                        request.TenantId,
                                                                        request.FirstName,
                                                                        request.LastName,
                                                                        request.Password,
                                                                        request.MobileNoCountryCode,
                                                                        request.MobileNumber,
                                                                        request.EMail));
            }
            catch (Exception ex)
            {
                throw;
            }

            return Ok();
        }

        [NoPermissionRequired]
        [AllowAnonymous]
        [HttpPatch("/identityaccess/{registrantId}/confirm")]
        public async Task<IActionResult> ConfirmRegistration(Guid registrantId)
        {
            await userAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrantId));

            return Ok();
        }

        [HttpGet("/identityaccess/registrants")]
        [HasPermission(IdentityAccessPermissions.GetRegistrants)]
        [Authorize]
        public async Task<IActionResult> GetAllRegisteredUsers()
        {
            var registrantsList = await userAccessModule.ExecuteQueryAsync(new GetAllUserRegistrationQuery());

            return Ok(registrantsList);
        }

        [HttpGet("/identityaccess/registrant/{registrantId}")]
        [HasPermission(IdentityAccessPermissions.GetRegistrants)]
        [Authorize]
        public async Task<IActionResult> GetARegisteredUser(Guid registrantId)
        {
            var registrant = await userAccessModule.ExecuteQueryAsync(new GetUserRegistrationQuery(registrantId));

            return Ok(registrant);
        }



        [AllowAnonymous]
        [HttpPatch("/identityaccess/addrole")]
        public async Task<IActionResult> AddRole(Guid userId, string role)
        {
            await userAccessModule.ExecuteCommandAsync(new AddRoleToUserCommand(userId, role));

            return Ok();
        }

        [AllowAnonymous]
        [HttpPatch("/identityaccess/user/deactivate")]
        public async Task<IActionResult> DeactivateUser(Guid userId)
        {
            await userAccessModule.ExecuteCommandAsync(new DeactivateUserCommand(userId));

            return Ok();
        }
    }
}
