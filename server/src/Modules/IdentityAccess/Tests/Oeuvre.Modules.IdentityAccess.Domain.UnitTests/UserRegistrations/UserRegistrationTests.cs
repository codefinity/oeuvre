
using Domania.Domain;
using Moq;
using Oeuvre.Modules.IdentityAccess.Domain.UnitTests.SeedWork;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Events;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Rules;
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
                Registration.RegisterNewUser( new System.Guid("79530f73-8d20-48e7-bc15-c4d2679deb35"),
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
        public void NewUserRegistration_WithoutUniqueLogin_BreaksUserLoginMustBeUniqueRule()
        {
            // Arrange
            var usersCounter = new Mock<IUsersCounter>();
            usersCounter.Setup(p => p.CountUsersWithLogin("emailId")).Returns(1);

            // Assert
            var exception = Record.Exception(() => Registration.RegisterNewUser(new System.Guid("79530f73-8d20-48e7-bc15-c4d2679deb35"),
                                              "firstName",
                                              "lastName",
                                              "password",
                                              "mobileNoCountryCode",
                                              "mobileNumber",
                                              "emailId",
                                               usersCounter.Object));


            Assert.IsType<BusinessRuleValidationException>(exception);

        }

        //[Fact]
        //public void ConfirmingUserRegistration_WhenWaitingForConfirmation_IsSuccessful()
        //{
        //    var usersCounter = Substitute.For<IUsersCounter>();

        //    var registration = Registration.RegisterNewUser(
        //            "login", "password", "test@email",
        //            "firstName", "lastName", usersCounter);

        //    registration.Confirm();

        //    var userRegistrationConfirmedDomainEvent = AssertPublishedDomainEvent<UserRegistrationConfirmedDomainEvent>(registration);

        //    Assert.That(userRegistrationConfirmedDomainEvent.UserRegistrationId, Is.EqualTo(registration.Id));
        //}

        //[Fact]
        //public void UserRegistration_WhenIsConfirmed_CannotBeConfirmedAgain()
        //{
        //    var usersCounter = Substitute.For<IUsersCounter>();

        //    var registration = Registration.RegisterNewUser(
        //        "login", "password", "test@email",
        //        "firstName", "lastName", usersCounter);

        //    registration.Confirm();

        //    AssertBrokenRule<UserRegistrationCannotBeConfirmedMoreThanOnceRule>(() =>
        //    {
        //        registration.Confirm();
        //    });
        //}

        //[Fact]
        //public void UserRegistration_WhenIsExpired_CannotBeConfirmed()
        //{
        //    var usersCounter = Substitute.For<IUsersCounter>();

        //    var registration = Registration.RegisterNewUser(
        //        "login", "password", "test@email",
        //        "firstName", "lastName", usersCounter);

        //    registration.Expire();

        //    AssertBrokenRule<UserRegistrationCannotBeConfirmedAfterExpirationRule>(() =>
        //    {
        //        registration.Confirm();
        //    });
        //}

        //[Fact]
        //public void ExpiringUserRegistration_WhenWaitingForConfirmation_IsSuccessful()
        //{
        //    var usersCounter = Substitute.For<IUsersCounter>();

        //    var registration = Registration.RegisterNewUser(
        //        "login", "password", "test@email",
        //        "firstName", "lastName", usersCounter);

        //    registration.Expire();

        //    var userRegistrationExpired = AssertPublishedDomainEvent<UserRegistrationExpiredDomainEvent>(registration);

        //    Assert.That(userRegistrationExpired.UserRegistrationId, Is.EqualTo(registration.Id));          
        //}

        //[Fact]
        //public void UserRegistration_WhenIsExpired_CannotBeExpiredAgain()
        //{
        //    var usersCounter = Substitute.For<IUsersCounter>();

        //    var registration = Registration.RegisterNewUser(
        //        "login", "password", "test@email",
        //        "firstName", "lastName", usersCounter);

        //    registration.Expire();

        //    AssertBrokenRule<UserRegistrationCannotBeExpiredMoreThanOnceRule>(() =>
        //    {
        //        registration.Expire();
        //    });       
        //}

        //[Fact]
        //public void CreateUser_WhenRegistrationIsConfirmed_IsSuccessful()
        //{
        //    var usersCounter = Substitute.For<IUsersCounter>();

        //    var registration = Registration.RegisterNewUser(
        //        "login", "password", "test@email",
        //        "firstName", "lastName", usersCounter);

        //    registration.Confirm();

        //    var user = registration.CreateUser();

        //    var userCreated = AssertPublishedDomainEvent<UserCreatedDomainEvent>(user);

        //    Assert.That(user.Id, Is.EqualTo(registration.Id));
        //    Assert.That(userCreated.Id, Is.EqualTo(registration.Id));
        //}

        //[Fact]
        //public void UserCreation_WhenRegistrationIsNotConfirmed_IsNotPossible()
        //{
        //    var usersCounter = Substitute.For<IUsersCounter>();

        //    var registration = Registration.RegisterNewUser(
        //        "login", "password", "test@email",
        //        "firstName", "lastName", usersCounter);

        //    AssertBrokenRule<UserCannotBeCreatedWhenRegistrationIsNotConfirmedRule>(
        //        () =>
        //        {
        //            registration.CreateUser(); 
        //        });
        //}
    }
}