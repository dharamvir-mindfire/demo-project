using DemoProject.Dtos;

namespace DemoProject.IServices

{
    public interface IHomeServices
    {
       ResponseDto Persons();
       ResponseDto Person(int id);
    }
}
