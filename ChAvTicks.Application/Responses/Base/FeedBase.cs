using System.Text.Json.Serialization;
using ChAvTicks.Domain.Enums.Healthcheck;

namespace ChAvTicks.Application.Responses.Base
{
    public record FeedBase(
        [property: JsonConverter(typeof(JsonStringEnumConverter))]
        FeedService Service,
        string Status,
        DateTime? MinAvailableLocalDate,
        DateTime? MaxAvailableLocalDate);
}
