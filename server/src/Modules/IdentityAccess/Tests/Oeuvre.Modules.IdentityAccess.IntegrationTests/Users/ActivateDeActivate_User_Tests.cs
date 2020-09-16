using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.ConfirmUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.GetUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser;
using Oeuvre.Modules.IdentityAccess.Application.Users.DeactivateUser;
using Oeuvre.Modules.IdentityAccess.Application.Users.GetUser;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Rules;
using Oeuvre.Modules.IdentityAccess.Infrastructure;
using Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.Users
{
    [Collection("IdentityAcessIntegrationTestCollection")]
    public class ActivateDeActivate_User_Tests : TestBase
    {
        private IdentityAcessIntegrationTestFixture fixture;

        public ActivateDeActivate_User_Tests(IdentityAcessIntegrationTestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async void GIVEN_UserIsActiveted_WHEN_UserIsDeActivated_THEN_UserShouldBeDeActivated()
        {
            //Given
            RegisterNewUserCommand registerNewUserCommand = new RegisterNewUserCommand(
                                                                "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                                                                "FN",
                                                                "LN",
                                                                "pass",
                                                                "+1",
                                                                "1234567",
                                                                "e2@mail.com");


            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);

            await IdentityAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrationId));


            //When
            await IdentityAccessModule.ExecuteCommandAsync(new DeActivateUserCommand(registrationId));

            //Then
            var userQuery = await IdentityAccessModule.ExecuteQueryAsync(new GetUserQuery(registrationId));

            Assert.False(userQuery.IsActive);

        }


        [Fact]
        public async void GIVEN_UserIsDeActiveted_WHEN_UserIsActivated_THEN_UserShouldBeActivated()
        {
            //Given
            RegisterNewUserCommand registerNewUserCommand = new RegisterNewUserCommand(
                                                                "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                                                                "FN",
                                                                "LN",
                                                                "pass",
                                                                "+1",
                                                                "1234567",
                                                                "e3@mail.com");


            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);

            await IdentityAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrationId));
            
            await IdentityAccessModule.ExecuteCommandAsync(new DeActivateUserCommand(registrationId));

            //When
            await IdentityAccessModule.ExecuteCommandAsync(new ActivateUserCommand(registrationId));

            //Then
            var userQuery = await IdentityAccessModule.ExecuteQueryAsync(new GetUserQuery(registrationId));

            Assert.True(userQuery.IsActive);

        }

    }
}
