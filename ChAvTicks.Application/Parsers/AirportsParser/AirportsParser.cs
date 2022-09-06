using System.Diagnostics;
using ChAvTicks.Domain.Entities;
using ChAvTicks.Infrastructure.Persistence;
using HtmlAgilityPack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ChAvTicks.Application.Parsers.AirportsParser
{
    public class AirportsParser : IHostedService, IDisposable
    {
        private int _executionCount = 0;
        private Timer? _timer;
        private readonly ILogger<AirportsParser> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AirportsParser(ILogger<AirportsParser> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public void Update(object? state)
        {
            var stopwatch = Stopwatch.StartNew();

            var url = "http://www.flugzeuginfo.net/table_airportcodes_country-location_en.php?sort=iata";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            int.TryParse(
                doc.DocumentNode.SelectSingleNode("/html/body/main/div/div/section[2]/article/div/div[1]/p[1]/b[2]")
                .InnerText, out int updatedAirportCount);

            int currentAirportCount;
            List<AirportEntity> existedAirports;
            List<AirportEntity> additionAirports = new List<AirportEntity>();
            using (var scope = _serviceProvider.CreateScope())
            {
                var store = scope.ServiceProvider.GetRequiredService<ApplicationStore>();
                currentAirportCount = store.Airports.Count();
                existedAirports = store.Airports.ToList();
            }

            if (currentAirportCount != updatedAirportCount)
            {
                var tables = doc.DocumentNode.SelectNodes("//table");

                foreach (var table in tables)
                {
                    var airportsTable = table.Descendants("tr").Skip(1)
                        .Where(tr => tr.Elements("td").Any())
                        .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                        .ToList();

                    if (currentAirportCount < updatedAirportCount)
                    {
                        foreach (var airport in airportsTable)
                        {
                            if (!existedAirports.Any(x => CompareAirportInstances(x, airport)))
                            {
                                var mapped = MapToAirportSearchParamsEntity(airport);
                                existedAirports.Add(mapped);
                                additionAirports.Add(mapped);
                            }
                        }
                    }
                    else
                    {
                        foreach (var airport in airportsTable)
                        {
                            if (!airport.Any(l => existedAirports.Any(r => CompareAirportInstances(r, airport))))
                            {
                                additionAirports.Add(existedAirports.First(x => CompareAirportInstances(x, airport)));
                            }
                        }
                    }
                }

                if (currentAirportCount < updatedAirportCount)
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var store = scope.ServiceProvider.GetRequiredService<ApplicationStore>();
                        store.Airports.AddRange(additionAirports);

                        store.SaveChanges();
                    }
                }
                else
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var store = scope.ServiceProvider.GetRequiredService<ApplicationStore>();
                        var extraAirports = new List<AirportEntity>();

                        foreach (var entity in additionAirports)
                        {
                            extraAirports = store.Airports.AsEnumerable()
                                .Where(x => CompareAirportInstances(x, new List<string>
                                    { entity.Iata, entity.Icao, entity.Location, entity.Airport, entity.Country })).ToList();
                        }

                        store.Airports.RemoveRange(extraAirports);
                        store.SaveChanges();
                    }
                }
            }

            _logger.LogInformation("Execution time: {TimeSpan}", stopwatch.Elapsed);

            var count = Interlocked.Increment(ref _executionCount);

            _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);

            stopwatch.Stop();
        }

        private static AirportEntity MapToAirportSearchParamsEntity(List<string> values)
        {
            return new AirportEntity()
            {
                Iata = values[0],
                Icao = values[1],
                Location = values[2],
                Airport = values[3],
                Country = values[4],
            };
        }

        private static bool CompareAirportInstances(AirportEntity entity, List<string> values)
        {
            return entity.Iata == values[0]
                   && entity.Icao == values[1]
                   && entity.Location == values[2]
                   && entity.Airport == values[3]
                   && entity.Country == values[4];
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start updating information about existed airports");

            _timer = new Timer(Update, null, TimeSpan.Zero, TimeSpan.FromDays(7));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stop updating information about existed airports");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}