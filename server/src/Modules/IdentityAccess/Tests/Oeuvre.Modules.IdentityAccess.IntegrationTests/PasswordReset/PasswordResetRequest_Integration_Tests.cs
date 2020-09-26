using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.GetPasswordResetRequests;
using Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.RequestPassswordReset;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.ConfirmUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser;
using Oeuvre.Modules.IdentityAccess.Application.Users.DeactivateUser;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Rules;
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
        public async void GIVEN_UserRequestsForPasswordReset_WHEN_UserProvidesValidEMailId_UserShouldGetAPasswordResetEMail()
        {

            var userData = new
            {
                TenentId = "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                FirstName = "FN",
                LastName = "LN",
                Password = "pass",
                CountryCode = "+1",
                MobileNo = "1234567",
                EMail = "e2@mail.com"
            };

            //Given
            RegisterNewUserCommand registerNewUserCommand = new RegisterNewUserCommand(
                                                                userData.TenentId,
                                                                userData.FirstName,
                                                                userData.LastName,
                                                                userData.Password,
                                                                userData.CountryCode,
                                                                userData.MobileNo,
                                                                userData.EMail,
                                                                true);


            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);

            await IdentityAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrationId));


            //When
            var resetRequestId = await IdentityAccessModule.ExecuteCommandAsync(
                                        new ResetPasswordRequestCommand(registerNewUserCommand.Email));

            //Then
            var passwordResetRequestQuery = await IdentityAccessModule.ExecuteQueryAsync(new GetPasswordResetRequestQuery(resetRequestId));

            Assert.Equal(resetRequestId, passwordResetRequestQuery.Id);
            Assert.Equal(userData.EMail, passwordResetRequestQuery.EMail);

        }


        //#FFPR-S2
        [Fact]
        public async void GIVEN_UserRequestsForPasswordResetANDIsInActive_WHEN_UserRrovidesCorrectEMailId_UserShouldNOTGetAPasswordResetEMail()
        {
            var userData = new
            {
                TenentId = "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                FirstName = "FN",
                LastName = "LN",
                Password = "pass",
                CountryCode = "+1",
                MobileNo = "1234567",
                EMail = "e3@mail.com"
            };

            //Given
            RegisterNewUserCommand registerNewUserCommand = new RegisterNewUserCommand(
                                                                userData.TenentId,
                                                                userData.FirstName,
                                                                userData.LastName,
                                                                userData.Password,
                                                                userData.CountryCode,
                                                                userData.MobileNo,
                                                                userData.EMail,
                                                                true);


            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);

            await IdentityAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrationId));

            //DeActivate User
            await IdentityAccessModule.ExecuteCommandAsync(new DeActivateUserCommand(registrationId));


            //When
            var exception = await Record.ExceptionAsync(() =>
                                        IdentityAccessModule.ExecuteCommandAsync(
                                            new ResetPasswordRequestCommand(registerNewUserCommand.Email)));

            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<UserMustBeActiveRule>(exc.BrokenRule);
            Assert.IsType<BusinessRuleValidationException>(exception);
        }

        //#FFPR-S3
        [Fact]
        public async void GIVEN_UserRequestsForPasswordReset_WHEN_UserProvidesWrongEMailId_UserShouldGetAPasswordResetEMail()
        {

            var userData = new
            {
                TenentId = "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                FirstName = "FN",
                LastName = "LN",
                Password = "pass",
                CountryCode = "+1",
                MobileNo = "1234567",
                EMail = "e2@mail.com"
            };

            var wrongEmailId = "e3212@mail.com";

            //Given
            RegisterNewUserCommand registerNewUserCommand = new RegisterNewUserCommand(
                                                                userData.TenentId,
                                                                userData.FirstName,
                                                                userData.LastName,
                                                                userData.Password,
                                                                userData.CountryCode,
                                                                userData.MobileNo,
                                                                userData.EMail,
                                                                true);


            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);

            await IdentityAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrationId));

            //When
            var exception = await Record.ExceptionAsync(() =>
                                        IdentityAccessModule.ExecuteCommandAsync(
                                        new ResetPasswordRequestCommand(wrongEmailId)));

            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<UserLoginEMailIdMustExistRule>(exc.BrokenRule);
            Assert.IsType<BusinessRuleValidationException>(exception);
        }


        //#FFPR-S4
        [Fact]
        public async void GIVEN_UserRequestsForPasswordReset_WHEN_UserIsInActiveANDProvidesWrongEMailId_UserShouldGetAPasswordResetEMail()
        {
            var userData = new
            {
                TenentId = "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                FirstName = "FN",
                LastName = "LN",
                Password = "pass",
                CountryCode = "+1",
                MobileNo = "1234567",
                EMail = "e2@mail.com"
            };

            var wrongEmailId = "e3212@mail.com";

            //Given
            RegisterNewUserCommand registerNewUserCommand = new RegisterNewUserCommand(
                                                                userData.TenentId,
                                                                userData.FirstName,
                                                                userData.LastName,
                                                                userData.Password,
                                                                userData.CountryCode,
                                                                userData.MobileNo,
                                                                userData.EMail,
                                                                true);


            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);

            await IdentityAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrationId));

            //DeActivate User
            await IdentityAccessModule.ExecuteCommandAsync(new DeActivateUserCommand(registrationId));

            //When
            var exception = await Record.ExceptionAsync(() =>
                                        IdentityAccessModule.ExecuteCommandAsync(
                                        new ResetPasswordRequestCommand(wrongEmailId)));

            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<UserLoginEMailIdMustExistRule>(exc.BrokenRule);
            Assert.IsType<BusinessRuleValidationException>(exception);
        }
    }

}
