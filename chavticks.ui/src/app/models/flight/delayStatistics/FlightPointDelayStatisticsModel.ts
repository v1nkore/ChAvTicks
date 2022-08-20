import { Time } from "@angular/common";
import { FlightDelayedBracketsModel } from "./FlightDelayedBracketsModel";

export class FlightPointDelayStatisticsModel {
  airportIcao: string;
  type: FlightStatisticType;
  scheduledHourUtc?: number | null;
  medianDelay: Time;
  consideredFlights: number;
  delayedBrackets: FlightDelayedBracketsModel[];
  fromUtc: Date;
  toUtc: Date;
}
