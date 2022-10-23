using ChAvTicks.Application.HttpRequests;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Domain.ServiceResponses;
using System.Net.Http.Headers;

namespace ChAvTicks.Application.Helpers
{
	public static class HttpHelper
	{
		public static async Task<HttpResponseMessage> SendRequestAsync(HttpClient httpClient, HttpRequestMessage httpRequest)
		{
			return await httpClient.SendAsync(httpRequest);
		}

		public static async Task<ModelResponseWithError<TResult?, string>?> HandleResponse<TResult>(HttpResponseMessage httpResponse) where TResult : class?
		{
			return await ResponseHandler.HandleAsync<TResult?>(httpResponse);
		}

		public static async Task<ModelResponseWithError<TResult?, string>?> ExecuteHttpRequestAsync<TResult>(this HttpClient httpClient, IRequestBuilder builder, HttpMethod method, Uri uri, HttpRequestHeaders? headers = null, HttpContent? content = null) where TResult : class?
		{
			var request = builder.Build(method, uri, headers, content);
			var response = await SendRequestAsync(httpClient, request);
			return await HandleResponse<TResult?>(response);
		}
	}
}
