import { AirportLocationModel } from "../airport/common/AirportLocationModel";

export class AirportModelBase {
  icao?: string | null;
  iata?: string | null;
  localCode?: string | null;
  shortName?: string | null;
  municipalityName?: string | null;
  location: AirportLocationModel
}
