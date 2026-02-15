export interface TagLevel {
  tag: string;
  level: number;
}

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

export interface QuestionaryItemDto {
  id: string;
  questionId: string;
  tag: string;
  level: number;
  text: string;
  options: string[];
  selectedOptionIndex: number | null;
  isCorrect: boolean | null;
}

export interface TagResultDto {
  tag: string;
  determinedLevel: number;
  determinedLevelName: string;
  correctPercentage: number;
  percentagePerLevel: Record<number, number>;
}

export interface QuestionaryDto {
  id: string;
  tags: string[];
  items: QuestionaryItemDto[];
  isCompleted: boolean;
  createdAt: string;
  completedAt: string | null;
  results: TagResultDto[] | null;
}

export interface AssessmentResultDto {
  questionaryId: string;
  results: TagResultDto[];
  recommendedSearchTags: TagLevel[];
}

export interface AnswerItem {
  itemId: string;
  selectedOptionIndex: number;
}

export interface SubmitAnswersRequest {
  answers: AnswerItem[];
}

export interface GenerateQuestionaryRequest {
  tags: string[];
}
