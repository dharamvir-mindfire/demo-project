using Asp.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace DemoProject.Services.Config
{
    internal static class AutoVersioning
    {
        public static IServiceCollection AddVersionConfig(this IServiceCollection services)
        {

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            }); ;
            return services;
        }
    }
}
