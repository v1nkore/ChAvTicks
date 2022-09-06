import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { SigninRedirectCallbackComponent } from './components/signin-redirect-callback/signin-redirect-callback.component';
import { SignoutRedirectCallbackComponent } from './components/signout-redirect-callback/signout-redirect-callback.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { HttpClientModule } from '@angular/common/http';
import {FlightsComponent} from "./components/flights/flights.component";
import {FlightsSearchComponent} from "./components/flights-search/flights-search.component";

const routes: Routes = [
  { path: '', redirectTo: 'flights-search', pathMatch: 'full' },
  { path: 'flights-search', component: FlightsSearchComponent },
  { path: 'flights', component: FlightsComponent },
  { path: 'signin-callback', component: SigninRedirectCallbackComponent },
  { path: 'signout-callback', component: SignoutRedirectCallbackComponent },
  { path: 'registration', component: RegistrationComponent },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
  ],
  exports: [RouterModule],
})
export class AppRoutingModule { }
