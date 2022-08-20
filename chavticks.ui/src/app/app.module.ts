import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { MenuComponent } from './components/menu/menu.component';
import { FlightsSearchComponent } from './components/flights-search/flights-search.component';
import { SignoutRedirectCallbackComponent } from './components/signout-redirect-callback/signout-redirect-callback.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { MainPageComponent } from './components/main-page/main-page.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    FlightsSearchComponent,
    SignoutRedirectCallbackComponent,
    RegistrationComponent,
    NotFoundComponent,
    MainPageComponent,
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
