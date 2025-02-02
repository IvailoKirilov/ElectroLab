namespace ElectroLab.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string UserId { get; set; }
        public int Score { get; set; }

        public DateTime DateSubmitted { get; set; } = DateTime.Now;

        public Test Test { get; set; }  // Navigation property for Test
        public ApplicationUser User { get; set; }  // Navigation property for User
        public ICollection<SubmissionAnswer> SubmissionAnswers { get; set; }

    }
}
