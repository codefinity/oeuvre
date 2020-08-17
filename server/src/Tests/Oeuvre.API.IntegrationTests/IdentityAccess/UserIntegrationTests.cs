using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Oeuvre.API.IntegrationTests.IdentityAccess
{
    public class UserIntegrationTests : IClassFixture<OeuvreTestFixture> 
    {

        private readonly HttpClient client;

        public UserIntegrationTests(OeuvreTestFixture oeuvreTestFixture)
        {
            //this.fixture = fixture;
            this.client = oeuvreTestFixture.CreateClient();

        }

        //[Theory]
        //[InlineData("/identityaccess/registrants")]
        //public async void Get_GetAllRegistrants_Valid_Success(string url)
        //{
        //    // Act
        //    var response = await client.GetAsync(url);

        //    var contents = await response.Content.ReadAsStringAsync();

        //    //var registrantResponse = JsonConvert.DeserializeObject<List<Registrants>>(response.Content.ReadAsStringAsync().Result);


        //    // Assert1
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //    // Assert2
        //    Assert.NotEmpty(contents);
        //    // Assert2
        //    Assert.Equal("application/json; charset=utf-8",
        //        response.Content.Headers.ContentType.ToString());
        //}

        //[Theory]
        //[InlineData("/identityaccess/register")]
        //public async void Post_Register_Valid_Success(string url)
        //{

        //    var registrant = new
        //    {
        //        TenantId = "47d60457-5a80-4c83-96b6-890a5e5e4d22",
        //        FirstName = "James",
        //        LastName = "Bond",
        //        Password = "",
        //        MobileNoCountryCode = "",
        //        MobileNumber = "",
        //        EMail = "a@b.com"
        //    };

        //    var json = new StringContent(JsonConvert.SerializeObject(registrant),
        //                                Encoding.UTF8,
        //                                "application/json");


        //    var response = await client.PostAsync(url, json);


        //    var contents = await response.Content.ReadAsStringAsync();

        //    // Assert1
        //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        //    // Assert2
        //    //Assert.NotEmpty(contents);
        //    // Assert2
        //    //Assert.Equal("application/json; charset=utf-8",
        //    //                response.Content.Headers.ContentType.ToString());
        //}
    }
}
