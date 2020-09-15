using Domania.Domain;
using Moq;
using Oeuvre.Modules.IdentityAccess.Domain.UnitTests.SeedWork;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Events;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Rules;
using Oeuvre.Modules.IdentityAccess.Domain.Users.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.UserRegistrations
{
    //#FRC
    public class RegistrationConfirmation : TestBase
    {
        //#FRC-S1
        [Fact]
        public void GIVEN_RegistrantConfirmsRegistrationWhenWaitingForConfirmation_THEN_ConfirmationShouldBeSuccessful()
        {
            //Given
            var usersCounter = new Mock<IUsersCounter>();

            var registration = Registration.RegisterNewUser(
                                 new System.Guid("79530f73-8d20-48e7-bc15-c4d2679deb35"),
                                 "Manfred",
                                 "Mann",
                                 "doWaDiddy",
                                 "+44",
                                 "4525856425",
                                 "Manfred@ManfredMann.com",
                                  usersCounter.Object);

            //When
            registration.Confirm();

            //Then
            var userRegistrationConfirmedDomainEvent = AssertPublishedDomainEvent<UserRegistrationConfirmedDomainEvent>(registration);

            Assert.Equal(userRegistrationConfirmedDomainEvent.UserRegistrationId, registration.Id);

            Assert.Equal(registration.GetProperty("status"), UserRegistrationStatus.Confirmed);
        }

        //#FRC-S2
        [Fact]
        public void GIVEN_RegistrantConfirmsRegistrationMoreThanOnce_THEN_UserRegistrationCannotBeConfirmedMoreThanOnceRule_ShouldBeBroken()
        {
            //Given
            var usersCounter = new Mock<IUsersCounter>();


            var registration = Registration.RegisterNewUser(
                                 new System.Guid("79530f73-8d20-48e7-bc15-c4d2679deb35"),
                                 "Manfred",
                                 "Mann",
                                 "doWaDiddy",
                                 "+44",
                                 "4525856425",
                                 "Manfred@ManfredMann.com",
                                  usersCounter.Object);

            //When
            //Calling first time
            registration.Confirm();

            //Calling Second time and receiving the exception
            var exception = Record.Exception(() => registration.Confirm());

            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<UserRegistrationCannotBeConfirmedMoreThanOnceRule>(exc.BrokenRule);

            Assert.IsType<BusinessRuleValidationException>(exception);

        }

        //#FRC-S3
        [Fact]
        public void GIVEN_RegistrantConfirmsRegistrationAfterExpirationPeriod_THEN_UserRegistrationCannotBeConfirmedAfterTimeExpiration_ShouldBeBroken()
        {




        }


        //Internal Tests
        [Fact]
        public void CreateUser_WhenRegistrationIsConfirmed_IsSuccessful()
        {
            var usersCounter = new Mock<IUsersCounter>();

            var registration = Registration.RegisterNewUser(
                                 new System.Guid("79530f73-8d20-48e7-bc15-c4d2679deb35"),
                                 "Manfred",
                                 "Mann",
                                 "doWaDiddy",
                                 "+44",
                                 "4525856425",
                                 "Manfred@ManfredMann.com",
                                  usersCounter.Object);

            registration.Confirm();

            var user = registration.CreateUser();

            var userCreatedDomainEvent = AssertPublishedDomainEvent<UserCreatedDomainEvent>(user);

            Assert.Equal(user.Id.Value, registration.Id.Value);
            Assert.Equal(userCreatedDomainEvent.UserId.Value, registration.Id.Value);

        }

        [Fact]
        public void UserCreation_WhenRegistrationIsNotConfirmed_IsNotPossible()
        {
            var usersCounter = new Mock<IUsersCounter>();

            var registration = Registration.RegisterNewUser(
                                 new System.Guid("79530f73-8d20-48e7-bc15-c4d2679deb35"),
                                 "Manfred",
                                 "Mann",
                                 "doWaDiddy",
                                 "+44",
                                 "4525856425",
                                 "Manfred@ManfredMann.com",
                                  usersCounter.Object);

            // Act
            var exception = Record.Exception(() => registration.CreateUser());

            //Assert
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<UserCannotBeCreatedWhenRegistrationIsNotConfirmedRule>(exc.BrokenRule);

            Assert.IsType<BusinessRuleValidationException>(exception);

        }

    }
}
