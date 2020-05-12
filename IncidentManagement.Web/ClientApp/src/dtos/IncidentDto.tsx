// eslint-disable-next-line no-unused-vars
import { LocationDto } from "./LocationDto";

export type IncidentDto = {
  id: number;
  title: string;
  description: string;
  occurrence: string;
  location: LocationDto;
};