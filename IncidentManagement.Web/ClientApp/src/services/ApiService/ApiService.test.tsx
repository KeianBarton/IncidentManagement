import ApiService from "./ApiService";
import axios from "axios";
jest.mock("axios");

describe("api service", (): void => {
  afterEach(() => {
    jest.clearAllMocks();
  });

  describe("get", () => {
    it("should make a http get request successfully for a given url", async () => {
      // Arrange
      expect.hasAssertions();
      const url = "example URL";
      const response = { "example": 123 };
      (axios.get as jest.Mock)
        .mockImplementationOnce(() => Promise.resolve(response));
      
      // Act
      const actualResponse = await ApiService.get(url);

      // Assert
      expect(axios.get).toHaveBeenCalledTimes(1);
      expect(axios.get).toHaveBeenLastCalledWith(url);
      expect(actualResponse).toStrictEqual(response);
    });

    it("should return an error for a failed http get request", async () => {
      // Arrange
      expect.hasAssertions();
      const url = "example URL";
      const errorMessage = "bad request";
      (axios.get as jest.Mock)
        .mockImplementationOnce(() => Promise.reject(new Error(errorMessage)));

      // Act / Assert
      await expect(ApiService.get(url)).rejects.toThrow(errorMessage);
      expect(axios.get).toHaveBeenCalledTimes(1);
      expect(axios.get).toHaveBeenLastCalledWith(url);
    });
  });

  describe("post", () => {
    it("should make a http post request successfully for a given url", async () => {
      // Arrange
      expect.hasAssertions();
      const url = "example URL";
      const data = { "postData": 123 };
      const response = { "example": 123 };
      (axios.post as jest.Mock)
        .mockImplementationOnce(() => Promise.resolve(response));
      
      // Act
      const actualResponse = await ApiService.post(url, data);

      // Assert
      expect(axios.post).toHaveBeenCalledTimes(1);
      expect(axios.post).toHaveBeenLastCalledWith(url, data);
      expect(actualResponse).toStrictEqual(response);
    });

    it("should return an error for a failed http post request", async () => {
      // Arrange
      expect.hasAssertions();
      const url = "example URL";
      const data = { "postData": 123 };
      const errorMessage = "bad request";
      (axios.post as jest.Mock)
        .mockImplementationOnce(() => Promise.reject(new Error(errorMessage)));

      // Act / Assert
      await expect(ApiService.post(url, data)).rejects.toThrow(errorMessage);
      expect(axios.post).toHaveBeenCalledTimes(1);
      expect(axios.post).toHaveBeenLastCalledWith(url, data);
    });
  });
});