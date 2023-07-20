namespace Application.Extensions;

public static class SpaExtension
{
    public static void AddSpaExtension(this IServiceCollection services)
    {
        services.AddSpaStaticFiles(c => c.RootPath = "dist");
    }

    public static void UseSpaExtension(this WebApplication app)
    {
        app.UseSpaStaticFiles();
        app.UseSpa(o =>
        {
            if (!app.Environment.IsDevelopment())
                return;
            o.UseProxyToSpaDevelopmentServer("http://localhost:8001");
        });
    }
}
