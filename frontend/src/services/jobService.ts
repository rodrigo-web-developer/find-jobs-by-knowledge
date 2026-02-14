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
  requiredKnowledge: string[];
  isActive: boolean;
  createdAt: string;
  updatedAt?: string;
}

export interface CreateJobRequest {
  title: string;
  company: string;
  description: string;
  location: string;
  salary?: number;
  postedDate: string;
  requiredKnowledge: string[];
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

  searchJobsByKnowledge: async (knowledge: string): Promise<Job[]> => {
    const response = await api.get<Job[]>(`/jobs/search/${knowledge}`);
    return response.data;
  },

  createJob: async (job: CreateJobRequest): Promise<Job> => {
    const response = await api.post<Job>('/jobs', job);
    return response.data;
  },

  deleteJob: async (id: string): Promise<void> => {
    await api.delete(`/jobs/${id}`);
  },
};
