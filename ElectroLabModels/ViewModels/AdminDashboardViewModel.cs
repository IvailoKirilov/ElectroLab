using ElectroLabModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroLabModels.ViewModels
{
    public class AdminDashboardViewModel
    {
        public IEnumerable<Report> Reports { get; set; }
        public IEnumerable<Log> Logs { get; set; }
    }
}
