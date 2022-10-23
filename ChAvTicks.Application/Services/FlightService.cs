using ChAvTicks.Application.Configuration;
using ChAvTicks.Application.Helpers;
using ChAvTicks.Application.Interfaces;
using ChAvTicks.Application.JsonConverters;
using ChAvTicks.Application.Requests.Flight;
using ChAvTicks.Application.Responses.Flight.Common;
using ChAvTicks.Application.Responses.Flight.DelayStatistics;
using ChAvTicks.Application.Responses.Flight.Schedule;
using ChAvTicks.Application.UrlConverter;
using ChAvTicks.Domain.Entities.Airport;
using ChAvTicks.Domain.ServiceResponses;
using ChAvTicks.Infrastructure.Persistence;
using ChAvTicks.Application.Requests.Pagination;
using ChAvTicks.Domain.Entities.Base;
using ChAvTicks.Infrastructure.Extensions;

namespace ChAvTicks.Application.Services
{
    public sealed class FlightService : IFlightService
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationStorage _storage;
        private readonly IRequestBuilder _requestBuilder;
        public FlightService(HttpClient httpClient, ApplicationStorage storage, IRequestBuilder requestBuilder)
        {
            _httpClient = httpClient;
            _storage = storage;
            _requestBuilder = requestBuilder;
        }

        public async Task<ModelResponseWithError<IEnumerable<FlightResponse>?, string>?> GetFlightsAsync(FlightsRequest request)
        {
            var flightUri = new Uri($"{FlightApiEndpoints.FlightEndpoints.BaseUrl}/{request.SearchBy}/{request.SearchParameter}/{request.DateLocal}?{request.WithLocation}");

            return await _httpClient.ExecuteHttpRequestAsync<IEnumerable<FlightResponse>?>(_requestBuilder, HttpMethod.Get, flightUri);
        }

        public async Task<ModelResponseWithError<string[]?, string>?> GetFlightDepartureDatesAsync(FlightDepartureDatesRequest request)
        {
            var departureDatesUri = new Uri($"{FlightApiEndpoints.FlightEndpoints.BaseUrl}/{request.SearchBy}/{request.SearchParameter}/dates/{request.FromLocal}/{request.ToLocal}");

            return await _httpClient.ExecuteHttpRequestAsync<string[]>(_requestBuilder, HttpMethod.Get, departureDatesUri);
        }

        public async Task<ModelResponseWithError<FlightDelayStatisticsResponse?, string>?> GetFlightDelayStatisticsAsync(string flightNumber)
        {
            var delayStatisticsUri = new Uri($"{FlightApiEndpoints.FlightEndpoints.BaseUrl}/{flightNumber}/delays");

            return await _httpClient.ExecuteHttpRequestAsync<FlightDelayStatisticsResponse?>(_requestBuilder, HttpMethod.Get, delayStatisticsUri);
        }

        public async Task<ModelResponseWithError<AirportScheduleResponse?, string>?> GetAirportScheduleAsync(AirportScheduleRequest request)
        {
            var airportScheduleUri = new Uri($"{FlightApiEndpoints.FlightEndpoints.AirportSchedule}/{request.Icao}/{request.FromLocal}/{request.ToLocal}?{request.ConvertToQueryParams()}");

            return await _httpClient.ExecuteHttpRequestAsync<AirportScheduleResponse?>(_requestBuilder, HttpMethod.Get, airportScheduleUri);
        }

        public async Task<ModelResponseWithError<IEnumerable<AirportFlightEventResponse>?, string>?> SearchAsync(SearchFlightsRequest request)
        {
            var fromLocal = request.Thereto.ToString(DateTimeDefaults.LocalDateTimeWithoutSeconds);
            var toLocal = request.Thereto.AddHours(12).ToString(DateTimeDefaults.LocalDateTimeWithoutSeconds);
            var airportScheduleUri = new Uri($"{FlightApiEndpoints.FlightEndpoints.AirportSchedule}/{request.FromAirportIcaoCode}/{fromLocal}/{toLocal}?withLeg=true");

            var airportSchedule = await _httpClient.ExecuteHttpRequestAsync<AirportScheduleResponse?>(_requestBuilder, HttpMethod.Get, airportScheduleUri);
            
            return new ModelResponseWithError<IEnumerable<AirportFlightEventResponse>?, string>()
            {
                Model = airportSchedule?.Model?.FlightDepartures.AsEnumerable()
                    .Where(d => d!.Arrival!.Airport!.Icao != request.ToAirportIcaoCode)
            };
        }

        public async Task<ModelResponseWithError<List<FlightChainResponse>?, string?>> SearchWithTransfersAsync(
            SearchFlightsRequest searchRequest,
            SearchFlightsPaginationRequest paginationRequest)
        {
            var departures = await _storage.GetAirportDeparturesAsync(searchRequest.FromAirportIcaoCode);
            var arrivals = await _storage.GetAirportArrivalsAsync(searchRequest.ToAirportIcaoCode);

            var flightChainsResponse = new ModelResponseWithError<List<FlightChainResponse>?, string?>();
            if (departures == null || arrivals == null)
            {
                return new ModelResponseWithError<List<FlightChainResponse>?, string?>()
                {
                    ErrorMessage = "Departure or arrival airport not found, check your request"
                };
            }

            if (paginationRequest.PageNumber == 1)
            {
                var directFlights = departures.Where(d => d.Departure!.AirportSummary!.Icao == searchRequest.ToAirportIcaoCode);

                flightChainsResponse.Model!.AddRange(directFlights.Select(directFlight => new FlightChainResponse()
                {
                    DepartureAirportIataCode = directFlight.Departure!.AirportSummary!.Iata,
                    ArrivalAirportIataCode = directFlight.Arrival!.AirportSummary!.Iata,
                    FlightDeparture = directFlight,
                    FlightArrival = arrivals.First(a => IsFlightsPair(directFlight, a)),
                }));    
            }

            var departureAirportIcaoCodes = departures.Where(d => 
                    d.Arrival!.AirportSummary!.Icao != searchRequest.FromAirportIcaoCode
                    && d.Arrival!.AirportSummary!.Icao != searchRequest.ToAirportIcaoCode)
                .Select(d => d.Arrival!.AirportSummary!.Icao)
                .ToArray();

            if (departureAirportIcaoCodes.Length > 0)
            {
                var transferAirportSchedules = await _storage.GetTransferAirportsAsync(
                    departureAirportIcaoCodes!,
                    searchRequest.FromAirportIcaoCode,
                    searchRequest.ToAirportIcaoCode,
                    paginationRequest.PageNumber,
                    paginationRequest.PageSize);

                foreach (var transferSchedule in transferAirportSchedules)
                {
                    var fromDepartureToTransferFlightsPair = FindFlightsPair(departures, transferSchedule.FlightArrivals);

                    if (fromDepartureToTransferFlightsPair != null)
                    {
                        var fromTransferToArrivalFlightsPair = FindFlightsPair(transferSchedule.FlightDepartures, arrivals);

                        if (fromTransferToArrivalFlightsPair != null 
                            && Validate(fromDepartureToTransferFlightsPair.Item1, fromDepartureToTransferFlightsPair.Item2,
                                        fromTransferToArrivalFlightsPair.Item1, fromTransferToArrivalFlightsPair.Item2))
                        {
                            flightChainsResponse.Model!.Add(MappingHelper.MapToFlightChainResponse(
                                                     fromDepartureToTransferFlightsPair.Item1,
                                                     fromDepartureToTransferFlightsPair.Item2,
                                                     fromTransferToArrivalFlightsPair.Item1, 
                                                     fromTransferToArrivalFlightsPair.Item2));
                            
                            flightChainsResponse.Model.OrderBy(c => c.FlightDeparture!.Departure!.ScheduledTimeLocal).ToList();
                        }
                    }
                }
            }

            return flightChainsResponse;
        }

        private Tuple<AirportFlightDepartureEntity, AirportFlightArrivalEntity>? FindFlightsPair(IEnumerable<AirportFlightDepartureEntity> departures, IEnumerable<AirportFlightArrivalEntity> arrivals)
        {
            foreach (var departure in departures)
            {
                foreach (var arrival in arrivals)
                {
                    if (IsFlightsPair(departure, arrival))
                    {
                        return new Tuple<AirportFlightDepartureEntity, AirportFlightArrivalEntity>(departure, arrival);
                    }
                }
            }

            return null;
        }

        private bool IsFlightsPair(AirportFlightEntityBase flightDeparture, AirportFlightEntityBase flightArrival)
        {
            return flightDeparture.Arrival!.AirportSummary!.Icao == flightArrival.Arrival!.AirportSummary!.Icao
                && flightDeparture.Departure!.ScheduledTimeUtc == flightArrival.Departure!.ScheduledTimeUtc
                && flightDeparture.Number == flightArrival.Number;
        }

        private bool Validate(AirportFlightEntityBase flightDeparture,
                              AirportFlightEntityBase transferArrival,
                              AirportFlightEntityBase transferDeparture,
                              AirportFlightEntityBase flightArrival)
        {
            return flightDeparture.Departure!.ScheduledTimeUtc == transferArrival.Departure!.ScheduledTimeUtc
                && transferDeparture.Departure!.ScheduledTimeUtc - transferArrival.Arrival!.ScheduledTimeUtc >= TimeSpan.FromHours(1)
                && transferDeparture.Departure.ScheduledTimeUtc == flightArrival.Departure!.ScheduledTimeUtc;
        }

        #region OldFunctional

        // public async Task<ICollection<FlightChainResponse>> SearchWithTransfersWithoutMappingAsync(SearchFlightsRequest searchRequest, SearchFlightsPaginationRequest paginationRequest)
        // {
        //     var departureAirportSchedule = await _storage.GetAirportAsync(searchRequest.FromAirportIcaoCode, FlightDirection.Departure);
        //     var arrivalAirportSchedule = await _storage.GetAirportAsync(searchRequest.ToAirportIcaoCode, FlightDirection.Arrival);
        //
        //     var flightChainsResponse = new List<FlightChainResponse>();
        //     if (departureAirportSchedule == null || arrivalAirportSchedule == null)
        //     {
        //         return flightChainsResponse;
        //     }
        //
        //     if (paginationRequest.PageNumber == 1)
        //     {
        //         var directFlights = departureAirportSchedule.FlightDepartures
        //             .Where(d => d.Departure!.AirportSummary!.Icao == searchRequest.ToAirportIcaoCode);
        //
        //         flightChainsResponse.AddRange(directFlights.Select(directFlight => new FlightChainResponse()
        //         {
        //             DepartureAirportId = departureAirportSchedule.Id,
        //             ArrivalAirportId = arrivalAirportSchedule.Id,
        //             DepartureAirportIataCode = directFlight.Departure!.AirportSummary!.Iata,
        //             ArrivalAirportIataCode = directFlight.Arrival!.AirportSummary!.Iata,
        //             FlightDeparture = directFlight,
        //             FlightArrival = arrivalAirportSchedule.FlightArrivals.First(a => IsFlightsPair(directFlight, a)),
        //         }));
        //     }
        //
        //     var departureAirportIcaoCodes = departureAirportSchedule.FlightDepartures
        //         .Where(d => d.Arrival!.AirportSummary!.Icao != searchRequest.FromAirportIcaoCode
        //                     && d.Arrival!.AirportSummary!.Icao != searchRequest.ToAirportIcaoCode)
        //         .Select(d => d.Arrival!.AirportSummary!.Icao)
        //         .ToArray();
        //
        //     if (departureAirportIcaoCodes.Length > 0)
        //     {
        //         var transferAirportSchedules = await _storage.GetTransferAirportsAsync(
        //             departureAirportIcaoCodes!,
        //             searchRequest.FromAirportIcaoCode,
        //             searchRequest.ToAirportIcaoCode,
        //             paginationRequest.PageNumber,
        //             paginationRequest.PageSize);
        //
        //         foreach (var departure in departureAirportSchedule.FlightDepartures)
        //         {
        //             foreach (var transferSchedule in transferAirportSchedules)
        //             {
        //                 foreach (var transferArrival in transferSchedule.FlightArrivals)
        //                 {
        //                     if (IsFlightsPair(departure, transferArrival))
        //                     {
        //                         foreach (var transferDeparture in transferSchedule.FlightDepartures)
        //                         {
        //                             foreach (var arrival in arrivalAirportSchedule.FlightArrivals)
        //                             {
        //                                 if (IsFlightsPair(transferDeparture, arrival)
        //                                     && Validate(departure, transferArrival, transferDeparture, arrival))
        //                                 {
        //                                     var flightChainResponse = new FlightChainResponse()
        //                                     {
        //                                         DepartureAirportIataCode = departure.Departure!.AirportSummary!.Iata,
        //                                         TransferAirportIataCode = transferDeparture.Departure!.AirportSummary!.Iata,
        //                                         ArrivalAirportIataCode = arrival.Arrival!.AirportSummary!.Iata,
        //                                         FlightDeparture = departure,
        //                                         TransferArrival = transferArrival,
        //                                         TransferDeparture = transferDeparture,
        //                                         FlightArrival = arrival,
        //                                     };
        //
        //                                     flightChainResponse.FlightDeparture.AirportSchedule = null;
        //                                     flightChainResponse.TransferDeparture.AirportSchedule = null;
        //                                     flightChainResponse.TransferArrival.AirportSchedule = null;
        //                                     flightChainResponse.FlightArrival.AirportSchedule = null;
        //
        //                                     flightChainsResponse.Add(flightChainResponse);
        //                                 }
        //                             }
        //                         }
        //                     }
        //                 }
        //             }
        //         }
        //     }
        //
        //     return flightChainsResponse.OrderBy(c => c.FlightDeparture.Departure.ScheduledTimeLocal).ToList();
        // }

        // public async Task<ModelResponseWithError<List<AirportFlightEventResponse?>, string?>> SearchWithTransfersAsync(SearchFlightsRequest request, int? repeat = null)
        // {
        //     var flightsWithTransfersResponse = new ModelResponseWithError<List<AirportFlightEventResponse?>, string?>()
        //     {
        //         Model = new List<AirportFlightEventResponse?>()
        //     };
        //
        //     var fromLocal = request.Thereto.ToString(DateTimeDefaults.LocalDateTimeWithoutSeconds);
        //     var toLocal = request.Thereto.AddHours(12).ToString(DateTimeDefaults.LocalDateTimeWithoutSeconds);
        //     if (!await _storage.AirportSchedules.AnyAsync())
        //     {
        //         var departureAirportUri = new Uri($"{FlightApiEndpoints.FlightEndpoints.AirportSchedule}/{request.FromAirportIcaoCode}/{fromLocal}/{toLocal}?withLeg=true");
        //         var departureAirportSchedule = await _httpClient.ExecuteHttpRequestAsync<AirportScheduleResponse?>(_requestBuilder, HttpMethod.Get, departureAirportUri);
        //
        //         var departureAirportSummaryUri = new Uri($"{FlightApiEndpoints.AirportEndpoints.Icao}/{request.FromAirportIcaoCode}");
        //         var departureAirportSummary = await _httpClient.ExecuteHttpRequestAsync<AirportSummaryResponse?>(_requestBuilder, HttpMethod.Get, departureAirportSummaryUri);
        //
        //         if (departureAirportSchedule?.Model != null)
        //         {
        //             InitializationHelper.InitializeAirportSummaries(departureAirportSchedule.Model, departureAirportSummary?.Model);
        //             await _storage.SaveAirportScheduleAsync(departureAirportSchedule.Model, request.FromAirportIcaoCode);
        //         }
        //
        //         var schedules = new ConcurrentStack<AirportScheduleResponse>();
        //
        //         if (departureAirportSchedule?.Model != null)
        //         {
        //             schedules.Push(departureAirportSchedule.Model);
        //
        //             var arrivalAirportUri = new Uri($"{FlightApiEndpoints.FlightEndpoints.AirportSchedule}/{request.ToAirportIcaoCode}/{fromLocal}/{toLocal}?withLeg=true");
        //             var arrivalAirportSchedule = await _httpClient.ExecuteHttpRequestAsync<AirportScheduleResponse?>(_requestBuilder, HttpMethod.Get, arrivalAirportUri);
        //
        //             var arrivalAirportSummaryUri = new Uri($"{FlightApiEndpoints.AirportEndpoints.Icao}/{request.ToAirportIcaoCode}");
        //             var arrivalAirportSummary = await _httpClient.ExecuteHttpRequestAsync<AirportSummaryResponse?>(_requestBuilder, HttpMethod.Get, arrivalAirportSummaryUri);
        //
        //             if (arrivalAirportSchedule?.Model != null)
        //             {
        //                 InitializationHelper.InitializeAirportSummaries(arrivalAirportSchedule.Model, arrivalAirportSummary?.Model);
        //                 await _storage.SaveAirportScheduleAsync(arrivalAirportSchedule.Model, request.ToAirportIcaoCode);
        //             }
        //
        //             int depth = 0;
        //             const int transfersLimit = 1;
        //
        //             var requestedSchedules = new ConcurrentStack<string>();
        //             while (schedules.TryPop(out var airportSchedule))
        //             {
        //                 if (depth < transfersLimit && airportSchedule != null)
        //                 {
        //                     if (flightsWithTransfersResponse.Model.Count == 0)
        //                     {
        //                         flightsWithTransfersResponse.Model.AddRange(airportSchedule.FlightDepartures.AsEnumerable()
        //                             .Where(x => x.Arrival!.Airport!.Icao?.ToUpperInvariant() == request.ToAirportIcaoCode.ToUpperInvariant()));
        //                     }
        //
        //                     while (depth++ < transfersLimit)
        //                     {
        //                         if (airportSchedule.FlightDepartures != null)
        //                         {
        //                             await Parallel.ForEachAsync(airportSchedule.FlightDepartures, async (flightDeparture, cancellationToken) =>
        //                             {
        //                                 if (!requestedSchedules.Contains(flightDeparture.Arrival.Airport!.Icao)
        //                                     && request.FromAirportIcaoCode != flightDeparture.Arrival.Airport.Icao
        //                                     && request.ToAirportIcaoCode != flightDeparture.Arrival.Airport.Icao)
        //                                 {
        //                                     var transferAirportUri = new Uri($"{FlightApiEndpoints.FlightEndpoints.AirportSchedule}/{flightDeparture.Arrival.Airport.Icao}/{fromLocal}/{toLocal}?withLeg=true");
        //                                     var transferAirportSchedule = await _httpClient.ExecuteHttpRequestAsync<AirportScheduleResponse?>(_requestBuilder, HttpMethod.Get, transferAirportUri);
        //
        //                                     if (transferAirportSchedule?.Model != null)
        //                                     {
        //                                         var transferAirportSummaryUri = new Uri($"{FlightApiEndpoints.AirportEndpoints.Icao}/{flightDeparture.Arrival.Airport.Icao}");
        //                                         var transferAirportSummary = await _httpClient.ExecuteHttpRequestAsync<AirportSummaryResponse?>(_requestBuilder, HttpMethod.Get, transferAirportSummaryUri);
        //
        //                                         InitializationHelper.InitializeAirportSummaries(transferAirportSchedule.Model, transferAirportSummary?.Model);
        //
        //                                         requestedSchedules.Push(flightDeparture.Arrival.Airport.Icao);
        //                                         schedules.Push(transferAirportSchedule.Model);
        //                                     }
        //                                 }
        //                             });
        //                         }
        //                     }
        //                 }
        //                 else if (airportSchedule != null && requestedSchedules.TryPop(out string? icao))
        //                 {
        //                     await _storage.SaveAirportScheduleAsync(airportSchedule, icao);
        //                 }
        //             }
        //         }
        //     }
        //
        //     while (repeat.HasValue && repeat-- != 0)
        //     {
        //         var secondDayPartFromLocal = request.Back!.Value;
        //         var secondDayPartToLocal = request.Back.Value.AddHours(12);
        //         var secondDayPartRequest = new SearchFlightsRequest(
        //             request.FromAirportIcaoCode,
        //             request.ToAirportIcaoCode,
        //             secondDayPartFromLocal,
        //             secondDayPartToLocal,
        //             request.Service,
        //             request.Passengers);
        //
        //         var secondDayPartFlightsResponse = await SearchWithTransfersAsync(secondDayPartRequest, repeat);
        //
        //         if (secondDayPartFlightsResponse.Model != null)
        //         {
        //             flightsWithTransfersResponse.Model.AddRange(secondDayPartFlightsResponse.Model);
        //         }
        //     }
        //
        //     return flightsWithTransfersResponse;
        // }
        
        #endregion
    }
}
