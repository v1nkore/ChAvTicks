import { FlightPointDelayStatisticsModel } from "./FlightPointDelayStatisticsModel";

export class FlightDelayStatisticsModel {
  number: string;
  origins: FlightPointDelayStatisticsModel[];
  destinations: FlightPointDelayStatisticsModel[];
}
