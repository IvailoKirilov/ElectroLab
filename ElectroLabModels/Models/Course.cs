namespace ElectroLabModels.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ContentHtml { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ICollection<Test> Tests { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
