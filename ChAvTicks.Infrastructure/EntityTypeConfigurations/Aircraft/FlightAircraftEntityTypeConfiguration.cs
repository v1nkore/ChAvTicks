using ChAvTicks.Domain.Entities.Flight;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChAvTicks.Infrastructure.EntityTypeConfigurations.Aircraft
{
    public class FlightAircraftEntityTypeConfiguration
    {
        public void Configure(EntityTypeBuilder<AircraftEntity> builder)
        {
        }
    }
}
