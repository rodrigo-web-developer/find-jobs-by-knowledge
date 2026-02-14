import axios from 'axios';

const API_BASE_URL = process.env.REACT_APP_API_URL || 'http://localhost:5034';

export interface Job {
  id: string;
  title: string;
  company: string;
  description: string;
  location: string;
  salary?: number;
  postedDate: string;
  tags: string[];
  source: string;
}

const api = axios.create({
  baseURL: `${API_BASE_URL}/api`,
  headers: {
    'Content-Type': 'application/json',
  },
});

export const jobService = {
  getAllJobs: async (): Promise<Job[]> => {
    const response = await api.get<Job[]>('/jobs');
    return response.data;
  },

  getJobById: async (id: string): Promise<Job> => {
    const response = await api.get<Job>(`/jobs/${id}`);
    return response.data;
  },

  searchJobsByTag: async (tag: string): Promise<Job[]> => {
    const response = await api.get<Job[]>(`/jobs/search/${tag}`);
    return response.data;
  },

  searchJobsByTags: async (tags: string[]): Promise<Job[]> => {
    const response = await api.post<Job[]>('/jobs/search', tags);
    return response.data;
  },
};
