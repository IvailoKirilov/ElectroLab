namespace ElectroLab.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CourseId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedAt { get; set; }
        public ApplicationUser User { get; set; }
        public Course Course { get; set; }
    }
}
