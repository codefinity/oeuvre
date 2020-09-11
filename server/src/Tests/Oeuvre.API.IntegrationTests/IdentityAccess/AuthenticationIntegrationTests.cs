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
    public class AuthenticationIntegrationTests
    {
        private readonly HttpClient client = null;

        public AuthenticationIntegrationTests(OeuvreIntegrationTestFixture oeuvreTestFixture)
        {
            this.client = oeuvreTestFixture.CreateClient();
        }

        [Theory]
        [InlineData("http://localhost:5000/connect/token")]
        public async void Post_Authenticate_Success_With_Valid_Credentials(string url)
        {
            //Arrange
            var body = new Dictionary<string, string>();

            body.Add("grant_type", "password");
            body.Add("username", "elvis@presley.com");
            body.Add("password", "music");
            body.Add("client_id", "ro.client");
            body.Add("client_secret", "secret");
            body.Add("scope", "oeuvreAPI openid profile");

            //Act
            var req = new HttpRequestMessage(
                HttpMethod.Post, url)
            { Content = new FormUrlEncodedContent(body) };

            var response = client.SendAsync(req).Result;

            string contents = response.Content.ReadAsStringAsync().Result;

            Token token = JsonConvert.DeserializeObject<Token>(contents);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            Assert.NotEmpty(contents);

            Assert.NotEmpty(token.access_token);

            Assert.Equal("application/json; charset=UTF-8".ToLower(),
                            response.Content.Headers.ContentType.ToString().ToLower());
        }

        [Theory]
        [InlineData("http://localhost:5000/connect/token")]
        public async void Post_Authenticate_Fail_With_Invalid_Credentials(string url)
        {

            //Arrange
            var body = new Dictionary<string, string>();

            body.Add("grant_type", "password");
            body.Add("username", "elvis@presley.com");
            body.Add("password", "music-music");        //Wrong Password
            body.Add("client_id", "ro.client");
            body.Add("client_secret", "secret");
            body.Add("scope", "oeuvreAPI openid profile");

            //Act
            var req = new HttpRequestMessage(
                HttpMethod.Post, url)
            { Content = new FormUrlEncodedContent(body) };

            var response = client.SendAsync(req).Result;

            string contents = response.Content.ReadAsStringAsync().Result;

            Token token = JsonConvert.DeserializeObject<Token>(contents);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

            Assert.NotEmpty(contents);

            Assert.Null(token.access_token);

            Assert.Equal("{\"error\":\"invalid_grant\"," +
                            "\"error_description\":\"Incorrect login or password\"}",
                            contents);

            Assert.Equal("application/json; charset=UTF-8".ToLower(),
                            response.Content.Headers.ContentType.ToString().ToLower());
        }

    }
}
