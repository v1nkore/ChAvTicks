using System.Net.Http.Headers;

namespace ChAvTicks.Application.Interfaces
{
	public interface IRequestBuilder
	{
		HttpRequestMessage Build(HttpMethod httpMethod, Uri uri, HttpHeaders? headers = null, HttpContent? content = null);
	}
}
