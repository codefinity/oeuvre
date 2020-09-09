using Domania.Domain;
using Moq;
using Oeuvre.Modules.IdentityAccess.Domain.UnitTests.SeedWork;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Events;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Rules;
using Oeuvre.Modules.IdentityAccess.Domain.Users.Events;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.Domain.UnitTests.UserRegistrations
{
    public class UserRegistrationTests : TestBase
    {
        [Fact]
        public void NewUserRegistration_WithUniqueLogin_IsSuccessful()
        {
            // Arrange
            var usersCounter = new Mock<IUsersCounter>();

            // Act
            var userRegistration =
                Registration.RegisterNewUser(new System.Guid("79530f73-8d20-48e7-bc15-c4d2679deb35"),
                                              "firstName",
                                              "lastName",
                                              "password",
                                              "mobileNoCountryCode",
                                              "mobileNumber",
                                              "emailId",
                                               usersCounter.Object);

            // Assert
            var newUserRegisteredDomainEvent = AssertPublishedDomainEvent<NewUserRegisteredDomainEvent>(userRegistration);

            Assert.Equal(newUserRegisteredDomainEvent.UserRegistrationId, userRegistration.Id);
        }

        [Fact]
        public void NewUserRegistration_WithoutUniqueEmailId_Login_BreaksUserLoginEmailIdMustBeUniqueRule()
        {
            // Arrange
            var usersCounter = new Mock<IUsersCounter>();
            usersCounter.Setup(p => p.CountUsersWithLogin("Manfred@ManfredMann.com")).Returns(1);

            // Assert
            var exception = Record.Exception(() => Registration.RegisterNewUser(
                                                     new System.Guid("79530f73-8d20-48e7-bc15-c4d2679deb35"),
                                                     "Manfred",
                                                     "Mann",
                                                     "doWaDiddy",
                                                     "+44",
                                                     "4525856425",
                                                     "Manfred@ManfredMann.com",
                                                      usersCounter.Object));

            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<UserEmailIdLoginMustBeUniqueRule>(exc.BrokenRule);

            Assert.IsType<BusinessRuleValidationException>(exception);

        }

        [Fact]
        public void ConfirmingUserRegistration_WhenWaitingForConfirmation_IsSuccessful()
        {
            //Arrange
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

            //Act
            registration.Confirm();

            //Assert
            var userRegistrationConfirmedDomainEvent = AssertPublishedDomainEvent<UserRegistrationConfirmedDomainEvent>(registration);

            Assert.Equal(userRegistrationConfirmedDomainEvent.UserRegistrationId, registration.Id);
        }

        [Fact]
        public void UserRegistration_WhenIsConfirmed_CannotBeConfirmedAgain()
        {
            //Arrange
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

            //Act
            //Calling first time
            registration.Confirm();

            var exception = Record.Exception(() => registration.Confirm());

            // Assert
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<UserRegistrationCannotBeConfirmedMoreThanOnceRule>(exc.BrokenRule);

            Assert.IsType<BusinessRuleValidationException>(exception);

        }

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


        [Fact]
        public void CreateUser_WhenRegistrationDateIsMoreThanXDays_IsNotPossible()
        {




        }

    }
}