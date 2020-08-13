using Newtonsoft.Json;
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
        public RegistrationIntegrationTests(OeuvreTestFixture oeuvreTestFixture)
        {
            //this.fixture = fixture;
            this.client = oeuvreTestFixture.CreateClient();
        }


        [Theory]
        [InlineData("/identityaccess/registrants")]
        public async void Get_GetAllRegistrants_Valid_Success(string url)
        {
            // Act
            var response = await client.GetAsync(url);

            var contents = await response.Content.ReadAsStringAsync();

            //var registrantResponse = JsonConvert.DeserializeObject<List<Registrants>>(response.Content.ReadAsStringAsync().Result);


            // Assert1
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Assert2
            Assert.NotEmpty(contents);
            // Assert2
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Theory]
        [InlineData("/identityaccess/register")]
        public async void Post_Register_Valid_Success(string url)
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


        [Fact]
        //[InlineData("{userRegistrationId}/confirm")]
        public async void Patch_Confirm_User_Registration_Valid_Success()
        {

            HttpContent httpContent = new StringContent("X", Encoding.UTF8, "application/json-patch+json");


            var response = await client
                .PatchAsync("/identityaccess/321d9a61-f129-427f-bc1d-97aaa8228088/confirm", httpContent);


            //var contents = await response.Content.ReadAsStringAsync();

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
