import api, { type ResponseHttp } from './api';
import type {
  QuestionaryDto,
  AssessmentResultDto,
  GenerateQuestionaryRequest,
  SubmitAnswersRequest,
} from './types';

const questionaryService = {
  generate: async (request: GenerateQuestionaryRequest): Promise<ResponseHttp<QuestionaryDto>> => {
    return await api.post<QuestionaryDto>('/questionary/generate', request) as ResponseHttp<QuestionaryDto>;
  },

  getAll: async (): Promise<ResponseHttp<QuestionaryDto[]>> => {
    return await api.get<QuestionaryDto[]>('/questionary') as ResponseHttp<QuestionaryDto[]>;
  },

  getById: async (id: string): Promise<ResponseHttp<QuestionaryDto>> => {
    return await api.get<QuestionaryDto>(`/questionary/${id}`) as ResponseHttp<QuestionaryDto>;
  },

  submitAnswers: async (id: string, request: SubmitAnswersRequest): Promise<ResponseHttp<AssessmentResultDto>> => {
    return await api.post<AssessmentResultDto>(`/questionary/${id}/submit`, request) as ResponseHttp<AssessmentResultDto>;
  },

  getResults: async (id: string): Promise<ResponseHttp<AssessmentResultDto>> => {
    return await api.get<AssessmentResultDto>(`/questionary/${id}/results`) as ResponseHttp<AssessmentResultDto>;
  },
};

export default questionaryService;
