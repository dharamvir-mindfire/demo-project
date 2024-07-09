﻿using Asp.Versioning;
using DemoProject.Dtos;
using DemoProject.IServices;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.App.V2.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("2.0")]
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
            Response.StatusCode = response.statusCode;
            return new JsonResult(response.message);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto payload)
        {
            var response = await _authServices.Login(payload);
            Response.StatusCode = response.statusCode;
            return new JsonResult(response.statusCode == 200 ? response.data : response.message);
        }
    }
}
