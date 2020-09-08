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
    public class OeuvreTestFixture : WebApplicationFactory<Startup>,  IDisposable
    {
        public OeuvreTestFixture()
        {

            // ... initialize data in the test database ...
            //Runs before all the tests in DemoFixtureTest

            TestDBHelpers.DropTables();
            TestDBHelpers.CreateTables();

            Debug.WriteLine("Runs before all tests");
        }

        public new void Dispose()
        {


            // ... clean up test data from the database ...
            //Runs after all the tests in DemoFixtureTest
            Debug.WriteLine("Runs after all tests");
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
