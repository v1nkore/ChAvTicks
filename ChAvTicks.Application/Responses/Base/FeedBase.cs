using ChAvTicks.Domain.Enums.Healthcheck;
using System.Text.Json.Serialization;

namespace ChAvTicks.Application.Responses.Base
{
	public record FeedBase(
		[property: JsonConverter(typeof(JsonStringEnumConverter))]
		FeedService Service,
		string Status,
		DateTime? MinAvailableLocalDate,
		DateTime? MaxAvailableLocalDate);
}
