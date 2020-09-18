using Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequest.GetPasswordResetRequests;
using Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequest.SendPasswordResetRequest;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.ConfirmUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser;
using Oeuvre.Modules.IdentityAccess.Infrastructure;
using Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.PasswordReset
{
    //#FFPR
    [Collection("IdentityAcessIntegrationTestCollection")]
    public class PasswordResetRequest_Integration_Tests : TestBase
    {
        private IdentityAcessIntegrationTestFixture fixture;

        public PasswordResetRequest_Integration_Tests(IdentityAcessIntegrationTestFixture fixture)
        {
            this.fixture = fixture;
        }

        //#FFPR-S1
        [Fact]
        public async void GIVEN_UserRequestsForPasswordReset_WHEN_UserRrovidesValidEMailId_UserShouldGetAPasswordResetEMail()
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
            ResetPasswordRequestCommand passwordResetRequestCommand = new ResetPasswordRequestCommand(registerNewUserCommand.Email);

            var resetRequestId = await IdentityAccessModule.ExecuteCommandAsync(passwordResetRequestCommand);

            //Then
            var passwordResetRequestQuery = await IdentityAccessModule.ExecuteQueryAsync(new GetPasswordResetRequestQuery(resetRequestId));




            Assert.Equal(resetRequestId, passwordResetRequestQuery.Id);


        }


        [Fact]
        public async void GIVEN_UserRequestsForPasswordReset_WHEN_UserRrovidesWrongEMailId_UserShouldNOTGetAPasswordResetEMail()
        {




        }

    }
}
