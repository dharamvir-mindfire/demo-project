using DemoProject.Dtos;
using DemoProject.Helpers;
using DemoProject.Infrastructure.IServices;
using DemoProject.IServices;
using DemoProject.Models;
using DemoProject.Services.Services;
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
                .AddScoped<IGenericServices<Person>, GenericServicess<Person>>()
                .AddScoped<IAuthHelpers, AuthHelpers>()
                .AddScoped<IPersonServices, PersonServices>();
            return services;
        }
    }
}
