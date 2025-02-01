namespace ElectroLab.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CourseId { get; set; }  
        public Course Course { get; set; }  
        public ICollection<Question> Questions { get; set; }  
    }
}
