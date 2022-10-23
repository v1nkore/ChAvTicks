using ChAvTicks.Domain.Entities.Flight;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChAvTicks.Infrastructure.EntityTypeConfigurations.Flight
{
    public class AirlineEntityTypeConfiguration : IEntityTypeConfiguration<AirlineEntity>
    {
        public void Configure(EntityTypeBuilder<AirlineEntity> builder)
        {
            builder.HasIndex(i => i.Name);

            builder.Property(p => p.Name).IsRequired();
        }
    }
}
