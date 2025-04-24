using ElectroLabModels.Models;

namespace ElectroLabViewModels
{
    public class AdminDashboardViewModel
    {
        public IEnumerable<Report> Reports { get; set; }
        public IEnumerable<Log> Logs { get; set; }
    }
}
