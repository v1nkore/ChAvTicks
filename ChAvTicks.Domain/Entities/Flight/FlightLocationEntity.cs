using ChAvTicks.Domain.Entities.Airport;
using ChAvTicks.Domain.Entities.Base;

namespace ChAvTicks.Domain.Entities.Flight
{
    public class FlightLocationEntity : LocationEntityBase, IEntity
    {
        public Guid Id { get; set; }
        public int PressureAltFeet { get; set; }
        public int GroundSpeed { get; set; }
        public int TrackDegrees { get; set; }
        public DateTime ReportedAtUtc { get; set; }
        public Guid? AirportFlightDepartureId { get; set; }
        public AirportFlightDepartureEntity? AirportFlightDeparture { get; set; }
        public Guid? AirportFlightArrivalId { get; set; }
        public AirportFlightArrivalEntity? AirportFlightArrival { get; set; }
    }
}
