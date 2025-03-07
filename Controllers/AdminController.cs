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

                        var course = _context.Courses
                    .Where(c => c.Id == report.CourseId)
                    .FirstOrDefault();

                        var testId = 1;

                        if (course == null) return NotFound();


                        var reports = _context.Reports.Where(x => x.CourseId == report.CourseId);


                        foreach (var report_ in reports)
                        {
                            _context.Reports.Remove(report_);
                        }

                        var comments = _context.Comments.Where(x => x.CourseId == report.CourseId);

                        foreach (var comment in comments)
                        {
                            _context.Comments.Remove(comment);
                        }

                        var test = _context.Tests.FirstOrDefault(x => x.CourseId == course.Id);
                        if (test != null)
                        {
                            testId = test.Id;
                        }
                        else
                        {
                            testId = -1;
                        }

                        var userId = User.Identity?.Name;

                        if (string.IsNullOrEmpty(userId))
                        {
                            return RedirectToAction("Login", "Account");
                        }

                        var user = await _userManager.FindByNameAsync(userId);

                        if (user == null)
                        {
                            return Unauthorized();
                        }


                    if (test != null)
                    {

                        var submissions = await _context.Submissions
                            .Where(s => s.TestId == testId)
                            .ToListAsync();

                        foreach (var submission in submissions)
                        {
                            submission.SubmissionAnswers = await _context.SubmissionAnswers
                                .Where(sa => sa.SubmissionId == submission.Id)
                                .ToListAsync();
                        }

                        var questions = await _context.Questions
                            .Where(q => q.TestId == testId)
                            .ToListAsync();

                        if (course == null)
                        {
                            return NotFound("Course not found.");
                        }

                        var isAdminOrOwner = await _userManager.IsInRoleAsync(user, "Admin") ||
                                             await _userManager.IsInRoleAsync(user, "Owner");

                        var isCourseOwner = course.UserId == user.Id;

                        if (!isAdminOrOwner && !isCourseOwner)
                        {
                            return Forbid();
                        }

                        foreach (var submission in submissions)
                        {
                            foreach (var submissionAnswer in submission.SubmissionAnswers)
                            {
                                _context.SubmissionAnswers.Remove(submissionAnswer);
                            }
                            _context.Submissions.Remove(submission);
                        }

                        foreach (var question in questions)
                        {
                            _context.Questions.Remove(question);
                        }

                        _context.Tests.Remove(test);
                        await _context.SaveChangesAsync();
                    }

                    _context.Courses.Remove(course);
                    await _context.SaveChangesAsync();
                    break;


                case "ban":
                    if (banDuration.HasValue)
                    {
                        var user_ = await _userManager.FindByIdAsync(report.UserId);
                        if (user_ != null)
                        {
                            user_.LockoutEnd = DateTimeOffset.UtcNow.AddDays(banDuration.Value);
                            user_.LockoutEnabled = true;
                            await _userManager.UpdateAsync(user_);

                            _context.Logs.Add(new Log
                            {
                                Action = "User Banned",
                                UserName = user_.UserName,
                                Time = DateTime.Now
                            });

                            report.ReportStatus = "Handled";
                            _context.Reports.Update(report);
                            await _context.SaveChangesAsync();

                        }
                    }

                    break;


                case "ignore":
                    report.ReportStatus = "Handled";
                    _context.Reports.Update(report);
                    await _context.SaveChangesAsync();
                    break;
                default:
                    return BadRequest();
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Bans()
        {
            var bans = await _context.Bans.ToListAsync();
            return View(bans);
        }
    }
}
