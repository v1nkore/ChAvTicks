using System.ComponentModel.DataAnnotations;

namespace ChAvTicks.Domain.Entities
{
    public class AirportSearchParamsEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
        public string Location { get; set; }
        public string Airport { get; set; }
        public string Country { get; set; }
    }
}
