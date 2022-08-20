import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-not-found',
  template: '<div></div>',
})
export class NotFoundComponent implements OnInit {

  constructor(private _router: Router) { }

  ngOnInit(): void {
    this._router.navigate(['']);
  }

}
