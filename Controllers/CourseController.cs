using ElectroLab.Data;
using ElectroLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace ElectroLab.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public CourseController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        async public Task<IActionResult> Index()
        {
            var courses = _context.Courses.ToList();

            foreach (var course in courses)
            {
                course.User = await _userManager.FindByIdAsync(course.UserId.ToString());
            }

            return View(courses);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(); 
            }

            course.UserId = userId; 

            _context.Courses.Add(course);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int id)
        {
            var course = _context.Courses
                .Where(c => c.Id == id)
                .FirstOrDefault();
            if (course == null) return NotFound();
            return View(course);
        }

        public IActionResult Delete(int courseId)
        {
            var course = _context.Courses
     .Where(c => c.Id == courseId)
     .FirstOrDefault();
            if (course == null) return NotFound();
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
