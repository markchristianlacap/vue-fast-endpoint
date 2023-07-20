using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.Extensions.JsonConverters;

public class JsonGuidStringConverter : JsonConverter<Guid>
{
    public override Guid Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return Guid.TryParse(reader.GetString(), out var guid) ? guid : Guid.Empty;
    }

    public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value == Guid.Empty ? "" : value.ToString());
    }
}
