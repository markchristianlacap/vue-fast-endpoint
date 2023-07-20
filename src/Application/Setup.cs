using Application.Extensions;
using Application.Services;
using Database;
using Database.Interfaces;

namespace Application;

public static class Setup
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration config)
    {
        // extensions from Application.Extensions
        services.AddAuthExtension();
        services.AddFastEndpoints();
        services.AddSwaggerExtension();
        services.AddSpaExtension();
        services.AddDatabase(config);

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IDateTimeService, DateTimeService>();
    }

    public static void ConfigureApplication(this WebApplication app, IWebHostEnvironment env)
    {
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseFastEndpointsExtension();
        app.UseSpaExtension();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwaggerExtension();
        }
    }
}
