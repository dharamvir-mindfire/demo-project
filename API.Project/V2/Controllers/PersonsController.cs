using Asp.Versioning;
using DemoProject.Dtos;
using DemoProject.Infrastructure.IServices;
using DemoProject.Models;
using Mapster;
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
    public class PersonsController : ControllerBase
    {
        private readonly IGenericServices<Person> _personServices;
        public PersonsController(IGenericServices<Person> personServices)
        {
            _personServices = personServices;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _personServices.GetAll();
            return new JsonResult(response);
        }
        [HttpGet]
        public IActionResult Get(int id)
        {
            var response = _personServices.Get(id);
            return new JsonResult(response);
        }
        [HttpPost]
        public IActionResult Add(PersonDto payload)
        {
            var response = _personServices.Add(payload.Adapt<Person>());
            return new JsonResult(response);
        }
        [HttpPut]
        public IActionResult Update(PersonDto payload)
        {
            var response = _personServices.Update(payload.Adapt<Person>());
            return new JsonResult(response);
        }
        [HttpDelete]
        public IActionResult Delete(Int64 id)
        {
            var response = _personServices.Delete(id);
            return new JsonResult(response);
        }
    }
}
