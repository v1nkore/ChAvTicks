using System.Net;
using System.Text.Json;
using ChAvTicks.Application.JsonConverters;
using ChAvTicks.Shared.ServiceResponses;

namespace ChAvTicks.Application.HttpRequests
{
    public static class ResponseHandler
    {
        public static async Task<ModelResponseWithError<T?, string>?> HandleAsync<T>(HttpResponseMessage responseMessage) where T : class?
        {
            if (responseMessage.IsSuccessStatusCode)
            {
                var body = await responseMessage.Content.ReadAsStreamAsync();
                var result = await JsonSerializer.DeserializeAsync<T?>(body,
                    new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        Converters =
                        {
                            new DateTimeConverter(),
                        },
                    });

                return new ModelResponseWithError<T?, string> { Model = result };
            }
            if (responseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                var message = await responseMessage.Content.ReadAsStringAsync();
                return new ModelResponseWithError<T?, string>
                {
                    ErrorMessage = message
                };
            }

            return null;
        }
    }
}
