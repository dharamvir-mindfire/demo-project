using DemoProject.Dtos;

namespace DemoProject.IServices
{
    public interface IAuthServices
    {
        public Task<ResponseDto> Register(RegistrationDto payload);
        public Task<ResponseDto> Login(LoginDto payload);
    }
}
