import { useEffect, useState } from 'react';
import './App.css';
import { useQuestionData } from './hooks/useQuestionData';
import ClozeGame from './components/ClozeGame/ClozeGame';
import { fetchAllQuestions } from './services/api.service';

function App() {
  const [currentQuestionIndex, setCurrentQuestionIndex] = useState(0);
  const [totalScore, setTotalScore] = useState(0);
  const [gameFinished, setGameFinished] = useState(false);
  const [totalQuestions, setTotalQuestions] = useState(3);

  const { question, loading, error } = useQuestionData(currentQuestionIndex + 1);

  useEffect(() => {
    async function loadQuestionCount() {
      const questions = await fetchAllQuestions();
      setTotalQuestions(questions.length);
    }
    loadQuestionCount();
  }, []);

  const handleQuestionComplete = (scoreEarned: number) => {
    const newTotalScore = totalScore + scoreEarned;
    setTotalScore(newTotalScore);
  };

  const handleNextQuestion = () => {
    if (currentQuestionIndex < totalQuestions - 1) {
      setCurrentQuestionIndex(currentQuestionIndex + 1);
    } else {
      setGameFinished(true);
    }
  };

  if (loading) {
    return (
      <div className="App">
        <h1>Let's learn English together!</h1>
        <div className="loading">Loading question...</div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="App">
        <h1>Let's learn English together!</h1>
        <div className="error">Error: {error}</div>
      </div>
    );
  }

  if (!question) {
    return (
      <div className="App">
        <h1>Let's learn English together!</h1>
        <div className="error">No question available.</div>
      </div>
    );
  }

  if (gameFinished) {
    return (
      <div className="App">
        <div className="gameFinished">
        <h1>You completed all questions!</h1>
        <h2>Your total score is: {totalScore}</h2>
        <button 
            className="restartButton"
            onClick={() => {
              setCurrentQuestionIndex(0);
              setTotalScore(0);
              setGameFinished(false);
            }}
          >
          Play Again
          </button>
        </div>
      </div>
    );
  }

  return (
    <div className="App">
      <div className="gameHeader">
      <h1>Let's learn English together! </h1>
      <h3>Click on the word to cycle through options. </h3>
      
        <div className="scoreBoard">
          <span className="scoreLabel">Score:</span>
          <span className="scoreValue">{totalScore}</span>
        </div>

      <ClozeGame 
        key={question.id}
        question={question}
        onComplete={handleQuestionComplete}
        onNext={handleNextQuestion}
        isLastQuestion={currentQuestionIndex === totalQuestions - 1}
      />
      </div>
    </div>
  );
}

export default App;
