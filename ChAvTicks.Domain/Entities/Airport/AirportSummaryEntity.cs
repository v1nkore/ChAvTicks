using ChAvTicks.Domain.Entities.Base;

namespace ChAvTicks.Domain.Entities.Airport
{
    public class AirportSummaryEntity : IEntity
    {
        public Guid Id { get; set; }
        public string? Icao { get; set; }
        public string? Iata { get; set; }
        public string? LocalCode { get; set; }
        public string? FullName { get; set; }
        public string? ShortName { get; set; }
        public string? MunicipalityName { get; set; }
        public Guid? LocationId { get; set; }
        public AirportLocationEntity? Location { get; set; }
        public string? CountryCode { get; set; }
        public string? CountryName { get; set; }
        public string[]? Urls { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
