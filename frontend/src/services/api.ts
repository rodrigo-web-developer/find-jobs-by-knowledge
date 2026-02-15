import axios, { AxiosResponse } from 'axios';

const api = axios.create({
    baseURL: '/api',
    headers: { 'Content-Type': 'application/json' },
});

api.interceptors.response.use(
    (response) => {
        (response as SuccessResponse<any>).success = true;
        return response;
    },
    async (error) => {
        if (error.response?.status) {
            // fetch like behavior: return response even for error status codes
            error.response.success = false;
            return Promise.resolve(error.response);
        }
        return Promise.reject(error);
    });

interface SuccessResponse<T> extends AxiosResponse<T> {
    success: true;
}

interface ErrorResponse extends AxiosResponse<any> {
    success: false;
}

export type ResponseHttp<T> = SuccessResponse<T> | ErrorResponse;

export default api;
