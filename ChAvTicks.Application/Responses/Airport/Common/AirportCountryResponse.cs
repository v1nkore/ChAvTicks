namespace ChAvTicks.Application.Responses.Airport.Common
{
    [Serializable]
    public sealed record AirportCountryResponse(
        string Code,
        string? Name);
}
