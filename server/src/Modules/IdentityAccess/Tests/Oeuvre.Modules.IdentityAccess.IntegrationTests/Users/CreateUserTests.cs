using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.ConfirmUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser;
using Oeuvre.Modules.IdentityAccess.Application.Users.CreateUser;
using Oeuvre.Modules.IdentityAccess.Application.Users.GetUser;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.Users
{
    [Collection("IdentityAccessIntegrationTestCollection")]
    public class CreateUserTests : TestBase
    {
        [Fact]
        public async Task CreateUser_Test()
        {

            RegisterNewUserCommand registerNewUserCommand = new RegisterNewUserCommand(
                                                                    "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                                                                    "FN",
                                                                    "LN",
                                                                    "pass",
                                                                    "+1",
                                                                    "1234567",
                                                                    "e@mail.com");

            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);
            
            await IdentityAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrationId));

            var userId = await IdentityAccessModule.ExecuteCommandAsync(new CreateUserCommand(Guid.NewGuid(), new UserRegistrationId(registrationId)));

            var user = await IdentityAccessModule.ExecuteQueryAsync(new GetUserQuery(userId));

            Assert.Equal(registerNewUserCommand.Email, user.EMail);
        }
    }
}