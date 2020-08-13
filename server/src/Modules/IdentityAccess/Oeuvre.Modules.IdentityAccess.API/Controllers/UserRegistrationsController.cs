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
    [Route("identityaccess/[controller]")]
    [ApiController]
    public class UserRegistrationsController : ControllerBase
    {
        private readonly IIdentityAccessModule userAccessModule;

        public UserRegistrationsController(IIdentityAccessModule userAccessModule)
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

        [HttpGet("/identityaccess/registrants")]
        //[HasPermission(MeetingsPermissions.GetAllMeetingGroups)]
        public async Task<IActionResult> GetAllRegisteredUsers()
        {
            var registrantsList = await userAccessModule.ExecuteQueryAsync(new GetAllUserRegistrationQuery());

            return Ok(registrantsList);
        }

        [HttpGet("/identityaccess/registrant/{registrantId}")]
        //[HasPermission(MeetingsPermissions.GetMeetingGroupProposals)]
        public async Task<IActionResult> GetARegisteredUser(Guid registrantId)
        {
            var registrant = await userAccessModule.ExecuteQueryAsync(new GetUserRegistrationQuery(registrantId));

            return Ok(registrant);
        }


        [AllowAnonymous]
        [HttpPatch("/identityaccess/{registrantId}/confirm")]
        public async Task<IActionResult> ConfirmRegistration(Guid registrantId)
        {
            await userAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrantId));

            return Ok();
        }
    }
}
