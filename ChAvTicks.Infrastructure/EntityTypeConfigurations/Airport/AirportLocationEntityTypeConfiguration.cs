using ChAvTicks.Domain.Entities.Airport;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChAvTicks.Infrastructure.EntityTypeConfigurations.Airport
{
    public class AirportLocationEntityTypeConfiguration : IEntityTypeConfiguration<AirportLocationEntity>
    {
        public void Configure(EntityTypeBuilder<AirportLocationEntity> builder)
        {
            builder.Property(p => p.Latitude).IsRequired();
            builder.Property(p => p.Longitude).IsRequired();

            builder.HasOne(s => s.AirportSummary)
                .WithOne(l => l.Location)
                .HasForeignKey<AirportSummaryEntity>(k => k.LocationId);
        }
    }
}
