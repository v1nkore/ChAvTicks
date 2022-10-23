using ChAvTicks.Domain.Entities.Base;

namespace ChAvTicks.Domain.Entities.Flight
{
    public class AircraftEntity : IEntity
    {
        public Guid Id { get; set; }
        public string? Registration { get; set; }
        public string? ModeS { get; set; }
        public string? Model { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
