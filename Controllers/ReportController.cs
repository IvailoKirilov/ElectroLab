using ElectroLab.Data;
using ElectroLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Create()
        {
            ViewBag.Courses = await _context.Courses.ToListAsync();
            ViewBag.Users = await _context.Users.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Report report)
        {
           
                report.ReportStatus = "Pending"; // Default status
                _context.Reports.Add(report);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); // Redirect after submission
            
        }

    }
}
