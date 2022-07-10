namespace ChAvTicks.Application.Configuration
{
    public static class FlightApiConstants
    {
        public static class Endpoints
        {
            public const string Flight = "https://aerodatabox.p.rapidapi.com/flights";
        }

        public static class HeaderKeys
        {
            public const string ApiKey = "X-RapidAPI-Key";
            public const string ApiHost = "X-RapidAPI-Host";
        }
    }
}
