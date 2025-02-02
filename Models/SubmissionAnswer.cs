namespace ElectroLab.Models
{
    public class SubmissionAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }

        // Foreign key for the related question
        public int? QuestionId { get; set; }
        public Question Question { get; set; }

        // Foreign key for the related submission
        public int? SubmissionId { get; set; }
        public Submission Submission { get; set; }
    }
}
