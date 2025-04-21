namespace ElectroLab.Models
{
    public class Report
    {
        public int Id { get; set; }                  
        public int CourseId { get; set; }            
        public string ReportContent { get; set; }    
        public string? ReportType { get; set; }      
        public string ReportStatus { get; set; }     
        public string UserId { get; set; }           
        public ApplicationUser User { get; set; }    
        public Course Course { get; set; }           
    }
}
