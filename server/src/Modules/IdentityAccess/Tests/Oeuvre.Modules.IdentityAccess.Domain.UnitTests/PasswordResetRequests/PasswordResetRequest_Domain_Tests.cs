using Domania.Domain;
using Moq;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Events;
using Oeuvre.Modules.IdentityAccess.Domain.PasswordResetRequests.Rules;
using Oeuvre.Modules.IdentityAccess.Domain.UnitTests.SeedWork;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.PasswordResetRequests
{
    //#FFPR
    public class PasswordResetRequest_Domain_Tests : TestBase
    {

        //#FFPR-S1
        [Fact]
        public void GIVEN_ValidEMailIdANDActiveUser_WHEN_PasswordRestsRequested_THEN_ForgotPasswordRequestShouldBeCreated()
        {
            //Given
            var userFinder = new Mock<IUserFinder>();
            var email = "valid@email.com";
            var userEmailExists = true;
            var userActive = true;

            userFinder.Setup(e => e.FindUser(email))
                                    .Returns((userEmailExists, userActive));

            //When
            var passwordResetRequest = PasswordResetRequest.CreatePasswordResetRequest(email, userFinder.Object);

            var passwordResetRequestedDomainEvent = AssertPublishedDomainEvent<PasswordResetRequestedDomainEvent>(passwordResetRequest);

            //Then
            Assert.Equal(passwordResetRequestedDomainEvent.EMailId, email);
            Assert.Equal(PasswordRequestStatus.ResetPending, passwordResetRequest.GetProperty("status"));

        }

        //#FFPR-S2
        [Fact]
        public void GIVEN_ValidEMailIdANDInActiveUser_WHEN_PasswordRestsRequested_THEN_ForgotPasswordRequestShouldNOTBeCreated()
        {

            //Given
            var userFinder = new Mock<IUserFinder>();
            var email = "valid@email.com";
            var userEmailExists = true;
            var userActive = false;

            userFinder.Setup(e => e.FindUser(email))
                                    .Returns((userEmailExists, userActive));


            //When
            PasswordResetRequest passwordResetRequest = null;
            
            var exception = Record.Exception(() => passwordResetRequest 
                                = PasswordResetRequest.CreatePasswordResetRequest(email, userFinder.Object));


            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.Null(passwordResetRequest); //This also means that no domain events were raised
            Assert.IsType<UserMustBeActiveRule>(exc.BrokenRule);

        }

        //#FFPR-S3
        [Fact]
        public void GIVEN_InValidEMailIdANDActiveUser_WHEN_PasswordRestsRequested_THEN_ForgotPasswordRequestShouldNOTBeCreated()
        {
            //Given
            var userFinder = new Mock<IUserFinder>();
            var email = "invalid@email.com";
            var userEmailExists = false;
            var userActive = true;

            userFinder.Setup(e => e.FindUser(email))
                                    .Returns((userEmailExists, userActive));


            //When
            PasswordResetRequest passwordResetRequest = null;

            var exception = Record.Exception(() => passwordResetRequest
                                = PasswordResetRequest.CreatePasswordResetRequest(email, userFinder.Object));


            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.Null(passwordResetRequest); //This also means that no domain events were raised
            Assert.IsType<UserLoginEMailIdMustExistRule>(exc.BrokenRule);
        }

        //#FFPR-S4
        [Fact]
        public void GIVEN_InValidEMailIdANDInActiveUser_WHEN_PasswordRestsRequested_THEN_ForgotPasswordRequestShouldNOTBeCreated()
        {
            //Given
            var userFinder = new Mock<IUserFinder>();
            var email = "invalid@email.com";
            var userEmailExists = false;
            var userActive = false;

            userFinder.Setup(e => e.FindUser(email))
                                    .Returns((userEmailExists, userActive));


            //When
            PasswordResetRequest passwordResetRequest = null;

            var exception = Record.Exception(() => passwordResetRequest
                                = PasswordResetRequest.CreatePasswordResetRequest(email, userFinder.Object));


            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.Null(passwordResetRequest); //This also means that no domain events were raised
            Assert.IsType<UserLoginEMailIdMustExistRule>(exc.BrokenRule);

        }

    }
}
