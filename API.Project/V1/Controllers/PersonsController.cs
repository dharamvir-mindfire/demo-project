using Asp.Versioning;
using DemoProject.Dtos;
using DemoProject.IServices;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.App.V1.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiVersion("1.0")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "Customer")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonServices _personServices;
        public PersonsController(IPersonServices personServices)
        {
            _personServices = personServices;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _personServices.GetAll();
            Response.StatusCode = response.statusCode;
            return new JsonResult(response.statusCode == 200 ? response.data : response.message);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var response = _personServices.Get(id);
            Response.StatusCode = response.statusCode;
            return new JsonResult(response.statusCode == 200 ? response.data : response.message);
        }
        [HttpPost]
        public IActionResult Add(PersonDto payload)
        {
            var response = _personServices.Add(payload);
            Response.StatusCode = response.statusCode;
            return new JsonResult(response.statusCode == 200 ? response.data : response.message);
        }
        [HttpPut]
        public IActionResult Update(PersonDto payload)
        {
            var response = _personServices.Update(payload);
            Response.StatusCode = response.statusCode;
            return new JsonResult(response.statusCode == 200 ? response.data : response.message);
        }
        [HttpDelete]
        public IActionResult Delete(Int64 id)
        {
            var response = _personServices.Delete(id);
            Response.StatusCode = response.statusCode;
            return new JsonResult(response.message);
        }
    }
}
