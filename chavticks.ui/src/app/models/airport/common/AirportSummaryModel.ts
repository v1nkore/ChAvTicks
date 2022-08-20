import { AirportModelBase } from "../../base/AirportModelBase";

export class AirportSummaryModel extends AirportModelBase{
  name: string;
  countryCode?: string | null;
}
