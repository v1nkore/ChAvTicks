import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({providedIn: 'root'})
export class ServiceNameService {

  private baseUrl = "/api/flights"

  constructor(private httpClient: HttpClient) { }

  getFlights(searchBy: FlightSearchBy, searchParam: string, dateLocal: Date, withLocation?: boolean) {
    return this.httpClient.get(`${this.baseUrl}/${searchBy}/${searchParam}/${dateLocal}?${withLocation}`)
  }

  getFlightDepartureDates(searchBy: FlightSearchBy, searchParam: string, fromLocal: Date, toLocal: Date) {
    return this.httpClient.get(`${this.baseUrl}/${searchBy}/${searchParam}/dates/${fromLocal}/${toLocal}`)
  }

  getFlightDelayStatistics(flightNumber: string) {
    return this.httpClient.get(`${this.baseUrl}/${flightNumber}/delays`)
  }

  getAirportSchedule(icao: string, fromLocal: Date, toLocal: Date,
                    direction: FlightDirection, withLeg?: boolean,
                    withCancelled?: boolean, withCodeshared?: boolean,
                    withCargo?: boolean, withPrivate?: boolean, withLocation?: boolean) {
    return this.httpClient.get(`airport-schedule/${icao}/${fromLocal}/${toLocal}
                                ?${direction}?${withLeg}?${withCancelled}
                                ?${withCodeshared}?${withCargo}?${withPrivate}?${withLocation}`)
  }
}

@Injectable({
  providedIn: 'root'
})
export class FlightService {


  constructor() { }
}
