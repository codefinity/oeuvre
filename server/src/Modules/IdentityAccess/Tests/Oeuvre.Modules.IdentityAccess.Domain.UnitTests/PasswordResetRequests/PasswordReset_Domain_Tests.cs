using Domania.Domain;
using Moq;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Events;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Rules;
using Oeuvre.Modules.IdentityAccess.Domain.UnitTests.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.PasswordResetRequests
{
    //#FRP
    public class PasswordReset_Domain_Tests : TestBase
    {
        //#FRP-S1
        [Fact]
        public void GIVEN_MyPasswordRequestHasNotExpired_WHEN_ISendMyPassword_THEN_MyPasswordShouldBeReset()
        {
            //Given
            var userFinder = new Mock<IUserFinder>();
            var email = "valid@email.com";
            var userEmailExists = true;
            var userActive = true;
            var newPassword = "newpassword";

            var expirationCalculator = new Mock<IPasswordResetExpirationCalculator>();

            DateTime registrationDate = DateTime.Now;

            expirationCalculator.Setup(e => e.Calculate(It.IsAny<DateTime>()))
                                                .Returns(registrationDate.AddDays(1));

            userFinder.Setup(e => e.FindUser(email))
                                    .Returns((userEmailExists, userActive));

            var passwordResetRequest = PasswordResetRequest.RequestPasswordReset(email, userFinder.Object);

            passwordResetRequest.InitiatePasswordReset(expirationCalculator.Object);

            //When
            passwordResetRequest.SendNewPassword(newPassword, expirationCalculator.Object, userFinder.Object);

            var passwordReceivedDomainEvent = AssertPublishedDomainEvent<NewPasswordReceivedDomainEvent>(passwordResetRequest);

            //Then
            Assert.Equal(passwordReceivedDomainEvent.NewPassword, newPassword);
            Assert.Equal(PasswordRequestStatus.NewPasswordReceived, passwordResetRequest.GetProperty("status"));

        }

        //#FRP-S2
        [Fact]
        public void GIVEN_MyPasswordRequestHasExpired_WHEN_IInitiateThePasswordReset_THEN_IShouldNotBeAllowedToResetThePassword()
        {
            //Given
            var userFinder = new Mock<IUserFinder>();
            var email = "valid@email.com";
            var userEmailExists = true;
            var userActive = true;

            var expirationCalculator = new Mock<IPasswordResetExpirationCalculator>();

            DateTime registrationDate = DateTime.Now;

            expirationCalculator.Setup(e => e.Calculate(It.IsAny<DateTime>()))
                                                .Returns(registrationDate.AddDays(1));

            userFinder.Setup(e => e.FindUser(email))
                                    .Returns((userEmailExists, userActive));

            var passwordResetRequest = PasswordResetRequest.RequestPasswordReset(email, userFinder.Object);


            //When
            var exception = Record.Exception(() => passwordResetRequest.InitiatePasswordReset(expirationCalculator.Object));

            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<PasswordCannotBeResetAfterRequestExpirationRule>(exc.BrokenRule);

        }

        //#FRP-S3
        [Fact]
        public void GIVEN_IHaveAlreadyUserTheRequestToResetMyPassword_WHEN_IInitiateThePasswordReset_THEN_IShouldNotBeAllowedToResetThePassword()
        {
            //Given
            var userFinder = new Mock<IUserFinder>();
            var email = "valid@email.com";
            var userEmailExists = true;
            var userActive = true;

            var expirationCalculator = new Mock<IPasswordResetExpirationCalculator>();

            DateTime registrationDate = DateTime.Now;

            expirationCalculator.Setup(e => e.Calculate(It.IsAny<DateTime>()))
                                                .Returns(registrationDate.AddDays(1));

            userFinder.Setup(e => e.FindUser(email))
                                    .Returns((userEmailExists, userActive));

            var passwordResetRequest = PasswordResetRequest.RequestPasswordReset(email, userFinder.Object);


            //When
            var exception = Record.Exception(() => passwordResetRequest.InitiatePasswordReset(expirationCalculator.Object));

            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<PasswordCannotBeResetMoreThanOnceRule>(exc.BrokenRule);

        }
    }
}
