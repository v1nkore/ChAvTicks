import {AirportLocationResponse} from "./AirportLocationResponse";

export class AirportSummaryResponse {
  icao: string | null;
  iata: string | null;
  localCode: string | null;
  name: string;
  shortName: string | null;
  municipalityName: string | null;
  location: AirportLocationResponse;
  countryCode: string | null;
  country: string | null;
}
