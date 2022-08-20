import { AirportModelBase } from "../../base/AirportModelBase";
import { AirportRunwayModel } from "../runway/AirportRunwayModel";
import { AirportContinentModel } from "./AirportContinentModel";
import { AirportCountryModel } from "./AirportCountryModel";
import { AirportLocalTimeModel } from "./AirportLocalTimeModel";
import { AirportUrlsModel } from "./AirportUrlsModel";

export class AirportModel extends AirportModelBase{
  fullName: string;
  coutry: AirportCountryModel;
  continent: AirportContinentModel;
  timeZone: string;
  urls: AirportUrlsModel;
  runways: AirportRunwayModel
  currentTime: AirportLocalTimeModel
}
