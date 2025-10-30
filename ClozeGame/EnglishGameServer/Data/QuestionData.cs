using EnglishGameServer.Models;

namespace EnglishGameServer.Data
{
    public static class QuestionsData
    {
        public static List<Question> GetAllQuestions()
        {
            return new List<Question>
            {
                new Question
                {
                    Id = 1,
                    SentenceTemplate = "Bob is ___ a pie.",
                    Options = new List<string> { "wanted", "having", "eat" },
                    CorrectAnswer = "having",
                    Points = 10,
                    Explanation = "We use 'is having' for present continuous tense. The structure is: subject + is/am/are + verb-ing."
                },
                new Question
                {
                    Id = 2,
                    SentenceTemplate = "She ___ to school every day.",
                    Options = new List<string> { "go", "goes", "going", "gone" },
                    CorrectAnswer = "goes",
                    Points = 10,
                    Explanation = "With 'she' (third person singular), we add 's' to the verb in present simple tense."
                },
                new Question
                {
                    Id = 3,
                    SentenceTemplate = "They ___ playing football now.",
                    Options = new List<string> { "is", "are", "am" },
                    CorrectAnswer = "are",
                    Points = 10,
                    Explanation = "We use 'are' with plural subjects like 'they' in present continuous tense."
                },
                new Question
                {
                    Id = 4,
                    SentenceTemplate = "I ___ a book at the moment.",
                    Options = new List<string> { "read", "reads", "am reading", "readed", "reading" },
                    CorrectAnswer = "am reading",
                    Points = 10,
                    Explanation = "We use 'am reading' for present continuous tense with the subject 'I'."
                },
                new Question
                {
                    Id = 5,
                    SentenceTemplate = "He ___ his homework every evening.",
                    Options = new List<string> { "do", "does", "doing" },
                    CorrectAnswer = "does",
                    Points = 10,
                    Explanation = "With 'he' (third person singular), we add 's' to the verb in present simple tense."
                }
            };
        }

        public static Question? GetQuestionById(int id)
        {
            return GetAllQuestions().FirstOrDefault(q => q.Id == id);
        }
    }
}
