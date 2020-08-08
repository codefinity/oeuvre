using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.ConfirmUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.GetUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser;

namespace Oeuvre.Modules.IdentityAccess.API.Controller
{
    [Route("userAccess/[controller]")]
    [ApiController]
    public class UserRegistrationsController : ControllerBase
    {
        private readonly IUserAccessModule userAccessModule;

        public UserRegistrationsController(IUserAccessModule userAccessModule)
        {
            this.userAccessModule = userAccessModule;
        }

        [AllowAnonymous]
        [HttpPost("/identityaccess/register")]
        public async Task<IActionResult> RegisterNewUser(RegisterNewUserRequest request)
        {
            try
            {
                await userAccessModule.ExecuteCommandAsync(new RegisterNewUserCommand(
                                                                        request.TenantId,
                                                                        request.Password,
                                                                        request.EMail,
                                                                        request.FirstName,
                                                                        request.MobileNoCountryCode,
                                                                        request.MobileNumber,
                                                                        request.LastName));
            }
            catch (Exception ex)
            {
                throw;
            }

            return Ok();
        }

        [HttpGet("/identityaccess/registrant/{userRegistrationId}")]
        //[HasPermission(MeetingsPermissions.GetAllMeetingGroups)]
        public async Task<IActionResult> GetAllMeetingGroups(Guid userRegistrationId)
        {
            var registrant = await userAccessModule.ExecuteQueryAsync(new GetUserRegistrationQuery(
                                                                        userRegistrationId));

            return Ok(registrant);

        }

        [AllowAnonymous]
        [HttpPatch("{userRegistrationId}/confirm")]
        public async Task<IActionResult> ConfirmRegistration(Guid userRegistrationId)
        {
            await userAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(userRegistrationId));

            return Ok();
        }
    }
}
