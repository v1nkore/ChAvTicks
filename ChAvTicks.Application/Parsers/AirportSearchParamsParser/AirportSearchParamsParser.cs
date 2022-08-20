using System.Diagnostics;
using ChAvTicks.Domain.Entities;
using ChAvTicks.Infrastructure.Persistence;
using HtmlAgilityPack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ChAvTicks.Application.Parsers.AirportSearchParamsParser
{
    public class AirportSearchParamsParser : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private Timer? _timer = null;
        private readonly ILogger<AirportSearchParamsParser> _logger;
        private readonly IServiceProvider _serviceProvider;

        public AirportSearchParamsParser(ILogger<AirportSearchParamsParser> logger, IServiceProvider serviceProvider)
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
                .InnerText, out int updatedEntityCount);

            int currentEntityCount;
            List<AirportSearchParamsEntity> existedEntities;
            List<AirportSearchParamsEntity> additionEntities = new List<AirportSearchParamsEntity>();
            using (var scope = _serviceProvider.CreateScope())
            {
                var store = scope.ServiceProvider.GetRequiredService<ApplicationStore>();
                currentEntityCount = store.AirportSearchParams.Count();
                existedEntities = store.AirportSearchParams.ToList();
            }

            if (currentEntityCount != updatedEntityCount)
            {
                var tables = doc.DocumentNode.SelectNodes("//table");

                List<List<string>>? singleAirportSummaryTable;
                foreach (var table in tables)
                {
                    singleAirportSummaryTable = table.Descendants("tr").Skip(1)
                        .Where(tr => tr.Elements("td").Any())
                        .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                        .ToList();

                    if (currentEntityCount < updatedEntityCount)
                    {
                        foreach (var summary in singleAirportSummaryTable)
                        {
                            if (!existedEntities.Any(x => CompareAirportInstances(x, summary)))
                            {
                                var mapped = MapToAirportSearchParamsEntity(summary);
                                existedEntities.Add(mapped);
                                additionEntities.Add(mapped);
                            }
                        }
                    }
                    else
                    {
                        foreach (var summary in singleAirportSummaryTable)
                        {
                            if (!summary.Any(l => existedEntities.Any(r => CompareAirportInstances(r, summary))))
                            {
                                additionEntities.Add(existedEntities.First(x => CompareAirportInstances(x, summary)));
                            }
                        }
                    }
                }

                if (currentEntityCount < updatedEntityCount)
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var store = scope.ServiceProvider.GetRequiredService<ApplicationStore>();
                        store.AirportSearchParams.AddRange(additionEntities);

                        var sameId =
                            additionEntities.FirstOrDefault(x => store.AirportSearchParams.Any(e => x.Id == e.Id));

                        store.SaveChanges();
                    }
                }
                else
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var store = scope.ServiceProvider.GetRequiredService<ApplicationStore>();
                        var extraEntities = new List<AirportSearchParamsEntity>();

                        var entities = store.AirportSearchParams.ToList();
                        foreach (var entity in additionEntities)
                        {
                            extraEntities = entities.Where(x => CompareAirportInstances(x,
                                    new List<string>
                                        { entity.Iata, entity.Icao, entity.Location, entity.Airport, entity.Country }))
                                .ToList();
                        }

                        store.AirportSearchParams.RemoveRange(extraEntities);
                        store.SaveChanges();
                    }
                }
            }

            _logger.LogInformation("Execution time: {TimeSpan}", stopwatch.Elapsed);

            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);

            stopwatch.Stop();
        }

        private static AirportSearchParamsEntity MapToAirportSearchParamsEntity(List<string> values)
        {
            return new AirportSearchParamsEntity()
            {
                Iata = values[0],
                Icao = values[1],
                Location = values[2],
                Airport = values[3],
                Country = values[4],
            };
        }

        private static bool CompareAirportInstances(AirportSearchParamsEntity entity, List<string> values)
        {
            return entity.Iata == values[0]
                   && entity.Icao == values[1]
                   && entity.Location == values[2]
                   && entity.Airport == values[3]
                   && entity.Country == values[4];
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Start updating airport search params");

            _timer = new Timer(Update, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Stop updating airport search params");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
