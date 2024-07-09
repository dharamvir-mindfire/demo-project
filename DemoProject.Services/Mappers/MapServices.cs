using DemoProject.Dtos;
using DemoProject.Helpers;
using DemoProject.IServices;
using DemoProject.Models;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DemoProject.Services.Mappers
{
    public static class MapServices
    {
        public static IServiceCollection AddScoppedServices(this IServiceCollection services)
        {
            TypeAdapterConfig<RegistrationDto, ApplicationUser>.NewConfig().Map(d => d.UserName, s => s.Email);
            services.AddScoped<IAuthServices, AuthServices>()
                .AddScoped<IAuthHelpers, AuthHelpers>()
                .AddScoped<IHomeServices, HomeServices>();
            return services;
        }
    }
}
