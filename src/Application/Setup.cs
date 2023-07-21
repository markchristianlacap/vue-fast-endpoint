using Application.Extensions;
using Application.Services;
using Database;
using Database.Interceptors;
using Database.Interfaces;
using Database.Seeders;

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
        services.AddTransient<IDateTimeService, DateTimeService>();
        services.AddTransient<IUserService, UserService>();
    }

    public static void ConfigureApplication(this WebApplication app, IWebHostEnvironment env)
    {
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(e => { });
        app.UseFastEndpointsExtension();
        app.UseSpaExtension();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwaggerExtension();
        }
    }
}
