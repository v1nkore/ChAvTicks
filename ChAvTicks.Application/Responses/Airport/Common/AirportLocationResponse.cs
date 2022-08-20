using ChAvTicks.Application.Responses.Base;

namespace ChAvTicks.Application.Responses.Airport.Common
{
    [Serializable]
    public sealed record AirportLocationResponse(
        double Latitude,
        double Longitude) : LocationResponseBase(Latitude, Longitude);
}
