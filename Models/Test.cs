namespace ElectroLab.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        // Navigation property for related questions
        public List<Question> Questions { get; set; }

        // Navigation property for related submissions
        public ICollection<Submission> Submissions { get; set; }
    }
}
