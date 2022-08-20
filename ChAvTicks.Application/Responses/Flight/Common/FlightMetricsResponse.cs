namespace ChAvTicks.Application.Responses.Flight.Common
{
    [Serializable]
    public sealed record FlightMetricsResponse(
        double Meter,
        double Km,
        double Mile,
        double NauticalMile,
        double Feet);
}
