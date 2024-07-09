using DemoProject.Dtos;
using DemoProject.Helpers;
using DemoProject.IServices;
using DemoProject.Models;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace DemoProject.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthHelpers _authHelper;
        public AuthServices(UserManager<ApplicationUser> userManager, IAuthHelpers authHelper)
        {
            _userManager = userManager;
            _authHelper = authHelper;
        }
        public async Task<ResponseDto> Register(RegistrationDto payload)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var user = payload.Adapt<ApplicationUser>();

                var result = await _userManager.CreateAsync(user, payload.Password);
                if (result.Succeeded)
                {
                    result = await _userManager.AddToRoleAsync(user, "Customer");
                    if (result.Succeeded)
                    {
                        response.message = "Registered Success";
                    }
                    else
                    {
                        response.statusCode = 400;
                        response.message = "Failed to add role";
                    }
                }
                else
                {
                    response.statusCode = 400;
                    response.message = "Failed to register";
                }
            }
            catch (Exception ex)
            {
                response.statusCode = 400;
                response.message = $"Unexpected error occured:{ex.Message}";
            }
            return response;
        }
        public async Task<ResponseDto> Login(LoginDto payload)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                var user = await _userManager.FindByNameAsync(payload.UserName);
                if (user == null)
                {
                    response.statusCode = 404;
                    response.message = "User not found";
                }
                else
                {
                    var isValid = await _userManager.CheckPasswordAsync(user, payload.Password);
                    if (isValid)
                    {
                        var tokenUser = user.Adapt<TokenGenerateDto>();
                        var roles = await _userManager.GetRolesAsync(user);
                        if (roles != null && roles.Count > 0)
                        {
                            tokenUser.Role = roles[0];
                        }
                        var token = _authHelper.GenerateJWTToken(tokenUser);
                        response.data = new
                        {
                            fullName = user.FullName,
                            email = user.Email,
                            phoneNumber = user.PhoneNumber,
                            token = token
                        };
                    }
                    else
                    {
                        response.statusCode = 401;
                        response.message = "Invalid user";
                    }
                }
            }
            catch
            {
                response.statusCode = 400;
                response.message = "Unexpected error occured";
            }
            return response;
        }
    }
}
