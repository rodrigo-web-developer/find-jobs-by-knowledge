import api from './api';
import type {
  QuestionaryDto,
  AssessmentResultDto,
  GenerateQuestionaryRequest,
  SubmitAnswersRequest,
} from './types';

const questionaryService = {
  generate: async (request: GenerateQuestionaryRequest): Promise<QuestionaryDto> => {
    const response = await api.post<QuestionaryDto>('/questionary/generate', request);
    return response.data;
  },

  getAll: async (): Promise<QuestionaryDto[]> => {
    const response = await api.get<QuestionaryDto[]>('/questionary');
    return response.data;
  },

  getById: async (id: string): Promise<QuestionaryDto> => {
    const response = await api.get<QuestionaryDto>(`/questionary/${id}`);
    return response.data;
  },

  submitAnswers: async (id: string, request: SubmitAnswersRequest): Promise<AssessmentResultDto> => {
    const response = await api.post<AssessmentResultDto>(`/questionary/${id}/submit`, request);
    return response.data;
  },

  getResults: async (id: string): Promise<AssessmentResultDto> => {
    const response = await api.get<AssessmentResultDto>(`/questionary/${id}/results`);
    return response.data;
  },
};

export default questionaryService;
