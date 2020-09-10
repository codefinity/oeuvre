using Domaina.Infrastructure.EMails;
using Microsoft.Extensions.Configuration;
using Moq;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Infrastructure;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork
{
    public class TestBase
    {
        protected string ConnectionString { get; private set; }
        protected ILogger Logger { get; private set; }
        protected IIdentityAccessModule IdentityAccessModule { get; private set; }
        protected Mock<IEmailSender> EmailSender { get; private set; }

        public TestBase()
        {
            ConnectionString = "Server=DESKTOP-6DRE2VL;Database=oeuvre_integration_testing;Trusted_Connection=True;";

            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "IntegrationTesting");

            var builder = new ConfigurationBuilder()
                    .SetBasePath(TestDBInitializationHelpers.SoultionPath() + @"\Oeuvre")
                    .AddJsonFile("appsettings.IntegrationTesting.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();

            var emailsConfiguration = new EmailsConfiguration();
            configuration.Bind("EmailsConfiguration", emailsConfiguration);


            //Logger = (new Mock<ILogger>()).Object;
            EmailSender = new Mock<IEmailSender>();

            IdentityAccessStartup.Initialize(
                ConnectionString,
                new ExecutionContextMock(Guid.NewGuid()),
                //Logger,
                emailsConfiguration,
                //"key",
                EmailSender.Object);

            IdentityAccessModule = new IdentityAccessModule();
        }
    }
}
