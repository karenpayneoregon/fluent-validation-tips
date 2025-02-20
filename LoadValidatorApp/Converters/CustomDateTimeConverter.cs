using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LoadValidatorApp.Converters;

/// <summary>
/// Provides a custom JSON converter for <see cref="DateTime"/> objects, enabling serialization and deserialization
/// using a specific date and time format.
/// </summary>
/// <remarks>
/// The converter uses the format "MM/dd/yyyyTHH:mm:ss" for both reading and writing <see cref="DateTime"/> values.
/// </remarks>
public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    private const string Format = "MM/dd/yyyyTHH:mm:ss";

    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) 
        => DateTime.ParseExact(reader.GetString()!, Format, CultureInfo.InvariantCulture);

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Format));
    }
}