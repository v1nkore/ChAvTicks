using ChAvTicks.Domain.Entities.Airport;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChAvTicks.Infrastructure.EntityTypeConfigurations.Airport
{
    public class AirportEntityTypeConfiguration : IEntityTypeConfiguration<AirportEntity>
    {
        public void Configure(EntityTypeBuilder<AirportEntity> builder)
        {
            builder.HasIndex(i => i.Airport);
            builder.HasIndex(i => i.Location);
            builder.HasIndex(i => i.Country);

            builder.Property(p => p.Iata).IsRequired();
            builder.Property(p => p.Icao).IsRequired();
            builder.Property(p => p.Airport).IsRequired();
            builder.Property(p => p.Country).IsRequired();
            builder.Property(p => p.Location).IsRequired();
        }
    }
}
