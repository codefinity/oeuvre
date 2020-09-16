using Moq;
using Oeuvre.Modules.IdentityAccess.Domain.UnitTests.SeedWork;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Domain.Users.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.UserActivationDeactivation
{
    public class UserActivationDeactivation_Domain_Tests : TestBase
    {
        [Fact]
        public void GIVEN_AUserIsActive_WHEN_UserIsDeactivated_THEN_UserShouldBeDeActivated()
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

            user.DeActivate();

            var userDeactivatedDomainEvent = AssertPublishedDomainEvent<UserDeActivated>(user);

            Assert.Equal(userDeactivatedDomainEvent.UserId, userDeactivatedDomainEvent.UserId);


            Assert.Equal(false, user.GetProperty("isActive"));


        }

        [Fact]
        public void GIVEN_AUserIsNotActive_WHEN_UserIsDeactivated_THEN_UserShouldBeActivated()
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

            user.Activate();

            var userDeactivatedDomainEvent = AssertPublishedDomainEvent<UserActivated>(user);

            Assert.Equal(userDeactivatedDomainEvent.UserId, userDeactivatedDomainEvent.UserId);

            Assert.Equal(true, user.GetProperty("isActive"));

        }

    }
}
