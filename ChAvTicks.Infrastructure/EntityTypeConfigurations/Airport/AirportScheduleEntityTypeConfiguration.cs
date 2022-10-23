using ChAvTicks.Domain.Entities.Airport;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChAvTicks.Infrastructure.EntityTypeConfigurations.Airport
{
    public class AirportScheduleEntityTypeConfiguration : IEntityTypeConfiguration<AirportScheduleEntity>
    {
        public void Configure(EntityTypeBuilder<AirportScheduleEntity> builder)
        {
            builder.Property(p => p.Icao).IsRequired();

            builder.HasMany(d => d.FlightDepartures)
                .WithOne(s => s.AirportSchedule)
                .HasForeignKey(k => k.AirportScheduleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(a => a.FlightArrivals)
                .WithOne(s => s.AirportSchedule)
                .HasForeignKey(k => k.AirportScheduleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
