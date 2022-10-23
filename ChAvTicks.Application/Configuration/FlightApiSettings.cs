namespace ChAvTicks.Application.Configuration
{
    public sealed class FlightApiSettings
    {
        public static string SectionName { get; } = "FlightApi";
        public string? Key { get; init; }
        public string? Host { get; init; }
    }
}
