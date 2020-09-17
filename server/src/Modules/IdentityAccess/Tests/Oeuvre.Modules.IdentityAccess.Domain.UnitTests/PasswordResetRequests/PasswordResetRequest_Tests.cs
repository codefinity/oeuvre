using Domania.Domain;
using Moq;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Events;
using Oeuvre.Modules.IdentityAccess.Domain.UnitTests.SeedWork;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Domain.Users;
using Oeuvre.Modules.IdentityAccess.Domain.Users.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.PasswordResetRequests
{
    //#FFPR
    public class PasswordResetRequest_Tests : TestBase
    {

        //#FFPR-S1
        [Fact]
        public void GIVEN_ValidEMailIdANDActiveUser_WHEN_PasswordRestsRequested_THEN_ForgotPasswordRequestShouldBeCreated()
        {
            //Given
            var usersCounter = new Mock<IUsersCounter>().Object;

            var registrationExpirationCalculator = new Mock<IUserRegistrationConfirmationExpirationCalculator>();

            var userFinder = new Mock<IUserFinder>();

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

            userFinder.Setup(e => e.FindUser(It.IsAny<string>()))
                                                .Returns(1);

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
            var passwordResetRequest = user.RequestPasswordReset(registerNewUserData.emailId, 
                                                                    userFinder.Object);

            var passwordResetRequestedDomainEvent = AssertPublishedDomainEvent<PasswordResetRequested>(passwordResetRequest);


            //Then
            Assert.Equal(passwordResetRequestedDomainEvent.UserId, user.Id);
            Assert.Equal(PasswordRequestStatus.ResetPending, passwordResetRequest.GetProperty("status"));

        }


        //#FFPR-S2
        [Fact]
        public void GIVEN_ValidEMailIdANDInActiveUser_WHEN_PasswordRestsRequested_THEN_ForgotPasswordRequestShouldNOTBeCreated()
        {
            //Given
            var usersCounter = new Mock<IUsersCounter>().Object;

            var registrationExpirationCalculator = new Mock<IUserRegistrationConfirmationExpirationCalculator>();

            var userFinder = new Mock<IUserFinder>();

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

            userFinder.Setup(e => e.FindUser(It.IsAny<string>()))
                                                .Returns(1);

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

            user.DeActivate();

            //When

            PasswordResetRequest passwordResetRequest = null;

            var exception = Record.Exception(() => passwordResetRequest = user.RequestPasswordReset(registerNewUserData.emailId,
                                                                    userFinder.Object));


            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;


            //Then
            //CheckBusinessRule Violations
            Assert.Null(passwordResetRequest); //This also means that no domain events were raised
            Assert.IsType<UserMustBeActiveRule>(exc.BrokenRule);
            Assert.IsType<BusinessRuleValidationException>(exception);

        }

        //#FFPR-S3
        [Fact]
        public void GIVEN_InValidEMailIdANDActiveUser_WHEN_PasswordRestsRequested_THEN_ForgotPasswordRequestShouldNOTBeCreated()
        {
            //Given
            var usersCounter = new Mock<IUsersCounter>().Object;

            var registrationExpirationCalculator = new Mock<IUserRegistrationConfirmationExpirationCalculator>();

            var userFinder = new Mock<IUserFinder>();

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

            userFinder.Setup(e => e.FindUser(It.IsAny<string>()))
                                                .Returns(0);

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

            PasswordResetRequest passwordResetRequest = null;

            var exception = Record.Exception(() => passwordResetRequest = user.RequestPasswordReset(registerNewUserData.emailId,
                                                                    userFinder.Object));



            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            //CheckBusinessRule Violations
            Assert.Null(passwordResetRequest); //This also means that no domain events were raised
            Assert.IsType<UserLoginEMailIdMustExistRule>(exc.BrokenRule);
            Assert.IsType<BusinessRuleValidationException>(exception);

        }

        //#FFPR-S4
        [Fact]
        public void GIVEN_InValidEMailIdANDInActiveUser_WHEN_PasswordRestsRequested_THEN_ForgotPasswordRequestShouldNOTBeCreated()
        {
            //Given
            var usersCounter = new Mock<IUsersCounter>().Object;

            var registrationExpirationCalculator = new Mock<IUserRegistrationConfirmationExpirationCalculator>();

            var userFinder = new Mock<IUserFinder>();

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

            userFinder.Setup(e => e.FindUser(It.IsAny<string>()))
                                                .Returns(0);

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

            user.DeActivate();

            //When

            PasswordResetRequest passwordResetRequest = null;

            var exception = Record.Exception(() => passwordResetRequest = user.RequestPasswordReset(registerNewUserData.emailId,
                                                                    userFinder.Object));



            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            //CheckBusinessRule Violations
            Assert.Null(passwordResetRequest); //This also means that no domain events were raised
            Assert.IsType<UserLoginEMailIdMustExistRule>(exc.BrokenRule);
            Assert.IsType<BusinessRuleValidationException>(exception);

        }

    }
}
