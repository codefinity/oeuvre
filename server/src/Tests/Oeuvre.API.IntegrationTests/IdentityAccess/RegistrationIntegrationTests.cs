using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Oeuvre.API.IntegrationTests.IdentityAccess
{
    public class RegistrationIntegrationTests : IClassFixture<OeuvreTestFixture>
    {
        //private readonly OeuvreTestFixture fixture;
        private readonly HttpClient client;
        public RegistrationIntegrationTests(OeuvreTestFixture fixture)
        {
            //this.fixture = fixture;
            this.client = fixture.CreateClient();
        }


        [Theory]
        [InlineData("/identityaccess/registrants")]
        public async void Get_GetAllRegistrants_Valid_Success(string url)
        {
            // Act
            var response = await client.GetAsync(url);

            var contents = await response.Content.ReadAsStringAsync();


            // Assert1
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Assert2
            Assert.NotEmpty(contents);
            // Assert2
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }

}
