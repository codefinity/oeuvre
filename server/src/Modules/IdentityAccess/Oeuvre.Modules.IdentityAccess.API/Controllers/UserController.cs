using Domania.Security.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oeuvre.Modules.IdentityAccess.Application.Authorization;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Application.Users.DeactivateUser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.Modules.IdentityAccess.API.Controllers
{
    [Route("user/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IIdentityAccessModule identityAccessModule;
        private readonly ILogger logger;

        public UserController(IIdentityAccessModule identityAccessModule
                                            , ILogger logger
                                            )
        {
            this.identityAccessModule = identityAccessModule;
            this.logger = logger;
        }

        [HttpPatch("/user/{userId}/activate")]
        [HasPermission(IdentityAccessPermissions.ActivateDeActivateUser)]
        [Authorize]
        public async Task<IActionResult> ActivateUser(Guid userId)
        {
            try
            {
                await identityAccessModule.ExecuteCommandAsync(new ActivateUserCommand(userId));

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPatch("/user/{userId}/deactivate")]
        [HasPermission(IdentityAccessPermissions.ActivateDeActivateUser)]
        [Authorize]
        public async Task<IActionResult> DeActivateUser(Guid userId)
        {
            try
            {
                await identityAccessModule.ExecuteCommandAsync(new DeActivateUserCommand(userId));

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
