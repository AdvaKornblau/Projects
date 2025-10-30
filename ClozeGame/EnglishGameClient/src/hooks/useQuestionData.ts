import { useState, useEffect } from 'react';
import { QuestionData } from '../types';
import { fetchQuestion } from '../services/api.service';


export function useQuestionData(questionId: number | null) {
  const [question, setQuestion] = useState<QuestionData | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (questionId === null) {
      return;
    }

    async function loadQuestion() {
      try {
        setLoading(true);
        setError(null);
        
        const data = await fetchQuestion(questionId);
        
        if (data) {
          setQuestion(data);
        } else {
          setError('Failed to load question');
        }
      } catch (err) {
        setError('An error occurred while loading the question');
        console.error(err);
      } finally {
        setLoading(false);
      }
    }

    loadQuestion();
  }, [questionId]);

  return { question, loading, error };
}
