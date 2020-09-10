using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace Oeuvre.API.IntegrationTests.IdentityAccess
{
    [Collection("IdentityAccessTestCollection")]
    public class RegistrationIntegrationTests
    {
        private readonly HttpClient client;
        public RegistrationIntegrationTests(OeuvreIntegrationTestFixture oeuvreTestFixture)
        {
            this.client = oeuvreTestFixture.CreateClient();
        }

        [Theory]
        [InlineData("/identityaccess/register")]
        public async void Post_Register_Valid_Success(string url)
        {
            //Arrange
            var newRegistrant = new
            {
                TenantId = "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                FirstName = "Roger",
                LastName = "Waters",
                Password = "dontneedno",
                MobileNoCountryCode = "+1",
                MobileNumber = "3256689922",
                EMail = "Roger@TheWall.com"
            };

            var registrantJson = new StringContent(JsonConvert.SerializeObject(
                                                    newRegistrant),
                                                    Encoding.UTF8,
                                                    "application/json");


            //Act
            var response = await client.PostAsync(url, registrantJson);


            //Assert
            string contents = response.Content.ReadAsStringAsync().Result;

            TestRegistrant reg = JsonConvert.DeserializeObject<TestRegistrant>(contents);

            TestRegistrant registrant = await DBAccessHelpers.GetData<TestRegistrant>(
                "SELECT * FROM [identityaccess].[Registrations] WHERE Id = '" + reg.Id + "'");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Assert.Equal("application/json; charset=UTF-8".ToLower(),
                            response.Content.Headers.ContentType.ToString().ToLower());

            Assert.NotEmpty(contents);


            Assert.Equal(newRegistrant.TenantId, registrant.TenantId.ToString());
            Assert.Equal(newRegistrant.FirstName, registrant.FirstName);
            Assert.Equal(newRegistrant.LastName, registrant.LastName);
            Assert.Equal(newRegistrant.MobileNumber, registrant.MobileNo);
            Assert.Equal(newRegistrant.MobileNoCountryCode, registrant.CountryCode);
            Assert.Equal(newRegistrant.EMail, registrant.EMail);
            Assert.Equal("WaitingForConfirmation", registrant.StatusCode);
            Assert.NotNull(registrant.Password);

        }

        [Fact(Skip = "Test Needs to be redesined to work on existing data")]
        public async void Patch_Confirm_User_Registration_Valid_Success()
        {
            //Arrange
            var newRegistrant = new
            {
                TenantId = "47d60457-5a80-4c83-96b6-890a5e5e4d22",
                FirstName = "Mary",
                LastName = "Carpenter",
                Password = "topoftheworld",
                MobileNoCountryCode = "+1",
                MobileNumber = "4387790052",
                EMail = "Mary@TheCarpenters.com"
            };

            var registrantJson = new StringContent(JsonConvert.SerializeObject(
                                                    newRegistrant),
                                                    Encoding.UTF8,
                                                    "application/json");


            var registrationResponse = await client.PostAsync("/identityaccess/register", registrantJson);

            TestRegistrant registrant = await DBAccessHelpers.GetData<TestRegistrant>(
                "SELECT * FROM [identityaccess].[Registrations] WHERE EMail = '" + newRegistrant.EMail + "'");

            //Act
            HttpContent httpContent = new StringContent("X", Encoding.UTF8, "application/json-patch+json");

            var confirmRegistrationResponse = await client
                .PatchAsync("/identityaccess/"+ registrant .Id + "/confirm", httpContent);

            // Assert
            var contents = await confirmRegistrationResponse.Content.ReadAsStringAsync();

            TestUser confirmedUser = await DBAccessHelpers.GetData<TestUser>(
                        "SELECT * FROM [identityaccess].[Users] " +
                        "WHERE Id = '" + registrant.Id + "'");

            TestRegistrant confirmedRegistrant = await DBAccessHelpers.GetData<TestRegistrant>(
                    "SELECT * FROM [identityaccess].[Registrations] " +
                    "WHERE Id = '" + registrant.Id + "'");


            Assert.Equal(newRegistrant.TenantId, confirmedUser.TenantId.ToString());
            Assert.Equal(newRegistrant.FirstName, confirmedUser.FirstName);
            Assert.Equal(newRegistrant.LastName, confirmedUser.LastName);
            Assert.Equal(newRegistrant.MobileNumber, confirmedUser.MobileNo);
            Assert.Equal(newRegistrant.MobileNoCountryCode, confirmedUser.CountryCode);
            Assert.Equal(newRegistrant.EMail, confirmedUser.EMail);
            Assert.True(confirmedUser.IsActive);
            Assert.NotNull(confirmedUser.Password);

            Assert.Equal("Confirmed", confirmedRegistrant.StatusCode);

            Assert.Equal(HttpStatusCode.OK, confirmRegistrationResponse.StatusCode);

            Assert.Empty(contents);

            //Not required because the API is not required to return any content.
            //Assert.Equal("application/json; charset=UTF-8",
            //                confirmRegistrationResponse.Content.Headers.ContentType.ToString());
        }

        [Theory(Skip = "Unable to perform this test because " +
                "identity server throws an exception: Issue #2")]
        [InlineData("/identityaccess/registrants")]
        public async void Get_GetAllRegistrants_Valid_Success(string url)
        {
            //Arrange
            string tokenResponse = TokenHelpers.GetAuthenticationToken("elvis@presley.com", "music", client);

            Token token = JsonConvert.DeserializeObject<Token>(tokenResponse);

            // Act

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5000" + url);
            httpRequestMessage.Headers.Add("Authorization", "Bearer " + token.access_token);


            var response = client.SendAsync(httpRequestMessage).Result;//.Content.ReadAsStringAsync().Result.ToString();


            //var contents = await response.Content.ReadAsStringAsync();
            //var registrantResponse = JsonConvert.DeserializeObject<List<Registrant>>(response.Content.ReadAsStringAsync().Result);


            // Assert1
            //Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            // Assert2
            //Assert.NotEmpty(contents);
            // Assert2
            //Assert.Equal("application/json; charset=utf-8",
            //    response.Content.Headers.ContentType.ToString());
        }

    }

}
