namespace ElectroLabModels.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public List<Question> Questions { get; set; }
        public ICollection<Submission> Submissions { get; set; }
    }
}
