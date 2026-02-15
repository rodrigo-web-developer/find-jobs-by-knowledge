import api, { type ResponseHttp } from './api';
import type { Job, TagLevel } from './types';

const jobService = {
  getAll: async (): Promise<ResponseHttp<Job[]>> => {
    return await api.get<Job[]>('/jobs') as ResponseHttp<Job[]>;
  },

  getById: async (id: string): Promise<ResponseHttp<Job>> => {
    return await api.get<Job>(`/jobs/${id}`) as ResponseHttp<Job>;
  },

  searchByTag: async (tag: string, level: number = 3): Promise<ResponseHttp<Job[]>> => {
    return await api.get<Job[]>(`/jobs/search/${tag}`, { params: { level } }) as ResponseHttp<Job[]>;
  },

  searchByTags: async (tags: TagLevel[]): Promise<ResponseHttp<Job[]>> => {
    return await api.post<Job[]>('/jobs/search', tags) as ResponseHttp<Job[]>;
  },
};

export default jobService;
