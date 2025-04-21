using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroLabModels.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public string UserName { get; set; }
        public DateTime Time { get; set; }
    }
}
