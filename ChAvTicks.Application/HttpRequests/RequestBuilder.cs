using ChAvTicks.Application.Configuration;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace ChAvTicks.Application.HttpRequests
{
    public static class RequestBuilder
    {
        public static HttpRequestMessage CreateFlightRequest(HttpMethod httpMethod, Uri uri, IOptions<FlightApiSettings> flightApiSettings, HttpHeaders? headers = null)
        {
            var request = new HttpRequestMessage()
            {
                Method = httpMethod,
                RequestUri = uri,
                Headers =
                {
                    {FlightApiConstants.HeaderKeys.ApiKey, flightApiSettings.Value.Key},
                    {FlightApiConstants.HeaderKeys.ApiHost, flightApiSettings.Value.Host},
                },
            };

            if (headers is not null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            return request;
        }
    }
}
