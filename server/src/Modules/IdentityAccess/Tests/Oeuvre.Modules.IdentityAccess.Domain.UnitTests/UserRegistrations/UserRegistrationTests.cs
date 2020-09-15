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
    //#FREG
    public class UserRegistrationTests : TestBase
    {

        //#FREG-S1
        [Fact]
        public void GIVEN_UserRegistersWithUniqueEMailId_THEN_RegistrationShouldBeSuccessful()
        {
            //Given
            var usersCounter = new Mock<IUsersCounter>();

            usersCounter.Setup(e => e.CountUsersWithLogin("Mary@TheCarpenters.com")).Returns(0);

            //When
            var userRegistration =
                Registration.RegisterNewUser(new System.Guid("47d60457-5a80-4c83-96b6-890a5e5e4d22"),
                                              "Mary",
                                              "Carpenter",
                                              "topoftheworld",
                                              "+1",
                                              "4387790052",
                                              "Mary@TheCarpenters.com",
                                               usersCounter.Object);

            //Then
            var newUserRegisteredDomainEvent = AssertPublishedDomainEvent<NewUserRegisteredDomainEvent>(userRegistration);

            Assert.Equal(newUserRegisteredDomainEvent.UserRegistrationId, userRegistration.Id);

            Assert.Equal(userRegistration.GetProperty("status"), UserRegistrationStatus.WaitingForConfirmation);
        }

        //#FREG-S2
        [Fact]
        public void GIVEN_UserRegistersMoreThanOnceWithUniqueEMailId_THEN_RegistrationShouldBeSuccessful()
        {
            //Given
            var usersCounter = new Mock<IUsersCounter>();

            usersCounter.Setup(e => e.CountUsersWithLogin("Mary@TheCarpenters.com")).Returns(0);

            //When
            var userRegistration =
                Registration.RegisterNewUser(new System.Guid("47d60457-5a80-4c83-96b6-890a5e5e4d22"),
                                              "Mary",
                                              "Carpenter",
                                              "topoftheworld",
                                              "+1",
                                              "4387790052",
                                              "Mary@TheCarpenters.com",
                                               usersCounter.Object);

            //Then
            var newUserRegisteredDomainEvent = AssertPublishedDomainEvent<NewUserRegisteredDomainEvent>(userRegistration);

            Assert.Equal(newUserRegisteredDomainEvent.UserRegistrationId, userRegistration.Id);

            Assert.Equal(userRegistration.GetProperty("status"), UserRegistrationStatus.WaitingForConfirmation);
        }

        //#FREG-S3
        [Fact]
        public void GIVEN_UserRegistersAfterEMailVerificationLinkExpiresWithUniqueEMailId_THEN_RegistrationShouldBeSuccessful()
        {
            //Given
            var usersCounter = new Mock<IUsersCounter>();

            usersCounter.Setup(e => e.CountUsersWithLogin("Mary@TheCarpenters.com")).Returns(0);

            //When
            var userRegistration =
                Registration.RegisterNewUser(new System.Guid("47d60457-5a80-4c83-96b6-890a5e5e4d22"),
                                              "Mary",
                                              "Carpenter",
                                              "topoftheworld",
                                              "+1",
                                              "4387790052",
                                              "Mary@TheCarpenters.com",
                                               usersCounter.Object);

            //Then
            var newUserRegisteredDomainEvent = AssertPublishedDomainEvent<NewUserRegisteredDomainEvent>(userRegistration);

            Assert.Equal(newUserRegisteredDomainEvent.UserRegistrationId, userRegistration.Id);

            Assert.Equal(userRegistration.GetProperty("status"), UserRegistrationStatus.WaitingForConfirmation);
        }

        //#FREG-S4
        [Fact]
        public void GIVEN_UserRegistersWithoutUniqueEmailId_THEN_BreaksUserLoginEmailIdMustBeUniqueRule()
        {
            //Given
            var usersCounter = new Mock<IUsersCounter>();
            usersCounter.Setup(p => p.CountUsersWithLogin("Manfred@ManfredMann.com")).Returns(1);

            //When
            var exception = Record.Exception(() => Registration.RegisterNewUser(
                                                     new System.Guid("79530f73-8d20-48e7-bc15-c4d2679deb35"),
                                                     "Manfred",
                                                     "Mann",
                                                     "doWaDiddy",
                                                     "+44",
                                                     "4525856425",
                                                     "Manfred@ManfredMann.com",
                                                      usersCounter.Object));

            
            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<UserEmailIdLoginMustBeUniqueRule>(exc.BrokenRule);

            Assert.IsType<BusinessRuleValidationException>(exception);

        }

    }
}