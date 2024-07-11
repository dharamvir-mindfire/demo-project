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
        public ResponseDto<PersonDto> Get(Int64 id)
        {
            var dto = _dbContext.Persons.Find(id).Adapt<PersonDto>();
            var response = new ResponseDto<PersonDto>();
            response.Data = dto;
            return response;
        }
        public ResponseDto<List<PersonDto>?> GetAll()
        {
            var dto = _dbContext.Persons.ToList().Adapt<List<PersonDto>>();
            var response = new ResponseDto<List<PersonDto>?>();
            response.Data = dto;
            return response;
        }
        public ResponseDto<PersonDto> Add(PersonDto payload)
        {
            _dbContext.Persons.Add(payload.Adapt<Person>());
            _dbContext.SaveChanges();
            var response = new ResponseDto<PersonDto>();
            response.Data = payload.Adapt<PersonDto>();
            return response;
        }
        public ResponseDto<PersonDto> Update(PersonDto payload)
        {
            _dbContext.Persons.Attach(payload.Adapt<Person>());
            _dbContext.SaveChanges();
            var response = new ResponseDto<PersonDto>();
            response.Data = payload.Adapt<PersonDto>();
            return response;
        }
        public ResponseDto<PersonDto> Delete(Int64 id)
        {
            var existing = _dbContext.Persons.Find(id);
                var response = new ResponseDto<PersonDto>();
            if (existing != null)
            {
                _dbContext.Persons.Remove(existing);
                response.Message = "Deleted Successfully";
            }
            else
            {
                response.Message = "Not found";
            }
            return response;
        }
    }
}
