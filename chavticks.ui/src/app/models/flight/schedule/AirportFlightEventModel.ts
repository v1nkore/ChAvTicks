import { FlightAircraftModel } from "../common/FlightAircraftModel";
import { FlightAirlineModel } from "../common/FlightAirlineModel";
import { FlightLocationModel } from "../common/FlightLocationModel";
import { FlightPointModel } from "../common/FlightEventModel";

export class AirportFlightEventModel {
  movement: FlightPointModel;
  departure: FlightPointModel;
  arrival: FlightPointModel;
  number: string;
  callSign?: string | null;
  status: FlightStatus;
  codeshareStatus: CodeshareStatus;
  isCargo: boolean;
  aircraft: FlightAircraftModel;
  airline: FlightAirlineModel;
  location: FlightLocationModel;
}
