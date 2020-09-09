using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oeuvre.Modules.IdentityAccess.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;


namespace Oeuvre.API.IntegrationTests
{
    public class OeuvreIntegrationTestFixture : WebApplicationFactory<Startup>,  IDisposable
    {
        public OeuvreIntegrationTestFixture()
        {
            //Initializing the data in the integtating testing database

            TestDBInitializationHelpers.DropTablesAndViewsAndSchema();
            TestDBInitializationHelpers.CreateSchemaAndTablesAndViews();
            TestDBInitializationHelpers.AddSeedData();
            TestDBInitializationHelpers.AddTestData();
        }

        public new void Dispose()
        {
            //Clean-up
            TestDBInitializationHelpers.DropTablesAndViewsAndSchema();

        }

        //override methods here as needed for Test purpose
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                // We can further customize our application setup here.

            });


            builder.ConfigureAppConfiguration(config =>
            {
                //var integrationConfig = new ConfigurationBuilder()
                //  .AddJsonFile("appsettings.IntegrationTests.json")
                //  .Build();

                //config.AddConfiguration(integrationConfig);
            })
            .UseEnvironment("IntegrationTesting");
        }

    }
}
