using System.Text.Json;
using ChAvTicks.Application.DateTimeConverter;

namespace ChAvTicks.Application.HttpRequests
{
    public class ResponseHandler
    {
        public static async Task<T?> HandleAsync<T>(HttpResponseMessage response) where T : class?
        {
            T? result = null;
            if (response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStreamAsync();
                result = await JsonSerializer.DeserializeAsync<T?>(body,
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        Converters = { new CustomDateTimeConverter() },
                    });
            }

            return result;
        }
    }
}
