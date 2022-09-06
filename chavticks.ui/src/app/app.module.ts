import {forwardRef, NgModule} from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';

import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { SignoutRedirectCallbackComponent } from './components/signout-redirect-callback/signout-redirect-callback.component';
import { RegistrationComponent } from './components/registration/registration.component';
import {FormsModule, NG_VALUE_ACCESSOR, ReactiveFormsModule} from '@angular/forms';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { MatSelectModule } from "@angular/material/select";
import { MatInputModule } from "@angular/material/input";
import { FlightsComponent } from './components/flights/flights.component';
import { FlightsSearchComponent } from './components/flights-search/flights-search.component';
import {HTTP_INTERCEPTORS} from "@angular/common/http";
import {ErrorInterceptor} from "./interceptors/ErrorInterceptor";

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    SignoutRedirectCallbackComponent,
    RegistrationComponent,
    NotFoundComponent,
    FlightsComponent,
    FlightsSearchComponent,
  ],

    imports: [
      BrowserModule,
      AppRoutingModule,
      ReactiveFormsModule,
      BrowserAnimationsModule,
      MatInputModule,
      FormsModule,
      MatSelectModule,
      MatToolbarModule,
      MatFormFieldModule,
      MatIconModule,
      NgxMatSelectSearchModule,
    ],
  bootstrap: [AppComponent],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true
    }
  ],
})
export class AppModule { }
