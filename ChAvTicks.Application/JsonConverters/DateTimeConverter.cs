using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.JsonConverters
{
    public sealed class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));

            var dateTime = reader.GetString();

            if (string.IsNullOrEmpty(dateTime))
            {
                return DateTime.Parse(string.Empty);
            }

            return DateTime.Parse(dateTime);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
