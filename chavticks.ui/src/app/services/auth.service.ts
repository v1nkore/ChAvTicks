import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { User, UserManager, UserManagerSettings } from 'oidc-client'
import { Subject } from 'rxjs';
import { OidcConstants } from '../shared/OidcConstants';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private _userManager: UserManager;
  private _user: User | null;
  private _loginChangedSubject = new Subject<boolean>();

  public loginChanged = this._loginChangedSubject.asObservable();

  private get idpSettings() : UserManagerSettings {
    return {
      authority: OidcConstants.identityServerUrl,
      client_id: OidcConstants.clientId,
      redirect_uri: OidcConstants.redirectUrl,
      scope: "openid profile angular-client",
      response_type: "code",
      post_logout_redirect_uri: OidcConstants.postLogoutRedirectUrl,
    }
  }

  constructor(private _httpClient: HttpClient, private _router: Router) {
    this._userManager = new UserManager(this.idpSettings);
  }

  public login() {
    return this._userManager.signinRedirect();
  }

  public isAuthenticated(): Promise<boolean> {
    return this._userManager.getUser()
    .then(user => {
      if(this._user !== user){
        this._loginChangedSubject.next(this.checkUser(user));
      }

      this._user = user;

      return this.checkUser(user);
    })
  }

  public finishLogin(): Promise<User> {
    return this._userManager.signinRedirectCallback()
    .then(user => {
      this._loginChangedSubject.next(this.checkUser(user));
      return user;
    })
  }

  public logout() {
    this._userManager.signoutRedirect();
  }

  public finishLogout() {
    this._user = null;
    this._loginChangedSubject.next(false);
    return this._userManager.signoutRedirectCallback();
  }

  private checkUser(user : User | null): boolean {
    return !!user && !user.expired;
  }
}
