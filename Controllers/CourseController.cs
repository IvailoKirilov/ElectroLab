using ElectroLab.Data;
using ElectroLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;


namespace ElectroLab.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            course.UserId = 

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
