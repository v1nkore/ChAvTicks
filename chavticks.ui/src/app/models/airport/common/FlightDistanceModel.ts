import { Time } from "@angular/common";
import { FlightMetricsModel } from "../../flight/common/FlightMetricsModel";
import { AirportSummaryModel } from "./AirportSummaryModel";

export class FlightDistanceModel {
  from: AirportSummaryModel;
  to: AirportSummaryModel;
  distance: FlightMetricsModel;
  approximateFlightTime: Time;
}
