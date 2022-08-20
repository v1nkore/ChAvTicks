import { AirportSummaryModel } from "../common/AirportSummaryModel";
import { AirportOperatorModel } from "./AirportOperatorModel";

export class AirportRouteModel {
  destination: AirportSummaryModel;
  averageDailyFlights: number;
  operators: AirportOperatorModel[];
}
