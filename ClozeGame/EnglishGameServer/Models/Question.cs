namespace EnglishGameServer.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string SentenceTemplate { get; set; } = string.Empty;
        public List<string> Options { get; set; } = new();
        public string CorrectAnswer { get; set; } = string.Empty;
        public int Points { get; set; }
        public string Explanation { get; set; } = string.Empty;
    }
}
