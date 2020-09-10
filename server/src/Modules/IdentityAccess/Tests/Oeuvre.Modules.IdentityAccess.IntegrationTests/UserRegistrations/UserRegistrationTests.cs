using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.GetUserRegistration;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.RegisterNewUser;
using Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.UserRegistrations
{
    [Collection("IdentityAccessIntegrationTestCollection")]
    public class UserRegistrationTests : TestBase
    {
        [Fact]
        public async Task RegisterNewUserCommand_Test()
        {
            RegisterNewUserCommand registerNewUserCommand = new RegisterNewUserCommand(
                                                    "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                                                    "FN",
                                                    "LN",
                                                    "pass",
                                                    "+1",
                                                    "1234567",
                                                    "e@mail.com");


            var registrationId = await IdentityAccessModule.ExecuteCommandAsync(registerNewUserCommand);

            var userRegistration = await IdentityAccessModule.ExecuteQueryAsync(new GetUserRegistrationQuery(registrationId));

            //Assert.That(userRegistration.Email, Is.EqualTo(UserRegistrationSampleData.Email));
            //Assert.That(userRegistration.Login, Is.EqualTo(UserRegistrationSampleData.Login));
            //Assert.That(userRegistration.FirstName, Is.EqualTo(UserRegistrationSampleData.FirstName));
            //Assert.That(userRegistration.LastName, Is.EqualTo(UserRegistrationSampleData.LastName));

            //var connection = new SqlConnection(ConnectionString);
            //var messagesList = await OutboxMessagesHelper.GetOutboxMessages(connection);

            //Assert.That(messagesList.Count, Is.EqualTo(1));

            //var newUserRegisteredNotification =
            //    await GetLastOutboxMessage<NewUserRegisteredNotification>();

            //Assert.That(newUserRegisteredNotification.DomainEvent.Login, Is.EqualTo(UserRegistrationSampleData.Login));
        }
    }
}