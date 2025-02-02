namespace ElectroLab.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IList<string> Options { get; set; }
        public string CorrectAnswer { get; set; }
        public int? TestId { get; set; }  // Link to Test

        // Navigation property for the related Test
        public Test Test { get; set; }

        // Navigation property for related submission answers
        public ICollection<SubmissionAnswer> SubmissionAnswers { get; set; }
    }
}
