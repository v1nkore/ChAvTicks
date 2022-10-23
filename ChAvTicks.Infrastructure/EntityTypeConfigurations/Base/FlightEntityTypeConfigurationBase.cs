using ChAvTicks.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChAvTicks.Infrastructure.EntityTypeConfigurations.Base
{
	public class FlightEntityTypeConfigurationBase
	{
		public void Configure(EntityTypeBuilder<FlightEntityBase> builder)
		{
		}
	}
}
