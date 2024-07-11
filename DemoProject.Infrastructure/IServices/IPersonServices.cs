using DemoProject.Dtos;

namespace DemoProject.IServices

{
    public interface IPersonServices
    {
        ResponseDto<List<PersonDto>> GetAll();
        ResponseDto<PersonDto> Get(Int64 id);
        ResponseDto<PersonDto> Add(PersonDto payload);
        ResponseDto<PersonDto> Update(PersonDto payload);
        ResponseDto<PersonDto> Delete(Int64 id);
    }
}
