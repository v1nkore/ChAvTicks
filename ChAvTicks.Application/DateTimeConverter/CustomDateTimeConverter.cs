using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.DateTimeConverter
{
    public sealed class CustomDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(typeToConvert == typeof(DateTime));

            var dateTime = reader.GetString();

            if (string.IsNullOrEmpty(dateTime))
            {
                return DateTime.Parse(dateTime!);
            }

            if (dateTime.Contains('Z'))
            {
                return DateTime.ParseExact(dateTime, DateTimeDefaults.UtcFormat, null);
            }

            return DateTime.ParseExact(dateTime, DateTimeDefaults.LocalFormat, null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime dateTime, JsonSerializerOptions options)
        {
            writer.WriteStringValue(dateTime.ToString());
        }
    }
}
