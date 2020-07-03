using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistration.RegisterNewUser;
using Oeuvre.Modules.IdentityAccess.Application.CQRS;

namespace Oeuvre.Modules.IdentityAccess.API
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> logger;
        private readonly IUserAccessModule userAccessModule;

        public UserController(IUserAccessModule userAccessModule, ILogger<UserController> logger)
        {
            this.userAccessModule = userAccessModule;
            this.logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult RegisterNewUser(RegisterNewUserRequest request)
        {
            logger.LogInformation("This is the first log");


            Task result = userAccessModule.ExecuteCommandAsync(new RegisterNewUserCommand(request.FirstName,
                                                                                   request.LastName,
                                                                                   request.Email,
                                                                                   request.Password));

            return Ok();
        }



        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };



        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
