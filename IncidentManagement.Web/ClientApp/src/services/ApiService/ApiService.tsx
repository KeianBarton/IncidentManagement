// eslint-disable-next-line no-unused-vars
import axios, { AxiosResponse } from "axios";

const ApiService = {
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  async get(url: string): Promise<AxiosResponse<any>> {
    const response = await axios.get(url);
    return response;
  },
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  async post(url: string, data?: any): Promise<AxiosResponse<any>> {
    const response = await axios.post(url, data);
    return response;
  }
};

export default ApiService;