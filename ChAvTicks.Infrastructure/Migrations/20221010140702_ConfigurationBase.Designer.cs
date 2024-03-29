﻿// <auto-generated />
using System;
using ChAvTicks.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChAvTicks.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationStorage))]
    [Migration("20221010140702_ConfigurationBase")]
    partial class ConfigurationBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Airport.AirportEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Airport")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Iata")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Icao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.HasIndex("Airport");

                    b.HasIndex("Country");

                    b.HasIndex("Location");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Airport.AirportFlightArrivalEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AircraftId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AirlineId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AirportScheduleId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ArrivalId")
                        .HasColumnType("uuid");

                    b.Property<string>("CallSign")
                        .HasColumnType("text");

                    b.Property<string>("CodeshareStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid?>("DepartureId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsCargo")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AircraftId");

                    b.HasIndex("AirlineId");

                    b.HasIndex("AirportScheduleId");

                    b.HasIndex("ArrivalId");

                    b.HasIndex("DepartureId");

                    b.HasIndex("LocationId");

                    b.HasIndex("Number");

                    b.ToTable("AirportFlightArrivals");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Airport.AirportFlightDepartureEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AircraftId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AirlineId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AirportScheduleId")
                        .IsRequired()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ArrivalId")
                        .HasColumnType("uuid");

                    b.Property<string>("CallSign")
                        .HasColumnType("text");

                    b.Property<string>("CodeshareStatus")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<Guid?>("DepartureId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsCargo")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AircraftId");

                    b.HasIndex("AirlineId");

                    b.HasIndex("AirportScheduleId");

                    b.HasIndex("ArrivalId");

                    b.HasIndex("DepartureId");

                    b.HasIndex("LocationId");

                    b.HasIndex("Number");

                    b.ToTable("AirportFlightDepartures");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Airport.AirportLocationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AirportSummaryId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.HasIndex("AirportSummaryId")
                        .IsUnique();

                    b.ToTable("AirportLocations");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Airport.AirportScheduleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Icao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.HasKey("Id");

                    b.ToTable("AirportSchedules");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Airport.AirportSummaryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CountryCode")
                        .HasColumnType("text");

                    b.Property<string>("CountryName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("Iata")
                        .HasColumnType("text");

                    b.Property<string>("Icao")
                        .HasColumnType("text");

                    b.Property<string>("LocalCode")
                        .HasColumnType("text");

                    b.Property<Guid?>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("MunicipalityName")
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .HasColumnType("text");

                    b.Property<string[]>("Urls")
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.HasIndex("FullName");

                    b.HasIndex("Icao");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.ToTable("AirportSummaries");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Flight.AircraftEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("ModeS")
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Registration")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Flight.AirlineEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Flight.FlightArrivalEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ActualTimeLocal")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ActualTimeUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("AirportFlightArrivalId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AirportFlightDepartureId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AirportSummaryId")
                        .HasColumnType("uuid");

                    b.Property<string>("BaggageBelt")
                        .HasColumnType("text");

                    b.Property<string>("CheckInDesk")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Gate")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string[]>("Quality")
                        .HasColumnType("text[]");

                    b.Property<string>("Runway")
                        .HasColumnType("text");

                    b.Property<string>("RunwayTimeLocal")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RunwayTimeUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ScheduledTimeLocal")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ScheduledTimeUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Terminal")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AirportFlightArrivalId")
                        .IsUnique();

                    b.HasIndex("AirportFlightDepartureId")
                        .IsUnique();

                    b.HasIndex("AirportSummaryId");

                    b.HasIndex("ScheduledTimeLocal");

                    b.HasIndex("ScheduledTimeUtc");

                    b.ToTable("FlightArrivals");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Flight.FlightDepartureEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ActualTimeLocal")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ActualTimeUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("AirportFlightArrivalId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AirportFlightDepartureId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AirportSummaryId")
                        .HasColumnType("uuid");

                    b.Property<string>("BaggageBelt")
                        .HasColumnType("text");

                    b.Property<string>("CheckInDesk")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string>("Gate")
                        .HasColumnType("text");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<string[]>("Quality")
                        .HasColumnType("text[]");

                    b.Property<string>("Runway")
                        .HasColumnType("text");

                    b.Property<string>("RunwayTimeLocal")
                        .HasColumnType("text");

                    b.Property<DateTime?>("RunwayTimeUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ScheduledTimeLocal")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ScheduledTimeUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Terminal")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AirportFlightArrivalId")
                        .IsUnique();

                    b.HasIndex("AirportFlightDepartureId")
                        .IsUnique();

                    b.HasIndex("AirportSummaryId");

                    b.HasIndex("ScheduledTimeLocal");

                    b.HasIndex("ScheduledTimeUtc");

                    b.ToTable("FlightDepartures");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Flight.FlightLocationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AirportFlightArrivalId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("AirportFlightDepartureId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("GroundSpeed")
                        .HasColumnType("integer");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("ModifiedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("NOW()");

                    b.Property<int>("PressureAltFeet")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReportedAtUtc")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TrackDegrees")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AirportFlightArrivalId")
                        .IsUnique();

                    b.HasIndex("AirportFlightDepartureId")
                        .IsUnique();

                    b.ToTable("FlightLocations");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Airport.AirportFlightArrivalEntity", b =>
                {
                    b.HasOne("ChAvTicks.Domain.Entities.Flight.AircraftEntity", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftId");

                    b.HasOne("ChAvTicks.Domain.Entities.Flight.AirlineEntity", "Airline")
                        .WithMany()
                        .HasForeignKey("AirlineId");

                    b.HasOne("ChAvTicks.Domain.Entities.Airport.AirportScheduleEntity", "AirportSchedule")
                        .WithMany("FlightArrivals")
                        .HasForeignKey("AirportScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");

                    b.Navigation("Airline");

                    b.Navigation("AirportSchedule");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Airport.AirportFlightDepartureEntity", b =>
                {
                    b.HasOne("ChAvTicks.Domain.Entities.Flight.AircraftEntity", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftId");

                    b.HasOne("ChAvTicks.Domain.Entities.Flight.AirlineEntity", "Airline")
                        .WithMany()
                        .HasForeignKey("AirlineId");

                    b.HasOne("ChAvTicks.Domain.Entities.Airport.AirportScheduleEntity", "AirportSchedule")
                        .WithMany("FlightDepartures")
                        .HasForeignKey("AirportScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aircraft");

                    b.Navigation("Airline");

                    b.Navigation("AirportSchedule");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Airport.AirportLocationEntity", b =>
                {
                    b.HasOne("ChAvTicks.Domain.Entities.Airport.AirportSummaryEntity", "AirportSummary")
                        .WithOne("Location")
                        .HasForeignKey("ChAvTicks.Domain.Entities.Airport.AirportLocationEntity", "AirportSummaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AirportSummary");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Flight.FlightArrivalEntity", b =>
                {
                    b.HasOne("ChAvTicks.Domain.Entities.Airport.AirportFlightArrivalEntity", "AirportFlightArrival")
                        .WithOne("Arrival")
                        .HasForeignKey("ChAvTicks.Domain.Entities.Flight.FlightArrivalEntity", "AirportFlightArrivalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChAvTicks.Domain.Entities.Airport.AirportFlightDepartureEntity", "AirportFlightDeparture")
                        .WithOne("Arrival")
                        .HasForeignKey("ChAvTicks.Domain.Entities.Flight.FlightArrivalEntity", "AirportFlightDepartureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChAvTicks.Domain.Entities.Airport.AirportSummaryEntity", "AirportSummary")
                        .WithMany()
                        .HasForeignKey("AirportSummaryId");

                    b.Navigation("AirportFlightArrival");

                    b.Navigation("AirportFlightDeparture");

                    b.Navigation("AirportSummary");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Flight.FlightDepartureEntity", b =>
                {
                    b.HasOne("ChAvTicks.Domain.Entities.Airport.AirportFlightArrivalEntity", "AirportFlightArrival")
                        .WithOne("Departure")
                        .HasForeignKey("ChAvTicks.Domain.Entities.Flight.FlightDepartureEntity", "AirportFlightArrivalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChAvTicks.Domain.Entities.Airport.AirportFlightDepartureEntity", "AirportFlightDeparture")
                        .WithOne("Departure")
                        .HasForeignKey("ChAvTicks.Domain.Entities.Flight.FlightDepartureEntity", "AirportFlightDepartureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChAvTicks.Domain.Entities.Airport.AirportSummaryEntity", "AirportSummary")
                        .WithMany()
                        .HasForeignKey("AirportSummaryId");

                    b.Navigation("AirportFlightArrival");

                    b.Navigation("AirportFlightDeparture");

                    b.Navigation("AirportSummary");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Flight.FlightLocationEntity", b =>
                {
                    b.HasOne("ChAvTicks.Domain.Entities.Airport.AirportFlightArrivalEntity", "AirportFlightArrival")
                        .WithOne("Location")
                        .HasForeignKey("ChAvTicks.Domain.Entities.Flight.FlightLocationEntity", "AirportFlightArrivalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ChAvTicks.Domain.Entities.Airport.AirportFlightDepartureEntity", "AirportFlightDeparture")
                        .WithOne("Location")
                        .HasForeignKey("ChAvTicks.Domain.Entities.Flight.FlightLocationEntity", "AirportFlightDepartureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("AirportFlightArrival");

                    b.Navigation("AirportFlightDeparture");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Airport.AirportFlightArrivalEntity", b =>
                {
                    b.Navigation("Arrival");

                    b.Navigation("Departure");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Airport.AirportFlightDepartureEntity", b =>
                {
                    b.Navigation("Arrival");

                    b.Navigation("Departure");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Airport.AirportScheduleEntity", b =>
                {
                    b.Navigation("FlightArrivals");

                    b.Navigation("FlightDepartures");
                });

            modelBuilder.Entity("ChAvTicks.Domain.Entities.Airport.AirportSummaryEntity", b =>
                {
                    b.Navigation("Location");
                });
#pragma warning restore 612, 618
        }
    }
}
