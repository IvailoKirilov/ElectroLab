using Microsoft.AspNetCore.Identity;

namespace ElectroLab.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Course> Courses { get; set; }

    }
}
