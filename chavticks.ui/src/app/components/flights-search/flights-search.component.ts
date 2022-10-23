import {Component, OnDestroy, OnInit} from '@angular/core';
import {FormBuilder, FormControl, FormGroup} from "@angular/forms";
import {debounceTime, filter, Observable, Subject, switchMap, takeUntil} from "rxjs";
import {AirportsSearchResponse} from "../../responses/airport/AirportsSearchResponse";
import {AuthService} from "../../services/auth.service";
import {HttpClient} from "@angular/common/http";
import {NavigationExtras, Router} from "@angular/router";
import {ApiEndpoints} from "../../shared/ApiEndpoints";
import {FlightSearchResponse} from "../../responses/flight/FlightSearchResponse";
import {AirportSummaryResponse} from "../../responses/airport/AirportSummaryResponse";
import {AirportResponse} from "../../responses/airport/AirportResponse";
import {AirportLocationResponse} from "../../responses/airport/AirportLocationResponse";

@Component({
  selector: 'app-flights-search',
  templateUrl: './flights-search.component.html',
  styleUrls: ['./flights-search.component.css']
})

export class FlightsSearchComponent implements OnInit, OnDestroy {

  public searchFlightsForm: FormGroup;

  public serviceTypes = ['Eco', 'Premium-eco', 'Business']
  public userAuthenticated = false;

  public fromAirports$: Observable<AirportsSearchResponse[]>;
  public toAirports$: Observable<AirportsSearchResponse[]>;

  public fromAirportControlFilter: FormControl = new FormControl('');
  public toAirportControlFilter: FormControl = new FormControl('');

  public _onDestroy = new Subject<void>();

  constructor(
    private _authService: AuthService,
    private _formBuilder: FormBuilder,
    private _httpClient: HttpClient,
    private _router: Router,) {}

  ngOnInit() {

    this.searchFlightsForm = this._formBuilder.group({
      from: '',
      to: '',
      thereto: '',
      back: '',
      service: '',
      passengers: '',
    })

    this._authService.loginChanged
      .subscribe(userAuthenticated => {
        this.userAuthenticated = userAuthenticated;
      })

    this.fromAirports$ = this.fromAirportControlFilter.valueChanges
      .pipe(
        takeUntil(this._onDestroy),
        filter(term => !!term),
        takeUntil(this._onDestroy),
        debounceTime(500),
        switchMap((term: string) => this.filterAirports(term)),
      )

    this.toAirports$ = this.toAirportControlFilter.valueChanges
      .pipe(
        takeUntil(this._onDestroy),
        filter(term => !!term),
        takeUntil(this._onDestroy),
        debounceTime(500),
        switchMap((term: string) => this.filterAirports(term)),
      )

  }

  public searchFlights() {
    this._httpClient.post<FlightSearchResponse[]>(ApiEndpoints.flightsSearch, this.searchFlightsForm.value)
      .subscribe(response => {

        let airportSummary: AirportSummaryResponse = new AirportSummaryResponse();
        //
        // this._httpClient.get<AirportResponse>(
        //   `${ApiEndpoints.airportsByTerm}/icao/${this.searchFlightsForm.get('from')?.value}`)
        //   .subscribe(response => {
        //     airportSummary.iata = response.iata;
        //     airportSummary.icao = response.icao;
        //     airportSummary.name = response.fullName;
        //     airportSummary.municipalityName = response.municipalityName;
        //     airportSummary.localCode = response.localCode;
        //     airportSummary.country = response.country.name;
        //     airportSummary.countryCode = response.country.code;
        //     airportSummary.location = response.location;
        //     airportSummary.shortName = null;
        //   });

        //
        // for (let flight of response) {
        //   if (!flight.departure.airport) {
        //     flight.departure.airport = airportSummary
        //   }
        // }

        console.log(response);
        localStorage.setItem('flights', JSON.stringify(response));
        this._router.navigate(['/flights']);
      }
    );
  }

  private filterAirports(term: string) : Observable<AirportsSearchResponse[]>{
    return this._httpClient.get<AirportsSearchResponse[]>(`${ApiEndpoints.airportsByTerm}/${term}`);
  }

  ngOnDestroy() {
    this._onDestroy.next();
    this._onDestroy.complete();
  }

}
