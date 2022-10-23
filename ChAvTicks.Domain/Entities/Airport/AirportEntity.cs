using ChAvTicks.Domain.Entities.Base;

namespace ChAvTicks.Domain.Entities.Airport
{
    public class AirportEntity : IEntity
    {
        public Guid Id { get; set; }
        public string? Icao { get; set; }
        public string? Iata { get; set; }
        public string? Location { get; set; }
        public string? Airport { get; set; }
        public string? Country { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
