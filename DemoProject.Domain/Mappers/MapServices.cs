using DemoProject.Dtos;
using DemoProject.Helpers;
using DemoProject.Infrastructure.IServices;
using DemoProject.IServices;
using DemoProject.Models;
using DemoProject.Domain.Services;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace DemoProject.Domain.Mappers
{
    public static class MapServices
    {
        public static IServiceCollection AddScoppedServices(this IServiceCollection services)
        {
            TypeAdapterConfig<RegistrationDto, ApplicationUser>.NewConfig().Map(d => d.UserName, s => s.Email);
            services.AddScoped<IAuthServices, AuthServices>()
                .AddScoped<IGenericServices<Person>, GenericServices<Person>>()
                .AddScoped<IAuthHelpers, AuthHelpers>()
                .AddScoped<IPersonServices, PersonServices>();
            return services;
        }
    }
}
