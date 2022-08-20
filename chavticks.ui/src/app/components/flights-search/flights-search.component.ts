import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-flights-search',
  templateUrl: './flights-search.component.html',
  styleUrls: ['./flights-search.component.css']
})
export class FlightsSearchComponent implements OnInit {

    public textInputLabels: string[] = [
      'From',
      'To',
    ];

    public dateInputLabels: string[] = [
      'Thereto date',
      'Return date',
    ];

  constructor() { }

  ngOnInit(): void {

  }

}
