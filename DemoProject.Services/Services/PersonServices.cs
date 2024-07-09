using DemoProject.Dtos;
using DemoProject.Infrastructure.IServices;
using DemoProject.IServices;
using DemoProject.Models;
using Mapster;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DemoProject.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly IGenericServices<Person> _genericServices;
        public PersonServices(IGenericServices<Person> genericServices)
        {
            _genericServices = genericServices;
        }
        public ResponseDto Get(Int64 id)
        {
            var dto = _genericServices.Get(id).Adapt<PersonDto>();
            var response = new ResponseDto();
            response.data = dto;
            return response;
        }
        public ResponseDto GetAll()
        {
            var dto = _genericServices.GetAll().Adapt<List<PersonDto>>();
            var response = new ResponseDto();
            response.data = dto;
            return response;
        }
        public ResponseDto Add(PersonDto payload)
        {
            var added = _genericServices.Add(payload.Adapt<Person>()).Adapt<PersonDto>();
            var response = new ResponseDto();
            response.data = added;
            return response;
        }
        public ResponseDto Update(PersonDto payload)
        {
            var updated = _genericServices.Add(payload.Adapt<Person>()).Adapt<PersonDto>();
            var response = new ResponseDto();
            response.data = updated;
            return response;
        }
        public ResponseDto Delete(Int64 id)
        {
            var message = _genericServices.Delete(id);
            var response = new ResponseDto();
            response.message = message;
            return response;
        }
    }
}
