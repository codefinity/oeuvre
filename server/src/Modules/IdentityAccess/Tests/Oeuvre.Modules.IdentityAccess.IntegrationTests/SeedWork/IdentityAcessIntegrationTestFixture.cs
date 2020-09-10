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
            //Initializing the data in the integtating testing database

            TestDBInitializationHelpers.DropTablesAndViewsAndSchema();
            TestDBInitializationHelpers.CreateSchemaAndTablesAndViews();
            TestDBInitializationHelpers.AddSeedData();
            TestDBInitializationHelpers.AddTestData();

        }

        public void Dispose()
        {
            //Clean-up
            TestDBInitializationHelpers.DropTablesAndViewsAndSchema();

        }

        //override methods here as needed for Test purpose
        //protected override void ConfigureWebHost(IWebHostBuilder builder)
        //{
        //    builder.ConfigureTestServices(services =>
        //    {
        //        // We can further customize our application setup here.

        //    });


        //    builder.ConfigureAppConfiguration(config =>
        //    {
        //        //var integrationConfig = new ConfigurationBuilder()
        //        //  .AddJsonFile("appsettings.IntegrationTests.json")
        //        //  .Build();

        //        //config.AddConfiguration(integrationConfig);
        //    })
        //    .UseEnvironment("IntegrationTesting");
        //}


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