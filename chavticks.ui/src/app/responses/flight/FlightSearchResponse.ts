import {FlightEventResponse} from "./FlightEventResponse";
import {FlightStatus} from "../enums/FlightStatus";
import {CodeshareStatus} from "../enums/CodeshareStatus";
import {FlightAircraftResponse} from "./FlightAircraftResponse";
import {FlightAirlineResponse} from "./FlightAirlineResponse";
import {FlightLocationResponse} from "./FlightLocationResponse";
import {Queue} from "queue-typescript";

export class FlightSearchResponse {
  movement: FlightEventResponse;
  departure: FlightEventResponse;
  arrival: FlightEventResponse;
  number: string;
  callSign: string | null;
  status: FlightStatus;
  codeshareStatus: CodeshareStatus;
  isCargo: boolean;
  aircraft: FlightAircraftResponse;
  airline: FlightAirlineResponse;
  location: FlightLocationResponse;
  transfers:  Queue<FlightSearchResponse>;
}
