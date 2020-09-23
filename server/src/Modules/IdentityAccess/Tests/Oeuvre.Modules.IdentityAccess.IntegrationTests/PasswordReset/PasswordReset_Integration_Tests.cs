using Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.GetPasswordResetRequests;
using Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.InitiatePasswordReset;
using Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.RequestPassswordReset;
using Oeuvre.Modules.IdentityAccess.Application.PasswordResetRequests.SendNewPassword;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.ConfirmUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser;
using Oeuvre.Modules.IdentityAccess.Domain;
using Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Rules;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.PasswordReset
{
    //#FRP
    [Collection("IdentityAcessIntegrationTestCollection")]
    public class PasswordReset_Integration_Tests : TestBase
    {
        //#FRP-S1
        [Fact]
        public async void GIVEN_IHaveThePasswordResetLink_WHEN_IProvideANewPasword_THEN_MyPasswordShouldBeResetToNewPassword()
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

            var newPassword = "newpassword";

            //Given
            RegisterNewUserCommand registerNewUserCommand = new RegisterNewUserCommand(
                                                                userData.TenentId,
                                                                userData.FirstName,
                                                                userData.LastName,
                                                                userData.Password,
                                                                userData.CountryCode,
                                                                userData.MobileNo,
                                                                userData.EMail);


            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);

            await IdentityAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrationId));

            var resetRequestId = await IdentityAccessModule.ExecuteCommandAsync(
                                        new ResetPasswordRequestCommand(registerNewUserCommand.Email));

            
            //When
            var resetRequestIdUnderInitiate = await IdentityAccessModule.ExecuteCommandAsync(
                            new InitiatePasswordResetCommand(resetRequestId));


            var resetRequestIdUnderSendPassword = await IdentityAccessModule.ExecuteCommandAsync(
                            new SendNewPasswordCommand(resetRequestId, newPassword));


            //Then
            var passwordResetRequestQuery = await IdentityAccessModule.ExecuteQueryAsync(new GetPasswordResetRequestQuery(resetRequestId));

            Assert.Equal(resetRequestId, passwordResetRequestQuery.Id);
            Assert.Equal(userData.EMail, passwordResetRequestQuery.EMail);
            Assert.Equal(resetRequestIdUnderInitiate, passwordResetRequestQuery.Id);
            Assert.Equal(resetRequestIdUnderSendPassword, passwordResetRequestQuery.Id);
        }

        //#FRP-S2
        [Fact]
        public async void GIVEN_IHaveThePasswordResetLinkANDTheLinkHasExpired_WHEN_IProvideANewPasword_THEN_MyPasswordShouldNOTBeResetToNewPassword()
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
                                                                userData.EMail);


            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);

            await IdentityAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrationId));

            var resetRequestId = await IdentityAccessModule.ExecuteCommandAsync(
                                        new ResetPasswordRequestCommand(registerNewUserCommand.Email));


            SystemClock.Set(DateTime.Now.AddDays(2).AddMinutes(1));

            //When
            var exception = await Record.ExceptionAsync(() =>
                                    IdentityAccessModule.ExecuteCommandAsync(
                                    new InitiatePasswordResetCommand(resetRequestId)));


            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<PasswordCannotBeResetAfterRequestExpirationRule>(exc.BrokenRule);
            Assert.IsType<BusinessRuleValidationException>(exception);


        }

        //#FRP-S3
        [Fact]
        public async void GIVEN_IHaveThePasswordResetLinkANDIHaveAlreadyResetThePasswordUsingTheLink_WHEN_IProvideANewPasword_THEN_MyPasswordShouldNOTBeResetToNewPassword()
        {
            var userData = new
            {
                TenentId = "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                FirstName = "FN",
                LastName = "LN",
                Password = "pass",
                CountryCode = "+1",
                MobileNo = "1234567",
                EMail = "e4@mail.com"
            };

            var newPassword = "newpassword";

            //Given
            RegisterNewUserCommand registerNewUserCommand = new RegisterNewUserCommand(
                                                                userData.TenentId,
                                                                userData.FirstName,
                                                                userData.LastName,
                                                                userData.Password,
                                                                userData.CountryCode,
                                                                userData.MobileNo,
                                                                userData.EMail);


            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);

            await IdentityAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrationId));

            var resetRequestId = await IdentityAccessModule.ExecuteCommandAsync(
                                        new ResetPasswordRequestCommand(registerNewUserCommand.Email));


            var resetRequestIdUnderInitiate = await IdentityAccessModule.ExecuteCommandAsync(
                            new InitiatePasswordResetCommand(resetRequestId));


            var resetRequestIdUnderSendPassword = await IdentityAccessModule.ExecuteCommandAsync(
                            new SendNewPasswordCommand(resetRequestId, newPassword));


            //When
            var exception = await Record.ExceptionAsync(() =>
                                    IdentityAccessModule.ExecuteCommandAsync(
                                        new InitiatePasswordResetCommand(resetRequestId)));


            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<PasswordCannotBeResetMoreThanOnceRule>(exc.BrokenRule);
            Assert.IsType<BusinessRuleValidationException>(exception);

        }
    }
}
