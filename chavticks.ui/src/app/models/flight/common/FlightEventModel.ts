import { AirportSummaryModel } from "../../airport/common/AirportSummaryModel";

export class FlightPointModel {
  airport: AirportSummaryModel;
  scheduledTimeLocal?: Date | null;
  actualTimeLocal?: Date | null;
  runwayTimeLocal?: Date | null;
  scheduledTimeUtc?: Date | null;
  actualTimeUtc?: Date | null;
  runwayTimeUtc?: Date | null;
  terminal?: string | null;
  checkInDest?: string | null;
  gate?: string | null;
  baggageBelt?: string | null;
  runway?: string | null;
  quality?: string[] | null;
}
