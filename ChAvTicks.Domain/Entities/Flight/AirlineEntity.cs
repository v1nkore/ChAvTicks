using ChAvTicks.Domain.Entities.Base;

namespace ChAvTicks.Domain.Entities.Flight
{
    public class AirlineEntity : IEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
