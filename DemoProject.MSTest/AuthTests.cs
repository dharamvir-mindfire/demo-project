using DemoProject.Test;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace APITesting.Test
{
    [TestClass]
    public class AuthTests
    {
        [TestMethod]
        public async Task RegisterTest()
        {
            string expected = "Registered Success";
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();
            string guid = Guid.NewGuid().ToString().Substring(0, 3);
            var payload = new
            {
                fullName = $"Mukesh {guid}",
                email = $"mukesh{guid}@example.com",
                phoneNumber = "9999955555",
                password = "Nokia@123"
            };
            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/v1/Account/Register", content);
            var stringResult = JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(expected, stringResult);
        }
        [TestMethod]
        public async Task LoginTest()
        {
            var expected = JsonConvert.SerializeObject(new
            {
                fullName = "Dharamvir",
                email = "dharamvir1@mindfiresolutions.com",
                phoneNumber = "9999955555",
            });
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();
            var payload = new
            {
                userName = "dharamvir1@mindfiresolutions.com",
                password = "Nokia@123"
            };
            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/api/v1/Account/Login", content);
            var stringResult = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
            string email = "";
            string token = "";
            if (stringResult != null)
            {
                email = Convert.ToString(stringResult["email"]);
                token = Convert.ToString(stringResult["token"]);
            }
            Token.token = token;
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(payload.userName, email);
        }
    }
}