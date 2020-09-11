using Newtonsoft.Json;
using Oeuvre.API.IntegrationTests.SeedWork;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Oeuvre.API.IntegrationTests.IdentityAccess
{
    [Collection("IdentityAccessTestCollection")]
    public class UserIntegrationTests
    {
        private readonly HttpClient client;

        public UserIntegrationTests(OeuvreIntegrationTestFixture oeuvreTestFixture)
        {
            this.client = oeuvreTestFixture.CreateClient();
        }

    }
}
