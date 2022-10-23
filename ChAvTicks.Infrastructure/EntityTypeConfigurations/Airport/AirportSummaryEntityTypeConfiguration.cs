using ChAvTicks.Domain.Entities.Airport;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChAvTicks.Infrastructure.EntityTypeConfigurations.Airport
{
    public class AirportSummaryEntityTypeConfiguration : IEntityTypeConfiguration<AirportSummaryEntity>
    {
        public void Configure(EntityTypeBuilder<AirportSummaryEntity> builder)
        {
            builder.HasIndex(i => i.Icao);
            builder.HasIndex(i => i.FullName);
            builder.HasIndex(i => i.LocationId);

            builder.HasOne(l => l.Location)
                .WithOne(s => s.AirportSummary)
                .HasForeignKey<AirportLocationEntity>(k => k.AirportSummaryId);
        }
    }
}
