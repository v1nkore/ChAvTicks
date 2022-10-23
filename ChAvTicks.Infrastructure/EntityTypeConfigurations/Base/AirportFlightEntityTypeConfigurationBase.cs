using ChAvTicks.Domain.Entities.Base;
using ChAvTicks.Domain.Enums.Flight;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChAvTicks.Infrastructure.EntityTypeConfigurations.Base
{
	public class AirportFlightEntityTypeConfigurationBase
	{
		public void Configure(EntityTypeBuilder<AirportFlightEntityBase> builder)
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
		}
	}
}
