using Microsoft.AspNetCore.Identity;

namespace ElectroLabModels.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Course> Courses { get; set; }

        public ICollection<Submission> Submissions { get; set; }

        public ICollection<Report> Reports { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
