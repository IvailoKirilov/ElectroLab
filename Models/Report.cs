namespace ElectroLab.Models
{
    public class Report
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string ReportContent { get; set; }

        public string UserReportedId { get; set; }

        // COURSE/TEST/USER
        public string ReportType { get; set; }

        public string ReportStatus { get; set; }

        public Course Course { get; set; }

        public ApplicationUser UserReported { get; set; }
    }
}
