using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Oeuvre.API.IntegrationTests
{
    public static class TokenHelpers
    {

        public static string GetAuthenticationToken(string email, string password, HttpClient client)
        {
            //HttpClient client = new HttpClient();

            var body = new Dictionary<string, string>();

            body.Add("grant_type", "password");
            body.Add("username", email);
            body.Add("password", password);
            body.Add("client_id", "ro.client");
            body.Add("client_secret", "secret");
            body.Add("scope", "oeuvreAPI openid profile");


            var req = new HttpRequestMessage(
                HttpMethod.Post, "http://localhost:5000/connect/token")
                { Content = new FormUrlEncodedContent(body) };

            return client.SendAsync(req).Result.Content.ReadAsStringAsync().Result.ToString();

        }

    }
}
