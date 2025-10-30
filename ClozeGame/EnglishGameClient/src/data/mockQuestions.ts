import { QuestionData } from "../types";
export const mockQuestions: QuestionData[] = [
    {
        id: 1,
        sentenceTemplate: "Bob is ___ a pie.",
        options: ["wanted", "having", "eat"],
        correctAnswer: "having",
        points: 10,
        explanation: "We use 'is having' for present continuous tense. The structure is: subject + is/am/are + verb-ing."
    },
    {
        id: 2,
        sentenceTemplate: "They ___ to the park every Sunday.",
        options: ["go", "going", "gone"],
        correctAnswer: "go",
        points: 10,
        explanation: "We use 'go' for present simple tense. The structure is: subject + base verb."
    },
    {   id: 3,
        sentenceTemplate: "She ___ a book right now.",
        options: ["reads", "is reading", "read"],
        correctAnswer: "is reading",
        points: 10,
        explanation: "We use 'is reading' for present continuous tense. The structure is: subject + is/am/are + verb-ing."
    }
];

export const DEFAULT_QUESTION = mockQuestions[2];