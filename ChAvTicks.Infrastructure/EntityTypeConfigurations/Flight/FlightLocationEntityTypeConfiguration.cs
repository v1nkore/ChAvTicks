using ChAvTicks.Domain.Entities.Flight;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChAvTicks.Infrastructure.EntityTypeConfigurations.Flight
{
    public class FlightLocationEntityTypeConfiguration : IEntityTypeConfiguration<FlightLocationEntity>
    {
        public void Configure(EntityTypeBuilder<FlightLocationEntity> builder)
        {
            builder.HasIndex(i => i.AirportFlightArrivalId);
            builder.HasIndex(i => i.AirportFlightDepartureId);

            builder.Property(p => p.Latitude).IsRequired();
            builder.Property(p => p.Longitude).IsRequired();
            builder.Property(p => p.PressureAltFeet).IsRequired();
            builder.Property(p => p.GroundSpeed).IsRequired();
            builder.Property(p => p.TrackDegrees).IsRequired();
            builder.Property(p => p.ReportedAtUtc).IsRequired();
        }
    }
}
