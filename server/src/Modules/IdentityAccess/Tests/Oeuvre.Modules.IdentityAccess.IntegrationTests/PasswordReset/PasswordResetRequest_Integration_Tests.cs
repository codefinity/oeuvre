using Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequest.SendPasswordResetRequest;
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
    public class PasswordResetRequest_Integration_Tests
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
            ResetPasswordRequestCommand passwordResetRequestCommand = new ResetPasswordRequestCommand("email@mail.com");



            //await IdentityAccessModule.ExecuteCommandAsync(passwordResetRequestCommand);



        }


        [Fact]
        public async void GIVEN_UserRequestsForPasswordReset_WHEN_UserRrovidesWrongEMailId_UserShouldNOTGetAPasswordResetEMail()
        {




        }

    }
}
