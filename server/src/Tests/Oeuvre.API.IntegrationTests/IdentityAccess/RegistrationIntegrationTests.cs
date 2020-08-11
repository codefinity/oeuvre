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

            var registrant = new
            {
                TenantId = "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                FirstName = "James",
                LastName = "Bond",
                Password = "",
                MobileNoCountryCode = "",
                MobileNumber = "",
                EMail = "a1@b.com"
            };

            var json = new StringContent(JsonConvert.SerializeObject(registrant),
                                        Encoding.UTF8,
                                        "application/json");


            var response = await client.PostAsync(url, json);


            var contents = await response.Content.ReadAsStringAsync();

            // Assert1
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Assert2
            //Assert.NotEmpty(contents);
            // Assert2
            //Assert.Equal("application/json; charset=utf-8",
            //                response.Content.Headers.ContentType.ToString());
        }

        public class Registrants
        {
            public Guid Id { get; set; }
            public Guid TenantId { get; }
            public string firstName { get; }
            public string LastName { get; }
            public string Password { get; }
            public string MobileNoCountryCode { get; set; }
            public string MobileNumber { get; }
            public string Email { get; }
        }
    }

}
