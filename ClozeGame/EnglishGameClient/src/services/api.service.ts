import { QuestionData } from '../types';

const API_BASE_URL = 'http://localhost:5162';

export async function fetchQuestion(id: number | null): Promise<QuestionData | null> {
  try {
    const response = await fetch(`${API_BASE_URL}/api/questions/${id}`);
    
    if (!response.ok) {
      throw new Error(`Failed to fetch question: ${response.status}`);
    }
    
    const data: QuestionData = await response.json();
    return data;
    
  } catch (error) {
    console.error('Error fetching question:', error);
    return null;
  }
}


export async function fetchAllQuestions(): Promise<QuestionData[]> {
  try {
    const response = await fetch(`${API_BASE_URL}/api/questions`);
    
    if (!response.ok) {
      throw new Error(`Failed to fetch questions: ${response.status}`);
    }
    
    const data: QuestionData[] = await response.json();
    return data;
    
  } catch (error) {
    console.error('Error fetching all questions:', error);
    return [];
  }
}
