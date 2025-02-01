namespace ElectroLab.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<string> Options { get; set; }  
        public string CorrectAnswer { get; set; }  
        public int TestId { get; set; }  
        public Test Test { get; set; }  
    }
}
