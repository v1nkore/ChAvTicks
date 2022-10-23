using ChAvTicks.Domain.Entities.Base;

namespace ChAvTicks.Domain.Entities.Airport
{
    public class AirportLocationEntity : LocationEntityBase, IEntity
    {
        public Guid Id { get; set; }
        public Guid AirportSummaryId { get; set; }
        public AirportSummaryEntity? AirportSummary { get; set; }
    }
}
