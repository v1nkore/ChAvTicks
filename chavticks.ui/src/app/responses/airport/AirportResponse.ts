import {AirportCountryResponse} from "./AirportCountryResponse";
import {AirportLocationResponse} from "./AirportLocationResponse";
import {AirportUrlsResponse} from "./AirportUrlsResponse";

export class AirportResponse {
  icao: string | null;
  iata: string | null;
  localCode: string | null;
  fullName: string;
  municipalityName: string | null;
  country: AirportCountryResponse;
  location: AirportLocationResponse;
  timeZone: string;
  urls: AirportUrlsResponse;
}
