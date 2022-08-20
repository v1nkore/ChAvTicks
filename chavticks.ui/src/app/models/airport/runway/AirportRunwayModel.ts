import { FlightMetricsModel } from "../../flight/common/FlightMetricsModel";
import { AirportLocationModel } from "../common/AirportLocationModel";

export class AirportRunwayModel {
  name: string;
  headingDegrees: number;
  length: FlightMetricsModel;
  width: FlightMetricsModel;
  isClosed: boolean;
  location: AirportLocationModel;
  surfaceType: AirportRunwaySurfaceType;
  displacedThreshold: FlightMetricsModel;
  hasLighting: boolean;
}
