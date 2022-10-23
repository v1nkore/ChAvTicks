namespace ChAvTicks.Application.Configuration
{
    public static class FlightApiEndpoints
    {
        public const string BaseEndpoint = "https://aerodatabox.p.rapidapi.com";

        public static class FlightEndpoints
        {
            public const string BaseUrl = $"{BaseEndpoint}/flights";
            public const string AirportSchedule = $"{BaseUrl}/airports/icao";
        }

        public static class AirportEndpoints
        {
            public const string BaseUrl = $"{BaseEndpoint}/airports";
            public const string Icao = $"{BaseUrl}/icao";
            public const string SearchByLocation = $"{BaseUrl}/search/location";
            public const string SearchByText = $"{BaseUrl}/search/term";
        }

        public static class AircraftEndpoints
        {
            public const string BaseUrl = $"{BaseEndpoint}/aircrafts";
        }

        public static class HealthcheckEndpoints
        {
            public const string BaseUrl = $"{BaseEndpoint}/health/services";
            public const string Icao = $"{BaseUrl}/airports";
        }

        public static class HeaderKeys
        {
            public const string ApiKey = "X-RapidAPI-Key";
            public const string ApiHost = "X-RapidAPI-Host";
        }
    }
}
