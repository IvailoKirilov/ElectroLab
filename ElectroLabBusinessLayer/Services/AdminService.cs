using ElectroLabModels.Models;
using ElectroLabModels.ViewModels;
using ElectroLabDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ElectroLabBusinessLayer.Interfaces;



namespace ElectroLabBusinessLayer.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<AdminDashboardViewModel> GetDashboardAsync()
        {
            var reports = await _context.Reports.Where(r => r.ReportStatus == "Pending").ToListAsync();
            var logs = await _context.Logs.OrderByDescending(l => l.Time).Take(10).ToListAsync();

            return new AdminDashboardViewModel
            {
                Reports = reports,
                Logs = logs
            };
        }

        public async Task<ReportViewModel> GetReportViewModelAsync(int reportId)
        {
            var report = await _context.Reports.Include(r => r.Course).FirstOrDefaultAsync(r => r.Id == reportId);
            if (report == null) return null;

            var course = await _context.Courses.FirstOrDefaultAsync(x => x.Id == report.CourseId);

            return new ReportViewModel
            {
                ReportId = report.Id,
                ReportContent = report.ReportContent,
                ReporterUserName = report.UserId,
                ReportType = report.ReportType,
                ReportedId = report.CourseId,
                CourseContent = course?.ContentHtml
            };
        }

        public async Task<bool> HandleReportActionAsync(int id, string action, int? banDuration, string currentUserName)
        {
            var report = await _context.Reports.FirstOrDefaultAsync(r => r.Id == id);
            if (report == null) return false;

            switch (action)
            {
                case "delete":
                    await DeleteCourseAndRelatedDataAsync(report.CourseId, currentUserName);
                    break;

                case "ban":
                    if (banDuration.HasValue)
                    {
                        var user = await _userManager.FindByIdAsync(report.UserId);
                        if (user != null)
                        {
                            user.LockoutEnd = DateTimeOffset.UtcNow.AddDays(banDuration.Value);
                            user.LockoutEnabled = true;
                            await _userManager.UpdateAsync(user);

                            _context.Logs.Add(new Log
                            {
                                Action = "User Banned",
                                UserName = user.UserName,
                                Time = DateTime.Now
                            });
                        }
                    }
                    break;

                case "ignore":
                    break;

                default:
                    return false;
            }

            report.ReportStatus = "Handled";
            _context.Reports.Update(report);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task DeleteCourseAndRelatedDataAsync(int courseId, string currentUserName)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course == null) return;

            var user = await _userManager.FindByNameAsync(currentUserName);
            if (user == null) return;

            var isAdminOrOwner = await _userManager.IsInRoleAsync(user, "Admin") ||
                                 await _userManager.IsInRoleAsync(user, "Owner");
            if (!isAdminOrOwner && course.UserId != user.Id) return;

            var test = await _context.Tests.FirstOrDefaultAsync(t => t.CourseId == courseId);
            if (test != null)
            {
                var submissions = await _context.Submissions
                    .Where(s => s.TestId == test.Id)
                    .Include(s => s.SubmissionAnswers)
                    .ToListAsync();

                _context.SubmissionAnswers.RemoveRange(submissions.SelectMany(s => s.SubmissionAnswers));
                _context.Submissions.RemoveRange(submissions);

                var questions = await _context.Questions.Where(q => q.TestId == test.Id).ToListAsync();
                _context.Questions.RemoveRange(questions);

                _context.Tests.Remove(test);
            }

            var reports = _context.Reports.Where(r => r.CourseId == courseId);
            var comments = _context.Comments.Where(c => c.CourseId == courseId);

            _context.Reports.RemoveRange(reports);
            _context.Comments.RemoveRange(comments);
            _context.Courses.Remove(course);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Ban>> GetAllBansAsync()
        {
            return await _context.Bans.ToListAsync();
        }
    }
}
