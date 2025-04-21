namespace ElectroLab.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IList<string> Options { get; set; }
        public string CorrectAnswer { get; set; }
        public int? TestId { get; set; } 
        public Test Test { get; set; }
        public ICollection<SubmissionAnswer> SubmissionAnswers { get; set; }
    }
}
