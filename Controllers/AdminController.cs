using ElectroLab.Data;
using ElectroLab.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectroLab.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AdminController(UserManager<ApplicationUser> userManager, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            var reports = await _context.Reports.Where(r => r.ReportStatus == "Pending").ToListAsync();
            var logs = await _context.Logs.OrderByDescending(l => l.Time).Take(10).ToListAsync();

            var viewModel = new AdminDashboardViewModel
            {
                Reports = reports,
                Logs = logs
            };

            return View(viewModel);
        }

        public async Task<IActionResult> ViewReport(int id)
        {
            var report = await _context.Reports
                .Include(r => r.Course)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (report == null)
            {
                return NotFound();
            }

            var viewModel = new ReportViewModel
            {
                ReportId = report.Id,
                ReportContent = report.ReportContent,
                ReporterUserName = report.UserId, // Assuming the UserId is a string
                ReportType = report.ReportType
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> HandleReport(int id, string action)
        {
            var report = await _context.Reports.FirstOrDefaultAsync(r => r.Id == id);

            if (report == null)
            {
                return NotFound();
            }

            switch (action)
            {
                case "delete":
                    // Delete the content (course or test)
                    if (report.ReportType == "Course")
                    {
                        var course = await _context.Courses.FindAsync(report.CourseId);
                        if (course != null)
                        {
                            _context.Courses.Remove(course);
                        }
                    }
                    else if (report.ReportType == "Test")
                    {
                        var test = await _context.Tests.FindAsync(report.CourseId);
                        if (test != null)
                        {
                            _context.Tests.Remove(test);
                        }
                    }
                    break;

                case "ban":
                    var user = await _userManager.FindByIdAsync(report.UserId);
                    if (user != null)
                    {
                        user.LockoutEnd = DateTimeOffset.UtcNow.AddDays(7); 
                        user.LockoutEnabled = true;
                        await _userManager.UpdateAsync(user);

                        _context.Logs.Add(new Log
                        {
                            Action = "User Banned",
                            UserName = user.UserName,
                            Time = DateTime.Now
                        });
                    }
                    break;

                case "ignore":
                    break;

                default:
                    return BadRequest();
            }

            report.ReportStatus = "Handled";
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Bans()
        {
            var bans = await _context.Bans.ToListAsync();
            return View(bans);
        }
    }
}
