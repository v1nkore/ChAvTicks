import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  public registrationForm: FormGroup;

  constructor(private _formBuilder: FormBuilder, private _httpClient: HttpClient) { }

  ngOnInit(): void {

    this.registrationForm = this._formBuilder.group({
      userName: '',
      password: '',
      confirmedPassword: '',
      returnUrl: window.location.origin
    })
  }

  public register() {
    const url = `https://localhost:7091/account/register?returnUrl=${this.registrationForm.value.returnUrl}}`;
    this._httpClient.post(url, this.registrationForm.value)
      .subscribe();
  }
}
