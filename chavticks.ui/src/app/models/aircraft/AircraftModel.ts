import { AircraftRegistrationModel } from "./AircraftRegistrationModel";

export class AircraftModel {
  id: bigint;
  registration: string;
  active: boolean;
  serialNumber?: string | null;
  hexIcao?: string | null;
  airlineName?: string | null;
  iataType?: string | null;
  iataCodeShort?: string;
  icaoCode?: string | null;
  model?: string | null;
  modelCode?: string;
  seatsNumber: number;
  rolloutDate?: Date | null;
  firstFlightDate?: Date | null;
  deliveryDate?: Date | null;
  registrationDate?: Date | null;
  typeName?: string | null;
  engines: number;
  engineType: AircraftEngineType;
  isFreighter: boolean;
  productionLine: string;
  age: number;
  isVerified: boolean;
  registrationsCount: number;
  registrations: AircraftRegistrationModel[];
}
