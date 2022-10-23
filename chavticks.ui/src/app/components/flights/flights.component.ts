import { Component, OnInit } from '@angular/core';
import {FlightSearchResponse} from "../../responses/flight/FlightSearchResponse";

@Component({
  selector: 'app-flights',
  templateUrl: './flights.component.html',
  styleUrls: ['./flights.component.css']
})
export class FlightsComponent implements OnInit {

  constructor() { }

  public flights: FlightSearchResponse[];

  ngOnInit(): void {
    this.flights = JSON.parse(localStorage.getItem('flights') as string);

    console.log(this.flights);
  }

}
