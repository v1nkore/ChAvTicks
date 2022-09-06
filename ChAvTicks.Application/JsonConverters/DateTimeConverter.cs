using System.Diagnostics;
using System.Globalization;
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

            if (dateTime.Contains('+'))
            {
                var offset = dateTime.Substring(dateTime.IndexOf('+'), dateTime.Length - dateTime.IndexOf('+'));
                return DateTime.ParseExact(dateTime, $"{DateTimeDefaults.DateTimeWithoutSec}{offset}", null);
            }

            if (dateTime.LastIndexOf('-') == 16)
            {
                var offset = dateTime.Substring(dateTime.LastIndexOf('-'), dateTime.Length - dateTime.LastIndexOf('-'));
                return DateTime.ParseExact(dateTime, $"{DateTimeDefaults.DateTimeWithoutSec}{offset}", null);
            }

            if (dateTime.Contains('Z'))
            {
                return DateTime.ParseExact(dateTime, DateTimeDefaults.UtcDateTimeFormat, null);
            }

            if (dateTime.Contains('T'))
            {
                return DateTime.ParseExact(dateTime, DateTimeDefaults.FullLocalDateTimeFormat, null);
            }

            return DateTime.ParseExact(dateTime, DateTimeDefaults.DateOnlyFormat, null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
