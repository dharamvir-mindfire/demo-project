using DemoProject.Domain.Config;

public class Program
{
    internal static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var Configuration = builder.Configuration;

        builder.Services.ConfigureServices(Configuration);

        var app = builder.Build();
        app.UseConfiguration(Configuration);
        app.Run();
    }


}

