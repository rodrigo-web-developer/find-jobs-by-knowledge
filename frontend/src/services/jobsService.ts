import api, { type HttpResponse } from './api';
import type { Job, TagLevel } from './types';

const jobService = {
  getAll: async (): Promise<HttpResponse<Job[]>> => {
    return await api.get<Job[]>('/jobs') as HttpResponse<Job[]>;
  },

  getById: async (id: string): Promise<HttpResponse<Job>> => {
    return await api.get<Job>(`/jobs/${id}`) as HttpResponse<Job>;
  },

  searchByTag: async (tag: string, level: number = 3): Promise<HttpResponse<Job[]>> => {
    return await api.get<Job[]>(`/jobs/search/${tag}`, { params: { level } }) as HttpResponse<Job[]>;
  },

  searchByTags: async (tags: TagLevel[]): Promise<HttpResponse<Job[]>> => {
    return await api.post<Job[]>('/jobs/search', tags) as HttpResponse<Job[]>;
  },
};

export default jobService;
