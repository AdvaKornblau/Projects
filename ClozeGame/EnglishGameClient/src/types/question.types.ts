export interface QuestionData {
    id: number;
    sentenceTemplate: string;
    options: string[];
    correctAnswer: string;
    points: number;
    explanation: string;
}

export interface QuestionResponse {
    question: QuestionData;
    success: boolean;
    error?: string;
}