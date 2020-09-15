using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Domaina.Infrastructure.EMails;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Moq;
using Oeuvre.Modules.IdentityAccess.Application.Contracts;
using Oeuvre.Modules.IdentityAccess.Infrastructure;
using Oeuvre.Modules.IdentityAccess.Infrastructure.Configuration;
using Serilog;

namespace Oeuvre.Modules.IdentityAccess.IntegrationTests.SeedWork
{
    public class IdentityAcessIntegrationTestFixture : IDisposable
    {
        public IdentityAcessIntegrationTestFixture()
        {
            //Initializing Settings
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "IntegrationTesting");

            var builder = new ConfigurationBuilder()
                    .SetBasePath(PathHelpers.SoultionPath() + @"\Oeuvre")
                    .AddJsonFile("appsettings.IntegrationTesting.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();

            TestConfigurationVariables.ConnectionString = configuration.GetConnectionString("DefaultConnection");

            var emailsConfiguration = new EmailsConfiguration();
            configuration.Bind("EmailsConfiguration", emailsConfiguration);
            TestConfigurationVariables.EmailsConfiguration = emailsConfiguration;


            //Initializing the data in the integtating testing database
            TestDBInitializationHelpers.DropTablesAndViewsAndSchema();
            TestDBInitializationHelpers.CreateSchemaAndTablesAndViews();
            TestDBInitializationHelpers.AddSeedData();
            TestDBInitializationHelpers.AddTestData();

        }

        public void Dispose()
        {
            //Clean-up
            //TestDBInitializationHelpers.DropTablesAndViewsAndSchema();

        }

        //protected async Task<T> GetLastOutboxMessage<T>()
        //    where T : class, INotification
        //{
        //    using (var connection = new SqlConnection(ConnectionString))
        //    {
        //        var messages = await OutboxMessagesHelper.GetOutboxMessages(connection);

        //        return OutboxMessagesHelper.Deserialize<T>(messages.Last());
        //    }
        //}
    }
}