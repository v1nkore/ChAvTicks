import { FlightAircraftModel } from "./FlightAircraftModel";
import { FlightAirlineModel } from "./FlightAirlineModel";
import { FlightLocationModel } from "./FlightLocationModel";
import { FlightMetricsModel } from "./FlightMetricsModel";
import { FlightPointModel } from "./FlightEventModel";

export class FlightModel {
  distance: FlightMetricsModel;
  departure: FlightPointModel;
  arrival: FlightPointModel;
  lastUpdatedUtc: Date;
  number: string;
  callSign?: string | null;
  // status: FlightStatus;
  codeshareStatus: string;
  isCargo: boolean;
  aircraft: FlightAircraftModel;
  airline: FlightAirlineModel;
  location: FlightLocationModel
}
