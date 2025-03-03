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

            var course = await _context.Courses
                .FirstOrDefaultAsync( x => x.Id == report.CourseId);

            if (report == null)
            {
                return NotFound();
            }

            var viewModel = new ReportViewModel
            {
                ReportId = report.Id,
                ReportContent = report.ReportContent,
                ReporterUserName = report.UserId,
                ReportType = report.ReportType,
                ReportedId = report.CourseId,
                CourseContent = course.ContentHtml
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> HandleReport(int id, string action, int? banDuration)
        {
            var report = await _context.Reports.FirstOrDefaultAsync(r => r.Id == id);

            if (report == null)
            {
                return NotFound();
            }

            switch (action)
            {
                case "delete":
                    // Handle the deletion of content based on the report type (Course or Test)
                    if (report.ReportType == "Course")
                    {
                        var course = await _context.Courses.FindAsync(report.CourseId);
                        if (course != null)
                        {
                            _context.Courses.Remove(course);
                            TempData["Message"] = "Course has been deleted successfully.";
                        }
                    }
                    else if (report.ReportType == "Test")
                    {
                        var test = await _context.Tests.FindAsync(report.CourseId);
                        if (test != null)
                        {
                            _context.Tests.Remove(test);
                            TempData["Message"] = "Test has been deleted successfully.";
                        }
                    }
                    break;

                case "ban":
                    // Ensure that the banDuration parameter is provided when the action is 'ban'
                    if (banDuration.HasValue)
                    {
                        var user = await _userManager.FindByIdAsync(report.UserId);
                        if (user != null)
                        {
                            user.LockoutEnd = DateTimeOffset.UtcNow.AddDays(banDuration.Value);
                            user.LockoutEnabled = true;
                            await _userManager.UpdateAsync(user);

                            // Log the action in the logs table
                            _context.Logs.Add(new Log
                            {
                                Action = "User Banned",
                                UserName = user.UserName,
                                Time = DateTime.Now
                            });

                        }
                    }

                    break;

                default:
                    return BadRequest();
            }

            report.ReportStatus = "Handled";
            _context.Reports.Update(report);
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
