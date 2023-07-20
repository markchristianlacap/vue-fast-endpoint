using FastEndpoints.Swagger;

namespace Application.Extensions;

public static class SwaggerExtension
{
    public static void AddSwaggerExtension(this IServiceCollection services)
    {
        services.SwaggerDocument();
    }

    public static void UseSwaggerExtension(this WebApplication app)
    {
        app.UseSwaggerGen();
    }
}
