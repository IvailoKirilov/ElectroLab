using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroLabModels.Models
{
    public class SubmissionAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public int? QuestionId { get; set; }
        public Question Question { get; set; }
        public int? SubmissionId { get; set; }
        public Submission Submission { get; set; }
    }
}
