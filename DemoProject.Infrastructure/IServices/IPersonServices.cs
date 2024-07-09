using DemoProject.Dtos;

namespace DemoProject.IServices

{
    public interface IPersonServices
    {
        ResponseDto GetAll();
        ResponseDto Get(Int64 id);
        ResponseDto Add(PersonDto payload);
        ResponseDto Update(PersonDto payload);
        ResponseDto Delete(Int64 id);
    }
}
