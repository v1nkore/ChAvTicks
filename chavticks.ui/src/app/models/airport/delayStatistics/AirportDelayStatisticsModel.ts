import { AircraftEventDelayStatisticsModel } from "./AircraftEventDelayStatistics";

export class AirportDelayStatisticsModel {
  airportIcao: string;
  fromLocal: Date;
  toLocal: Date;
  fromUtc: Date;
  toUtc: Date;
  departuresDelay: AircraftEventDelayStatisticsModel;
  arrivalsDelay: AircraftEventDelayStatisticsModel;
}
