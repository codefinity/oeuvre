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
    public class ConfirmRegistration_Domain_Tests : TestBase
    {
        //#FRC-S1
        [Fact]
        public void GIVEN_RegistrantConfirmsRegistrationWhenWaitingForConfirmation_THEN_ConfirmationShouldBeSuccessful()
        {
            //Given
            var usersCounter = new Mock<IUsersCounter>().Object;

            var registrationExpirationCalculator = new Mock<IUserRegistrationConfirmationExpirationCalculator>();

            DateTime registrationDate = DateTime.Now;
            registrationExpirationCalculator.Setup(e => e.Calculate(It.IsAny<DateTime>()))
                                                .Returns(registrationDate.AddDays(2));

            var registration = Registration.RegisterNewUser(
                                 new System.Guid("79530f73-8d20-48e7-bc15-c4d2679deb35"),
                                 "Manfred",
                                 "Mann",
                                 "doWaDiddy",
                                 "+44",
                                 "4525856425",
                                 "Manfred@ManfredMann.com",
                                  usersCounter);

            //When
            registration.Confirm(registrationExpirationCalculator.Object);

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
            var usersCounter = new Mock<IUsersCounter>().Object;

            var registrationExpirationCalculator = new Mock<IUserRegistrationConfirmationExpirationCalculator>();

            DateTime registrationDate = DateTime.Now;
            registrationExpirationCalculator.Setup(e => e.Calculate(It.IsAny<DateTime>()))
                                                .Returns(registrationDate.AddDays(2));

            var registration = Registration.RegisterNewUser(
                                 new System.Guid("79530f73-8d20-48e7-bc15-c4d2679deb35"),
                                 "Manfred",
                                 "Mann",
                                 "doWaDiddy",
                                 "+44",
                                 "4525856425",
                                 "Manfred@ManfredMann.com",
                                  usersCounter);

            //When
            //Calling first time
            registration.Confirm(registrationExpirationCalculator.Object);

            //Calling Second time and receiving the exception
            var exception = Record.Exception(() => registration.Confirm(registrationExpirationCalculator.Object));

            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<UserRegistrationCannotBeConfirmedMoreThanOnceRule>(exc.BrokenRule);

            Assert.IsType<BusinessRuleValidationException>(exception);

        }

        //#FRC-S3
        [Fact(Skip ="Skipped due to SystemClock concurrency issues")]
        public void GIVEN_RegistrantConfirmsRegistrationAfterExpirationPeriod_THEN_UserRegistrationCannotBeConfirmedAfterTimeExpiration_ShouldBeBroken()
        {
            //Given
            var usersCounter = new Mock<IUsersCounter>().Object;

            var registrationExpirationCalculator = new Mock<IUserRegistrationConfirmationExpirationCalculator>();

            DateTime registrationDate = DateTime.Now;
            registrationExpirationCalculator.Setup(e => e.Calculate(It.IsAny<DateTime>()))
                                                .Returns(registrationDate.AddDays(2));


            var registration = Registration.RegisterNewUser(
                                 new System.Guid("79530f73-8d20-48e7-bc15-c4d2679deb35"),
                                 "Manfred",
                                 "Mann",
                                 "DoWaDiddy",
                                 "+44",
                                 "4525856425",
                                 "Manfred@ManfredMann.com",
                                  usersCounter);


            //When
            //Set System clock two days ahead
            SystemClock.Set(registrationDate.AddDays(2).AddMinutes(1));

            var exception = Record.Exception(() => registration.Confirm(registrationExpirationCalculator.Object));

            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<UserRegistrationCannotBeConfirmedAfterExpirationRule>(exc.BrokenRule);

            Assert.IsType<BusinessRuleValidationException>(exception);


        }

    }
}
