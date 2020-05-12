/* eslint-disable no-unused-vars */
import { AxiosResponse } from "axios";
import { IncidentDto } from "../../dtos/IncidentDto";
/* eslint-enable no-unused-vars */
import { ApiService } from "../";
import { api } from "../../config.json";

const IncidentsService = {
  async addIncident(incident: IncidentDto): Promise<AxiosResponse> {
    const response = await ApiService.post(process.env.PUBLIC_URL + api.incidents, incident);
    return response;
  },
  async getIncidents(): Promise<AxiosResponse<IncidentDto[]>> {
    const response = await ApiService.get(process.env.PUBLIC_URL + api.incidents);
    return response;
  },
};

export default IncidentsService;