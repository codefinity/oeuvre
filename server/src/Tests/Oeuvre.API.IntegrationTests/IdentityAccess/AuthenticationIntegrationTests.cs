using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Oeuvre.API.IntegrationTests.IdentityAccess
{
    public class AuthenticationIntegrationTests : IClassFixture<OeuvreTestFixture>
    {
        private readonly HttpClient client;

        [Theory]
        [InlineData("/identityaccess/register")]
        public async void Post_Authenticate_Valid_Success(string url)
        {

            var registrantJson = new StringContent(JsonConvert.SerializeObject(
                                                    new
                                                    {
                                                        TenantId = "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                                                        FirstName = "Axl",
                                                        LastName = "Rose",
                                                        Password = "GunsNRoses",
                                                        MobileNoCountryCode = "1",
                                                        MobileNumber = "9999999999",
                                                        EMail = "Axl.Rose@GunsNRoses.com"
                                                    }),
                                                    Encoding.UTF8,
                                                    "application/json");


            var response = await client.PostAsync(url, registrantJson);


            var contents = await response.Content.ReadAsStringAsync();

            // Assert1
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Assert2
            //Assert.NotEmpty(contents);
            // Assert2
            //Assert.Equal("application/json; charset=utf-8",
            //                response.Content.Headers.ContentType.ToString());
        }

    }
}
