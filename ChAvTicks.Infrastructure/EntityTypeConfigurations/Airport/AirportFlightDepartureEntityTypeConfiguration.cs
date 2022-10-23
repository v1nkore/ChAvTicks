using ChAvTicks.Domain.Entities.Airport;
using ChAvTicks.Domain.Entities.Flight;
using ChAvTicks.Domain.Enums.Flight;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChAvTicks.Infrastructure.EntityTypeConfigurations.Airport
{
    public class AirportFlightDepartureEntityTypeConfiguration : IEntityTypeConfiguration<AirportFlightDepartureEntity>
    {
        public void Configure(EntityTypeBuilder<AirportFlightDepartureEntity> builder)
        {
            builder.HasIndex(i => i.Number);
            builder.HasIndex(i => i.AirportScheduleId);
            builder.HasIndex(i => i.ArrivalId);
            builder.HasIndex(i => i.AircraftId);
            builder.HasIndex(i => i.DepartureId);
            builder.HasIndex(i => i.AirlineId);
            builder.HasIndex(i => i.LocationId);

            builder.Property(p => p.Status)
                .HasConversion(
                v => v.ToString(),
                v => (FlightStatus)Enum.Parse(typeof(FlightStatus), v));

            builder.Property(p => p.CodeshareStatus)
                .HasConversion(
                v => v.ToString(),
                v => (CodeshareStatus)Enum.Parse(typeof(CodeshareStatus), v));

            builder.Property(p => p.Number).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.CodeshareStatus).IsRequired();
            builder.Property(p => p.IsCargo).IsRequired();

            builder.HasOne(d => d.Departure)
                .WithOne(e => e.AirportFlightDeparture)
                .HasForeignKey<FlightDepartureEntity>(k => k.AirportFlightDepartureId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Arrival)
                .WithOne(e => e.AirportFlightDeparture)
                .HasForeignKey<FlightArrivalEntity>(k => k.AirportFlightDepartureId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.Location)
                .WithOne(e => e.AirportFlightDeparture)
                .HasForeignKey<FlightLocationEntity>(k => k.AirportFlightDepartureId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
