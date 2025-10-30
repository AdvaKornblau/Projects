export type GameStatus = 'FIRST_ATTEMPT' | 'SECOND_ATTEMPT' | 'REVEALED' | 'CORRECT';

export interface GameState {
    selectedWordIndex: number;
    status: GameStatus;
    showExplanation: boolean;
    totalScore: number;
}