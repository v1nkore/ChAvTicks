using ChAvTicks.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChAvTicks.Infrastructure.EntityTypeConfigurations.Base
{
	public class LocationEntityTypeConfigurationBase<TLocation>
	{
		public void Configure(EntityTypeBuilder<LocationEntityBase> builder)
		{
			builder.Property(p => p.Latitude).IsRequired();
			builder.Property(p => p.Longitude).IsRequired();
		}
	}
}
