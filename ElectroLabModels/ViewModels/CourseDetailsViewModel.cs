using ElectroLabModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroLabModels.ViewModels
{
    public class CourseDetailsViewModel
    {
        public Course Course { get; set; }
        public bool TestExists { get; set; }
    }
}
