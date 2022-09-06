import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({providedIn: 'root'})
export class ServiceNameService {

  private baseUrl = "/api/flights"

  constructor(private httpClient: HttpClient) { }


}

@Injectable({
  providedIn: 'root'
})
export class FlightService {


  constructor() { }
}
