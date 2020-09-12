using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.ConfirmUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.GetUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.Infrastructure;
using Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.UserRegistrations
{
    [Collection("IdentityAccessIntegrationTestCollection")]
    public class ConfirmUserRegistrationTests: TestBase
    {
        [Fact]
        public async Task ConfirmUserRegistration_Test()
        {
            RegisterNewUserCommand registerNewUserCommand = new RegisterNewUserCommand(
                                                                "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                                                                "FN",
                                                                "LN",
                                                                "pass",
                                                                "+1",
                                                                "1234567",
                                                                "e2@mail.com");


            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);

            await IdentityAccessModule.ExecuteCommandAsync(new ConfirmUserRegistrationCommand(registrationId));

            var userRegistration = await IdentityAccessModule.ExecuteQueryAsync(new GetUserRegistrationQuery(registrationId));

            //Assert.Equal(userRegistration.StatusCode, UserRegistrationStatus.Confirmed.Value);


            //Not Needed
            //var userRegistrationConfirmedNotification = await GetLastOutboxMessage<UserRegistrationConfirmedNotification>();
            //Assert.That(userRegistrationConfirmedNotification.DomainEvent.UserRegistrationId.Value, Is.EqualTo(registrationId));
        }
    }
}