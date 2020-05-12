// eslint-disable-next-line no-unused-vars
import { IncidentDto } from "../../dtos/IncidentDto";
import IncidentsService from "./IncidentsService";
import ApiService from "../ApiService/ApiService";
jest.mock("../ApiService/ApiService");

describe("incidents service", (): void => {
  afterEach(() => {
    jest.clearAllMocks();
  });

  describe("addIncident", () => {
    it("should call out to api service with specific url and data", async () => {
      // Arrange
      expect.hasAssertions();
      const response = { "example response": "bla" };
      const incident = {} as IncidentDto;
      (ApiService.post as jest.Mock)
        .mockImplementationOnce(() => Promise.resolve(response));

      // Act
      const actualResponse = await IncidentsService.addIncident(incident);

      // Assert
      expect(ApiService.post).toHaveBeenCalledTimes(1);
      expect(ApiService.post).toHaveBeenCalledWith(`${process.env.PUBLIC_URL}/api/incidents`, incident);
      expect(actualResponse).toStrictEqual(response);
    });
  });

  describe("getIncidents", () => {
    it("should call out to api service with specific url", async () => {
      // Arrange
      expect.hasAssertions();
      const response = [{}, {}, {}] as IncidentDto[];
      (ApiService.get as jest.Mock)
        .mockImplementationOnce(() => Promise.resolve(response));

      // Act
      const actualResponse = await IncidentsService.getIncidents();

      // Assert
      expect(ApiService.get).toHaveBeenCalledTimes(1);
      expect(ApiService.get).toHaveBeenCalledWith(`${process.env.PUBLIC_URL}/api/incidents`);
      expect(actualResponse).toStrictEqual(response);
    });
  });
});