using DemoProject.Dtos;
using DemoProject.IServices;
using DemoProject.Models;
using Mapster;

namespace DemoProject.Services
{
    public class HomeServices : IHomeServices
    {
        private readonly IList<Person> mockData = DemoData.CreatePersons();
        public ResponseDto Person(int id)
        {
            var dto = mockData.Where(g => g.Id == id).FirstOrDefault().Adapt<PersonDto>();
            var response = new ResponseDto();
            response.data = dto;
            return response;
        }
        public ResponseDto Persons()
        {
            var dto = mockData.Adapt<IList<PersonDto>>();
            var response = new ResponseDto();
            response.data = dto;
            return response;
        }
    }
}
