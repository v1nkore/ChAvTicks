using ChAvTicks.Domain.Entities.Flight;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChAvTicks.Infrastructure.EntityTypeConfigurations.Flight
{
	public class ArrivalEntityTypeConfiguration : IEntityTypeConfiguration<FlightArrivalEntity>
	{
		public void Configure(EntityTypeBuilder<FlightArrivalEntity> builder)
		{
			builder.Property(p => p.ActualTimeLocal)
				.HasConversion(
				v => v!.Value.ToString(),
				v => DateTime.Parse(v).ToLocalTime());

			builder.Property(p => p.RunwayTimeLocal)
				.HasConversion(
				v => v!.Value.ToString(),
				v => DateTime.Parse(v).ToLocalTime());

			builder.Property(p => p.ScheduledTimeLocal)
				.HasConversion(
				v => v!.Value.ToString(),
				v => DateTime.Parse(v).ToLocalTime());

			builder.HasIndex(i => i.ScheduledTimeLocal);
			builder.HasIndex(i => i.ScheduledTimeUtc);
			builder.HasIndex(i => i.AirportFlightArrivalId);
			builder.HasIndex(i => i.AirportFlightDepartureId);
			builder.HasIndex(i => i.AirportSummaryId);
		}
	}
}
