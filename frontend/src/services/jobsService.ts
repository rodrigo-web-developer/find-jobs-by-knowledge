import api from './api';
import type { Job, TagLevel } from './types';

const jobService = {
  getAll: async (): Promise<Job[]> => {
    const response = await api.get<Job[]>('/jobs');
    return response.data;
  },

  getById: async (id: string): Promise<Job> => {
    const response = await api.get<Job>(`/jobs/${id}`);
    return response.data;
  },

  searchByTag: async (tag: string, level: number = 3): Promise<Job[]> => {
    const response = await api.get<Job[]>(`/jobs/search/${tag}`, { params: { level } });
    return response.data;
  },

  searchByTags: async (tags: TagLevel[]): Promise<Job[]> => {
    const response = await api.post<Job[]>('/jobs/search', tags);
    return response.data;
  },
};

export default jobService;
