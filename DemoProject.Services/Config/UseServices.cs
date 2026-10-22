using Asp.Versioning.ApiExplorer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoProject.Services.Config
{
    public static class UseServices
    {
        public static IApplicationBuilder UseConfiguration(this WebApplication app, IConfiguration configuration)
        {
            app.UseAutoMigrate();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
            }
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var providers = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
                string baseUrl = "";
                foreach(var description in providers.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"{baseUrl}/swagger/{description.GroupName}/swagger.json", $"App {description.GroupName.ToLowerInvariant()}");
                }
            });
            app.UseCors("MyPolicy");
            //app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            return app;
        }
    }
}
