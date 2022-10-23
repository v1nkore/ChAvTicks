using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace ChAvTicks.Application.HttpRequests
{
    public class RequestBuilder : IRequestBuilder
    {
        private readonly IOptions<FlightApiSettings> _flightApiSettings;

        public RequestBuilder(IOptions<FlightApiSettings> flightApiSettings)
        {
            _flightApiSettings = flightApiSettings;
        }

        public HttpRequestMessage Build(HttpMethod httpMethod, Uri uri, HttpHeaders? headers = null, HttpContent? content = null)
        {
            var request = new HttpRequestMessage()
            {
                Method = httpMethod,
                RequestUri = uri,
                Content = content,
            };

            if (uri.OriginalString.StartsWith(FlightApiEndpoints.BaseEndpoint))
            {
                request.Headers.Add(FlightApiEndpoints.HeaderKeys.ApiKey, _flightApiSettings.Value.Key);
                request.Headers.Add(FlightApiEndpoints.HeaderKeys.ApiHost, _flightApiSettings.Value.Host);
            }

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
