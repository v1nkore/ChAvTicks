using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChAvTicks.Domain.Entities
{
    public class AirportEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Icao { get; set; }
        public string Iata { get; set; }
        public string Location { get; set; }
        public string Airport { get; set; }
        public string Country { get; set; }
    }
}
