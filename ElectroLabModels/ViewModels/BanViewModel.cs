using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroLabModels.ViewModels
{
    public class BanViewModel
    {
        public string UserName { get; set; }
        public DateTime BanDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Reason { get; set; }
    }
}
