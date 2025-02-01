using ElectroLab.Data;
using ElectroLab.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectroLab.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int courseId)
        {
            ViewBag.CourseId = courseId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Test test)
        {
            if (ModelState.IsValid)
            {
                _context.Tests.Add(test);
                _context.SaveChanges();
                return RedirectToAction("Details", "Course", new { id = test.CourseId });
            }
            return View(test);
        }
    }
}
