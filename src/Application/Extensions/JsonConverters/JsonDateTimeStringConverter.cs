using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.Extensions.JsonConverters;

public class JsonDateTimeStringConverter : JsonConverter<DateTime>
{
    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return DateTime.TryParse(reader.GetString(), out var date) ? date : default;
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value == default ? "" : value.ToString("yyyy/MM/dd hh:mm:ss tt"));
    }
}
