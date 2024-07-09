using Asp.Versioning.ApiExplorer;
using DemoProject.Database;
using DemoProject.Models;
using DemoProject.Services.Config;
using DemoProject.Services.CronJobs;
using DemoProject.Services.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace DemoProject.services.Config
{
    public static class AddServices
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.

            services.AddControllers();
            services.AddVersionConfig();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(description.GroupName, new OpenApiInfo
                    {
                        Title = "Demo Project",
                        Description = "Demo Project for strong concept",
                        Version = description.ApiVersion.ToString()
                    });
                }
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter bearer token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id  = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(configuration
                .GetConnectionString("DbConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            string? issuer = configuration["jwt:issuer"];
            string? issuerKey = configuration["jwt:key"];
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = issuer,
                    ValidAudience = issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(issuerKey))
                };
            });

            services.AddCors(options => options.AddPolicy("MyPolicy", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
            services.AddScoppedServices();
            services.AddHostedService<CronJobService>();
            return services;
        }
    }
}
