namespace ChAvTicks.Application.Responses.Airport.Common
{
    [Serializable]
    public sealed record AirportContinentResponse(
        string Code,
        string? Name);
}
