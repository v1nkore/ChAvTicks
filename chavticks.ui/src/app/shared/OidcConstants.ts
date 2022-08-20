export class OidcConstants {
  static readonly apiUrl: string =  "https://localhost:7103";
  static readonly identityServerUrl: string = "https://localhost:7091";
  static readonly clientUrl: string = "http://localhost:4200";
  static readonly clientId: string = "angular-client";
  static readonly apiScope: string  = "angular-client";
  static readonly clientSecret: string = "angular-client-secret";
  static readonly redirectUrl: string = "http://localhost:4200/signin-callback";
  static readonly postLogoutRedirectUrl: string = "http://localhost:4200/signout-callback";
}
