import { LocationModelBase } from "../../base/LocationModelBase";

export class FlightLocationModel extends LocationModelBase {
  pressureAltFeet: number;
  groundSpeed: number;
  trackDegrees: number;
  reportedAtUtc: Date;
}
