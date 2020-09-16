using System;
using System.Threading.Tasks;
using Domaina.Infrastructure.EMails;
using Moq;
using Oeuvre.Modules.IdentityAccess.Application.UserRegistrations.SendUserRegistrationConfirmationEmail;
using Oeuvre.Modules.IdentityAccess.Domain.UserRegistrations;
using Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.UserRegistrations
{
    [Collection("IdentityAccessIntegrationTestCollection")]
    public class SendUserRegistrationConfirmationEmail_Integration_Tests : TestBase
    {
        [Fact]
        public async Task SendUserRegistrationConfirmationEmail_Test()
        {
            var registrationId = Guid.NewGuid();

            await IdentityAccessModule.ExecuteCommandAsync(new SendUserRegistrationConfirmationEmailCommand(
                                                            Guid.NewGuid(),
                                                            new UserRegistrationId(registrationId),
                                                            "e@mail.com"));

            var content = "Please click on this link to confirm your Registration http://localhost:5000/identityaccess/{registrationId}/confirm";

            var email = new EmailMessage(
                                "e@mail.com",
                                "MyMeetings - Please confirm your registration",
                                content);


            EmailSender.Object.SendEmail(email);

            EmailSender.Verify(m => m.SendEmail(email), Times.Once());

        }
    }
}