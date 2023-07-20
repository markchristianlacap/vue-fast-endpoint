﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace Application.Extensions.JsonConverters;

public class JsonGuidNullableStringConverter : JsonConverter<Guid?>
{
    public override Guid? Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return Guid.TryParse(reader.GetString(), out var guid) ? guid : null;
    }

    public override void Write(Utf8JsonWriter writer, Guid? value, JsonSerializerOptions options)
    {
        if (value == null)
            writer.WriteNullValue();
        else
            writer.WriteStringValue(value == Guid.Empty ? "" : value.ToString());
    }
}
