import { QuestionData, GameState } from '../../types';
import WordCycler from '../WordCycler/WordCycler';
import styles from './ClozeGame.module.css';
import { useState } from 'react';

interface ClozeGameProps {
    question: QuestionData;
    onComplete: (scoreEarned: number) => void;
    onNext: () => void;
    isLastQuestion: boolean;
}

function ClozeGame({ question, onComplete, onNext, isLastQuestion }: ClozeGameProps) {
    const [gameState, setGameState] = useState<GameState>({
        selectedWordIndex: 0,
        status: 'FIRST_ATTEMPT',
        showExplanation: false,
        totalScore: 0,
    });

    const handleWordCycle = () => {
        setGameState({
            ...gameState,
            selectedWordIndex: (gameState.selectedWordIndex + 1) % question.options.length,
        });
    };

    const handleSubmit = () => {
        const selectedWord = question.options[gameState.selectedWordIndex];
        const isCorrect = selectedWord === question.correctAnswer;
        
        if (isCorrect) {
            setGameState({
                ...gameState,
                status: 'CORRECT',
                totalScore: gameState.totalScore + question.points,
                showExplanation: true
            });

            onComplete(question.points);
            
        } else {
            if(gameState.status === 'FIRST_ATTEMPT') {
                setGameState({
                    ...gameState,
                    status: 'SECOND_ATTEMPT',
                });
            } else if (gameState.status === 'SECOND_ATTEMPT') {
                setGameState({
                    ...gameState,
                    status: 'REVEALED',
                    showExplanation: true,
                });
                onComplete(0);
            }
        }
    };

    const renderSentence = () => {
        const template = question.sentenceTemplate;
        const blankIndex = template.indexOf('___');

        if (blankIndex === -1) {
            return <span>{template}</span>;
        }
        const beforeBlank = template.slice(0, blankIndex);
        const afterBlank = template.slice(blankIndex + 3);

        return (
            <>
            {beforeBlank}
            <WordCycler
            words={question.options}
            currentIndex={gameState.selectedWordIndex}
            onClick={handleWordCycle}
            />
            {afterBlank}
            </>
        );
    };

    const isQuestionFinished = gameState.status === 'CORRECT' || gameState.status === 'REVEALED';

    return (
        <div className={styles.clozeGame}>
            <div className={styles.sentence}>
                {renderSentence()}
            </div>
            
            {!isQuestionFinished && (
            <button className={styles.submitButton} onClick={handleSubmit} disabled={gameState.status === 'CORRECT' || gameState.status === 'REVEALED'}>
                Submit 
            </button>
            )}

            {isQuestionFinished && (
            <button className={styles.nextButton} onClick={onNext} >
            {isLastQuestion ? 'Finish' : 'Next Question'}
            </button>
            )}

            <div className={styles.feedback}>
                {gameState.status === 'CORRECT' && ( <div className={styles.correct}><p>Correct! You earned {question.points} points.</p></div>)}
                {gameState.status === 'SECOND_ATTEMPT' && (<div className={styles.wrong}> <p>Incorrect. Try again!</p></div>)}
                {gameState.status === 'REVEALED' && ( <div className={styles.revealed}><p>The correct answer is: {question.correctAnswer}</p></div>)}
            </div>

            {gameState.showExplanation && (
                <div className={styles.explanation}>
                    <h4>Explanation:</h4>
                    <p>{question.explanation}</p>
                </div>
            )}
        </div>
    );
}

export default ClozeGame;
