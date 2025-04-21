using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroLabModels.ViewModels
{
    public class ReportViewModel
    {
        public int ReportId { get; set; }
        public string ReportContent { get; set; }
        public string ReporterUserName { get; set; }
        public string ReportType { get; set; }
        public int ReportedId { get; set; }
        public string CourseContent { get; set; }
    }
}
