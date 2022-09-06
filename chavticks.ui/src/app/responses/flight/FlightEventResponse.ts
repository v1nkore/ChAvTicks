import {AirportSummaryResponse} from "../airport/AirportSummaryResponse";

export class FlightEventResponse {
  airport: AirportSummaryResponse;
  scheduledTimeLocal: Date | null;
  runwayTimeLocal: Date | null;
  actualTimeLocal: Date | null;
  scheduledTimeUtc: Date | null;
  actualTimeUtc: Date | null;
  runwayTimeUtc: Date | null;
  terminal: string | null;
  checkInDesk: string | null;
  gate: string | null;
  baggageBelt: string | null;
  runway: string | null;
  quality: string[];
}
