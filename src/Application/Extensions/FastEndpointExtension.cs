using System.Text.Json;
using Application.Extensions.JsonConverters;

namespace Application.Extensions;

public static class FastEndpointExtension
{
    public static void UseFastEndpointsExtension(this WebApplication app)
    {
        app.UseFastEndpoints(c =>
        {
            c.Serializer.Options.Converters.Add(new JsonGuidStringConverter());
            c.Serializer.Options.Converters.Add(new JsonGuidNullableStringConverter());
            c.Serializer.Options.Converters.Add(new JsonDateTimeStringConverter());
            c.Serializer.Options.Converters.Add(new JsonDateTimeNullableStringConverter());
            c.Endpoints.RoutePrefix = "api";
            c.Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        });
    }
}
