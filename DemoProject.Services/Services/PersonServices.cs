using DemoProject.Database;
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
        private readonly AppDbContext _dbContext;
        public PersonServices(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ResponseDto Get(Int64 id)
        {
            var dto = _dbContext.Persons.Find(id).Adapt<PersonDto>();
            var response = new ResponseDto();
            response.data = dto;
            return response;
        }
        public ResponseDto GetAll()
        {
            var dto = _dbContext.Persons.ToList().Adapt<List<PersonDto>>();
            var response = new ResponseDto();
            response.data = dto;
            return response;
        }
        public ResponseDto Add(PersonDto payload)
        {
            _dbContext.Persons.Add(payload.Adapt<Person>());
            _dbContext.SaveChanges();
            var response = new ResponseDto();
            response.data = payload.Adapt<PersonDto>();
            return response;
        }
        public ResponseDto Update(PersonDto payload)
        {
            _dbContext.Persons.Attach(payload.Adapt<Person>());
            _dbContext.SaveChanges();
            var response = new ResponseDto();
            response.data = payload.Adapt<PersonDto>();
            return response;
        }
        public ResponseDto Delete(Int64 id)
        {
            var existing = _dbContext.Persons.Find(id);
                var response = new ResponseDto();
            if (existing != null)
            {
                var message = _dbContext.Persons.Remove(existing);
                response.message = "Deleted Successfully";
            }
            else
            {
                response.message = "Not found";
            }
            return response;
        }
    }
}
