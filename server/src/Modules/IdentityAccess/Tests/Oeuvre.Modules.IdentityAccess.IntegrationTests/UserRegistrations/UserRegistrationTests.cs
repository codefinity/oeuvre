using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.GetUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser;
using Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.UserRegistrations
{
    [Collection("IdentityAccessIntegrationTestCollection")]
    public class UserRegistrationTests : TestBase
    {
        [Fact]
        public async Task RegisterNewUserCommand_Test()
        {
            RegisterNewUserCommand registerNewUserCommand = new RegisterNewUserCommand(
                                                    "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                                                    "Bono",
                                                    "Hewson",
                                                    "withorwithoutyou",
                                                    "+1",
                                                    "1294561062",
                                                    "Bono@U2.com");


            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);

            var userRegistration = await IdentityAccessModule.ExecuteQueryAsync(new GetUserRegistrationQuery(registrationId));

            Assert.Equal(userRegistration.Email, registerNewUserCommand.Email);
            Assert.Equal(userRegistration.FirstName, registerNewUserCommand.FirstName);
            Assert.Equal(userRegistration.LastName, registerNewUserCommand.LastName);
            Assert.Equal(userRegistration.CountryCode, registerNewUserCommand.MobileNoCountryCode);
            Assert.Equal(userRegistration.MobileNo, registerNewUserCommand.MobileNumber);
            //Assert.Equals(userRegistration.TenantId, registerNewUserCommand.TenantId);

        }
    }
}