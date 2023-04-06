using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleWebAPI.Infrastructure.Converters.JsonConverters
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateOnly.FromDateTime(reader.GetDateTime());
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            string rawValue;

            rawValue = value.ToString("O");
            writer.WriteStringValue(rawValue);
        }
    }
}