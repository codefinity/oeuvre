using Domania.Domain;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.ConfirmUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.GetUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser;
using Oeuvre.Modules.IdentityAccess.Application.Users.GetUser;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations.Rules;
using Oeuvre.Modules.IdentityAccess.Infrastructure;
using Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.UserRegistrations
{
    [Collection("IdentityAcessIntegrationTestCollection")]
    //#FRC
    public class ConfirmRegistration_Integration_Tests: TestBase
    {

        private IdentityAcessIntegrationTestFixture fixture;

        public ConfirmRegistration_Integration_Tests(IdentityAcessIntegrationTestFixture fixture)
        {
            this.fixture = fixture;
        }

        //#FRC-S1
        [Fact]
        public async Task GIVEN_RegistrantConfirmsRegistrationWhenWaitingForConfirmation_THEN_ConfirmationShouldBeSuccessful()
        {
            //Given
            RegisterNewUserCommand registerNewUserCommand = new RegisterNewUserCommand(
                                                                "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                                                                "FN",
                                                                "LN",
                                                                "pass",
                                                                "+1",
                                                                "1234567",
                                                                "e2@mail.com",
                                                                true);

            //When
            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);

            await IdentityAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrationId));

            //Then
            var registrationQuery = await IdentityAccessModule.ExecuteQueryAsync(new GetUserRegistrationQuery(registrationId));

            var userQuery = await IdentityAccessModule.ExecuteQueryAsync(new GetUserQuery(registrationId));


            Assert.Equal(registrationQuery.StatusCode, UserRegistrationStatus.Confirmed.Value);
            Assert.Equal(registrationId, userQuery.Id);

            //Add DomainEvents Tests in the Application Layer by refering to code below:


            //Not Needed
            //var userRegistrationConfirmedNotification = await GetLastOutboxMessage<UserRegistrationConfirmedNotification>();
            //Assert.That(userRegistrationConfirmedNotification.DomainEvent.UserRegistrationId.Value, Is.EqualTo(registrationId));
        }

        //#FRC-S2
        [Fact]
        public async Task GIVEN_RegistrantConfirmsRegistrationMoreThanOnce_THEN_UserRegistrationCannotBeConfirmedMoreThanOnceRule_ShouldBeBroken()
        {

            //Given
            RegisterNewUserCommand registerNewUserCommand = new RegisterNewUserCommand(
                                                                "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                                                                "FN",
                                                                "LN",
                                                                "pass",
                                                                "+1",
                                                                "1234567",
                                                                "e3@mail.com",
                                                                true);


            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);

            await IdentityAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrationId));

            //When

            //Confirm Twice
            var exception = await Record.ExceptionAsync(() => 
                IdentityAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrationId)));


            //Then
            BusinessRuleValidationException exc = (BusinessRuleValidationException)exception;

            Assert.IsType<UserRegistrationCannotBeConfirmedMoreThanOnceRule>(exc.BrokenRule);

            Assert.IsType<BusinessRuleValidationException>(exception);


        }


        //#FRC-S3
        [Fact(Skip = "Skipped due to SystemClock concurrency issues")]
        public void GIVEN_RegistrantConfirmsRegistrationAfterExpirationPeriod_THEN_UserRegistrationCannotBeConfirmedAfterTimeExpiration_ShouldBeBroken()
        {

        }

    }
}