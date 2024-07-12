using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Test
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public async Task PersonsTest()
        {
            var authToken = Token.token;
            var webFactory = new WebApplicationFactory<Program>();
            var httpClient = webFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            var response = await httpClient.GetAsync("/api/v1/Persons/GetAll");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            var data = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
            Assert.IsTrue(data.Count > 0);
        }
    }
}
