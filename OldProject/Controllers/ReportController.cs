using ElectroLab.Data;
using ElectroLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ElectroLab.Controllers
{
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create(int? courseId)
        {
            if (!courseId.HasValue)
            {
                return RedirectToAction("Index", "Home"); 
            }

            var report = new Report();

            report.CourseId = courseId.Value;
            report.ReportType = "Course"; 

            ViewBag.Courses = _context.Courses.ToList();
            ViewBag.Users = _context.Users.ToList();

            return View(report);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Report report)
        {
            report.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            report.ReportStatus = "Pending";

            var courseExists = await _context.Courses.AnyAsync(c => c.Id == report.CourseId);

            if (!courseExists)
            {
                ModelState.AddModelError("CourseId", "The specified course does not exist.");
                return View(report);
            }

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

    }
}
