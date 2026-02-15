import api, { type HttpResponse } from './api';
import type {
  QuestionaryDto,
  AssessmentResultDto,
  GenerateQuestionaryRequest,
  SubmitAnswersRequest,
} from './types';

const questionaryService = {
  generate: async (request: GenerateQuestionaryRequest): Promise<HttpResponse<QuestionaryDto>> => {
    return await api.post<QuestionaryDto>('/questionary/generate', request) as HttpResponse<QuestionaryDto>;
  },

  getAll: async (): Promise<HttpResponse<QuestionaryDto[]>> => {
    return await api.get<QuestionaryDto[]>('/questionary') as HttpResponse<QuestionaryDto[]>;
  },

  getById: async (id: string): Promise<HttpResponse<QuestionaryDto>> => {
    return await api.get<QuestionaryDto>(`/questionary/${id}`) as HttpResponse<QuestionaryDto>;
  },

  submitAnswers: async (id: string, request: SubmitAnswersRequest): Promise<HttpResponse<AssessmentResultDto>> => {
    return await api.post<AssessmentResultDto>(`/questionary/${id}/submit`, request) as HttpResponse<AssessmentResultDto>;
  },

  getResults: async (id: string): Promise<HttpResponse<AssessmentResultDto>> => {
    return await api.get<AssessmentResultDto>(`/questionary/${id}/results`) as HttpResponse<AssessmentResultDto>;
  },
};

export default questionaryService;
