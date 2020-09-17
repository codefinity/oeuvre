using Moq;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Events;
using Oeuvre.Modules.IdentityAccess.Domain.UnitTests.SeedWork;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.PasswordResetRequest
{
    public class PasswordResetRequest_Tests : TestBase
    {
        [Fact]
        public void GIVEN_ValidEMailId_WHEN_PasswordRestsRequested_THEN_ForgotPasswordRequestShouldBeCreated()
        {
            //Given
            var usersCounter = new Mock<IUsersCounter>().Object;

            var registrationExpirationCalculator = new Mock<IUserRegistrationConfirmationExpirationCalculator>();

            var registerNewUserData = new
            {
                tenantId = new System.Guid("79530f73-8d20-48e7-bc15-c4d2679deb35"),
                firstName = "Manfred",
                lastName = "Mann",
                password = "doWaDiddy",
                mobileNoCountryCode = "+44",
                mobileNumber = "4525856425",
                emailId = "Manfred@ManfredMann.com",
                usersCounter = usersCounter
            };

            DateTime registrationDate = DateTime.Now;
            registrationExpirationCalculator.Setup(e => e.Calculate(It.IsAny<DateTime>()))
                                                .Returns(registrationDate.AddDays(2));

            var registration = Registration.RegisterNewUser(
                                 registerNewUserData.tenantId,
                                 registerNewUserData.firstName,
                                 registerNewUserData.lastName,
                                 registerNewUserData.password,
                                 registerNewUserData.mobileNoCountryCode,
                                 registerNewUserData.mobileNumber,
                                 registerNewUserData.emailId,
                                 registerNewUserData.usersCounter);

            registration.Confirm(registrationExpirationCalculator.Object);

            var user = registration.CreateUser();

            //When
            var passwordResetRequest = user.RequestPasswordReset(registerNewUserData.emailId);

            var passwordResetRequestedDomainEvent = AssertPublishedDomainEvent<PasswordResetRequested>(passwordResetRequest);


            //Then
            Assert.Equal(passwordResetRequestedDomainEvent.UserId, user.Id);
            Assert.Equal(PasswordRequestStatus.ResetPending, passwordResetRequest.GetProperty("status"));

        }


        //[Fact]
        //public void GIVEN_InValidEMailId_WHEN_PasswordRestsRequested_THEN_ForgotPasswordRequestShouldBeNotBeCreated()
        //{


        //}

    }
}
