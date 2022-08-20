export class AircraftRegistrationModel {
  registration: string;
  active: boolean;
  hexIcao?: string | null;
  airlineName?: string | null;
  registrationDate?: Date | null;
}
