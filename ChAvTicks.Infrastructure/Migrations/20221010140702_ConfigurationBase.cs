using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChAvTicks.Infrastructure.Migrations
{
    public partial class ConfigurationBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Registration = table.Column<string>(type: "text", nullable: true),
                    ModeS = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airlines",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airlines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Icao = table.Column<string>(type: "text", nullable: false),
                    Iata = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Airport = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirportSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Icao = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportSchedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirportSummaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Icao = table.Column<string>(type: "text", nullable: true),
                    Iata = table.Column<string>(type: "text", nullable: true),
                    LocalCode = table.Column<string>(type: "text", nullable: true),
                    FullName = table.Column<string>(type: "text", nullable: true),
                    ShortName = table.Column<string>(type: "text", nullable: true),
                    MunicipalityName = table.Column<string>(type: "text", nullable: true),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: true),
                    CountryCode = table.Column<string>(type: "text", nullable: true),
                    CountryName = table.Column<string>(type: "text", nullable: true),
                    Urls = table.Column<string[]>(type: "text[]", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportSummaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirportFlightArrivals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Number = table.Column<string>(type: "text", nullable: false),
                    CallSign = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CodeshareStatus = table.Column<string>(type: "text", nullable: false),
                    IsCargo = table.Column<bool>(type: "boolean", nullable: false),
                    AirportScheduleId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartureId = table.Column<Guid>(type: "uuid", nullable: true),
                    ArrivalId = table.Column<Guid>(type: "uuid", nullable: true),
                    AircraftId = table.Column<Guid>(type: "uuid", nullable: true),
                    AirlineId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportFlightArrivals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirportFlightArrivals_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AirportFlightArrivals_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AirportFlightArrivals_AirportSchedules_AirportScheduleId",
                        column: x => x.AirportScheduleId,
                        principalTable: "AirportSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AirportFlightDepartures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Number = table.Column<string>(type: "text", nullable: false),
                    CallSign = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CodeshareStatus = table.Column<string>(type: "text", nullable: false),
                    IsCargo = table.Column<bool>(type: "boolean", nullable: false),
                    AirportScheduleId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartureId = table.Column<Guid>(type: "uuid", nullable: true),
                    ArrivalId = table.Column<Guid>(type: "uuid", nullable: true),
                    AircraftId = table.Column<Guid>(type: "uuid", nullable: true),
                    AirlineId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportFlightDepartures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirportFlightDepartures_Aircrafts_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircrafts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AirportFlightDepartures_Airlines_AirlineId",
                        column: x => x.AirlineId,
                        principalTable: "Airlines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AirportFlightDepartures_AirportSchedules_AirportScheduleId",
                        column: x => x.AirportScheduleId,
                        principalTable: "AirportSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AirportLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AirportSummaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirportLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirportLocations_AirportSummaries_AirportSummaryId",
                        column: x => x.AirportSummaryId,
                        principalTable: "AirportSummaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlightArrivals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ScheduledTimeLocal = table.Column<string>(type: "text", nullable: true),
                    ActualTimeLocal = table.Column<string>(type: "text", nullable: true),
                    RunwayTimeLocal = table.Column<string>(type: "text", nullable: true),
                    ScheduledTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActualTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RunwayTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Terminal = table.Column<string>(type: "text", nullable: true),
                    CheckInDesk = table.Column<string>(type: "text", nullable: true),
                    Gate = table.Column<string>(type: "text", nullable: true),
                    BaggageBelt = table.Column<string>(type: "text", nullable: true),
                    Runway = table.Column<string>(type: "text", nullable: true),
                    Quality = table.Column<string[]>(type: "text[]", nullable: true),
                    AirportFlightDepartureId = table.Column<Guid>(type: "uuid", nullable: true),
                    AirportFlightArrivalId = table.Column<Guid>(type: "uuid", nullable: true),
                    AirportSummaryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightArrivals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightArrivals_AirportFlightArrivals_AirportFlightArrivalId",
                        column: x => x.AirportFlightArrivalId,
                        principalTable: "AirportFlightArrivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightArrivals_AirportFlightDepartures_AirportFlightDepartu~",
                        column: x => x.AirportFlightDepartureId,
                        principalTable: "AirportFlightDepartures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightArrivals_AirportSummaries_AirportSummaryId",
                        column: x => x.AirportSummaryId,
                        principalTable: "AirportSummaries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FlightDepartures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ScheduledTimeLocal = table.Column<string>(type: "text", nullable: true),
                    ActualTimeLocal = table.Column<string>(type: "text", nullable: true),
                    RunwayTimeLocal = table.Column<string>(type: "text", nullable: true),
                    ScheduledTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ActualTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RunwayTimeUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Terminal = table.Column<string>(type: "text", nullable: true),
                    CheckInDesk = table.Column<string>(type: "text", nullable: true),
                    Gate = table.Column<string>(type: "text", nullable: true),
                    BaggageBelt = table.Column<string>(type: "text", nullable: true),
                    Runway = table.Column<string>(type: "text", nullable: true),
                    Quality = table.Column<string[]>(type: "text[]", nullable: true),
                    AirportFlightDepartureId = table.Column<Guid>(type: "uuid", nullable: true),
                    AirportFlightArrivalId = table.Column<Guid>(type: "uuid", nullable: true),
                    AirportSummaryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDepartures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightDepartures_AirportFlightArrivals_AirportFlightArrival~",
                        column: x => x.AirportFlightArrivalId,
                        principalTable: "AirportFlightArrivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightDepartures_AirportFlightDepartures_AirportFlightDepar~",
                        column: x => x.AirportFlightDepartureId,
                        principalTable: "AirportFlightDepartures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightDepartures_AirportSummaries_AirportSummaryId",
                        column: x => x.AirportSummaryId,
                        principalTable: "AirportSummaries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FlightLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PressureAltFeet = table.Column<int>(type: "integer", nullable: false),
                    GroundSpeed = table.Column<int>(type: "integer", nullable: false),
                    TrackDegrees = table.Column<int>(type: "integer", nullable: false),
                    ReportedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AirportFlightDepartureId = table.Column<Guid>(type: "uuid", nullable: true),
                    AirportFlightArrivalId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlightLocations_AirportFlightArrivals_AirportFlightArrivalId",
                        column: x => x.AirportFlightArrivalId,
                        principalTable: "AirportFlightArrivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightLocations_AirportFlightDepartures_AirportFlightDepart~",
                        column: x => x.AirportFlightDepartureId,
                        principalTable: "AirportFlightDepartures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Airlines_Name",
                table: "Airlines",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlightArrivals_AircraftId",
                table: "AirportFlightArrivals",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlightArrivals_AirlineId",
                table: "AirportFlightArrivals",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlightArrivals_AirportScheduleId",
                table: "AirportFlightArrivals",
                column: "AirportScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlightArrivals_ArrivalId",
                table: "AirportFlightArrivals",
                column: "ArrivalId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlightArrivals_DepartureId",
                table: "AirportFlightArrivals",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlightArrivals_LocationId",
                table: "AirportFlightArrivals",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlightArrivals_Number",
                table: "AirportFlightArrivals",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlightDepartures_AircraftId",
                table: "AirportFlightDepartures",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlightDepartures_AirlineId",
                table: "AirportFlightDepartures",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlightDepartures_AirportScheduleId",
                table: "AirportFlightDepartures",
                column: "AirportScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlightDepartures_ArrivalId",
                table: "AirportFlightDepartures",
                column: "ArrivalId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlightDepartures_DepartureId",
                table: "AirportFlightDepartures",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlightDepartures_LocationId",
                table: "AirportFlightDepartures",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_AirportFlightDepartures_Number",
                table: "AirportFlightDepartures",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_AirportLocations_AirportSummaryId",
                table: "AirportLocations",
                column: "AirportSummaryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Airports_Airport",
                table: "Airports",
                column: "Airport");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_Country",
                table: "Airports",
                column: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_Airports_Location",
                table: "Airports",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_AirportSummaries_FullName",
                table: "AirportSummaries",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_AirportSummaries_Icao",
                table: "AirportSummaries",
                column: "Icao");

            migrationBuilder.CreateIndex(
                name: "IX_AirportSummaries_LocationId",
                table: "AirportSummaries",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightArrivals_AirportFlightArrivalId",
                table: "FlightArrivals",
                column: "AirportFlightArrivalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightArrivals_AirportFlightDepartureId",
                table: "FlightArrivals",
                column: "AirportFlightDepartureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightArrivals_AirportSummaryId",
                table: "FlightArrivals",
                column: "AirportSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightArrivals_ScheduledTimeLocal",
                table: "FlightArrivals",
                column: "ScheduledTimeLocal");

            migrationBuilder.CreateIndex(
                name: "IX_FlightArrivals_ScheduledTimeUtc",
                table: "FlightArrivals",
                column: "ScheduledTimeUtc");

            migrationBuilder.CreateIndex(
                name: "IX_FlightDepartures_AirportFlightArrivalId",
                table: "FlightDepartures",
                column: "AirportFlightArrivalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightDepartures_AirportFlightDepartureId",
                table: "FlightDepartures",
                column: "AirportFlightDepartureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightDepartures_AirportSummaryId",
                table: "FlightDepartures",
                column: "AirportSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightDepartures_ScheduledTimeLocal",
                table: "FlightDepartures",
                column: "ScheduledTimeLocal");

            migrationBuilder.CreateIndex(
                name: "IX_FlightDepartures_ScheduledTimeUtc",
                table: "FlightDepartures",
                column: "ScheduledTimeUtc");

            migrationBuilder.CreateIndex(
                name: "IX_FlightLocations_AirportFlightArrivalId",
                table: "FlightLocations",
                column: "AirportFlightArrivalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightLocations_AirportFlightDepartureId",
                table: "FlightLocations",
                column: "AirportFlightDepartureId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirportLocations");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "FlightArrivals");

            migrationBuilder.DropTable(
                name: "FlightDepartures");

            migrationBuilder.DropTable(
                name: "FlightLocations");

            migrationBuilder.DropTable(
                name: "AirportSummaries");

            migrationBuilder.DropTable(
                name: "AirportFlightArrivals");

            migrationBuilder.DropTable(
                name: "AirportFlightDepartures");

            migrationBuilder.DropTable(
                name: "Aircrafts");

            migrationBuilder.DropTable(
                name: "Airlines");

            migrationBuilder.DropTable(
                name: "AirportSchedules");
        }
    }
}
