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
using System.Threading.Tasks;
using Xunit;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork
{
    public class TestBase
    {
        protected ILogger Logger { get; private set; }
        protected IIdentityAccessModule IdentityAccessModule { get; private set; }
        protected Mock<IEmailSender> EmailSender { get; private set; }

        public TestBase()
        {

            EmailSender = new Mock<IEmailSender>();

            IdentityAccessStartup.Initialize(
                TestConfigurationVariables.ConnectionString,
                new ExecutionContextMock(Guid.NewGuid()),
                //Logger,
                TestConfigurationVariables.EmailsConfiguration,
                //"key",
                EmailSender.Object);

            IdentityAccessModule = new IdentityAccessModule();
        }

    }
}
