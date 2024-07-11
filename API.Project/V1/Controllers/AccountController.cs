using Asp.Versioning;
using DemoProject.Dtos;
using DemoProject.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.App.V1.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("1.0", Deprecated = true)]
    public class AccountController : Controller
    {
        private readonly IAuthServices _authServices;
        public AccountController(IAuthServices authServices)
        {
            _authServices = authServices;
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationDto payload)
        {
            var response = await _authServices.Register(payload);
            Response.StatusCode = response.StatusCode;
            return new JsonResult(response.Message);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto payload)
        {
            var response = await _authServices.Login(payload);
            Response.StatusCode = response.StatusCode;
            return new JsonResult(response.StatusCode == 200 ? response.Data : response.Message);
        }
    }
}
