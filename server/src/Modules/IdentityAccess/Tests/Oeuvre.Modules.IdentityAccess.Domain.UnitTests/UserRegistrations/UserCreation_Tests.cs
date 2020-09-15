using Domania.Domain;
using Moq;
using Oeuvre.Modules.IdentityAccess.Domain.UnitTests.SeedWork;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Rules;
using Oeuvre.Modules.IdentityAccess.Domain.Users.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.UserRegistrations
{
    public class UserCreation_Tests : TestBase
    {

        //Internal Tests
        [Fact]
        public void CreateUser_WhenRegistrationIsConfirmed_IsSuccessful()
        {

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

            registration.Confirm(registrationExpirationCalculator.Object);

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
