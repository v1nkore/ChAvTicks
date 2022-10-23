using ChAvTicks.Domain.Entities.Airport;
using ChAvTicks.Domain.Entities.Base;
using ChAvTicks.Domain.Entities.Flight;
using ChAvTicks.Infrastructure.EntityTypeConfigurations.Airport;
using Microsoft.EntityFrameworkCore;

namespace ChAvTicks.Infrastructure.Persistence
{
    public class ApplicationStorage : DbContext
    {
        public DbSet<AirportScheduleEntity> AirportSchedules { get; set; }
        public DbSet<AirportFlightDepartureEntity> AirportFlightDepartures { get; set; }
        public DbSet<AirportFlightArrivalEntity> AirportFlightArrivals { get; set; }
        public DbSet<FlightDepartureEntity> FlightDepartures { get; set; }
        public DbSet<FlightArrivalEntity> FlightArrivals { get; set; }
        public DbSet<AirportEntity> Airports { get; set; }
        public DbSet<AirportLocationEntity> AirportLocations { get; set; }
        public DbSet<AirportSummaryEntity> AirportSummaries { get; set; }
        public DbSet<AircraftEntity> Aircrafts { get; set; }
        public DbSet<AirlineEntity> Airlines { get; set; }
        public DbSet<FlightLocationEntity> FlightLocations { get; set; }

        public ApplicationStorage(DbContextOptions<ApplicationStorage> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AirportEntityTypeConfiguration).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IEntity).IsAssignableFrom(entityType.ClrType) && !entityType.ClrType.Name.EndsWith("Base"))
                {
                    modelBuilder.Entity(entityType.ClrType).HasKey("Id");
                    modelBuilder.Entity(entityType.ClrType).Property(nameof(IEntity.Id)).ValueGeneratedOnAdd();
                    modelBuilder.Entity(entityType.ClrType).Property(nameof(IEntity.CreatedAt)).HasDefaultValueSql("NOW()");
                    modelBuilder.Entity(entityType.ClrType).Property(nameof(IEntity.ModifiedAt)).HasDefaultValueSql("NOW()");

                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
