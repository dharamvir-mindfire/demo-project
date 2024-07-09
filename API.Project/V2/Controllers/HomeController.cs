using Asp.Versioning;
using DemoProject.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.App.V2.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("2.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Customer")]
    public class HomeController : ControllerBase
    {
        private readonly IHomeServices _homeServices;
        public HomeController(IHomeServices homeServices)
        {
            _homeServices = homeServices;
        }
        [HttpGet]
        public IActionResult Persons()
        {
            var response = _homeServices.Persons();
            return new JsonResult(response.statusCode == 200 ? response.data : response?.message);
        }
        [HttpGet]
        public IActionResult Person(int id)
        {
            var response = _homeServices.Person(id);
            return new JsonResult(response.statusCode == 200 ? response.data : response?.message);
        }
    }
}
