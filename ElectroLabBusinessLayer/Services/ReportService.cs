using ElectroLabModels.Models;
using ElectroLabDB;
using Microsoft.EntityFrameworkCore;
using ElectroLabBusinessLayer.Interfaces;


namespace ElectroLabBusinessLayer.Services
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _context;

        public ReportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Report?> PrepareNewReportAsync(int courseId)
        {
            var courseExists = await _context.Courses.AnyAsync(c => c.Id == courseId);
            if (!courseExists) return null;

            return new Report
            {
                CourseId = courseId,
                ReportType = "Course"
            };
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<List<ApplicationUser>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<(bool Success, string? ErrorMessage)> CreateReportAsync(Report report, string? userId)
        {
            if (string.IsNullOrEmpty(userId))
                return (false, "User not authenticated");

            var courseExists = await _context.Courses.AnyAsync(c => c.Id == report.CourseId);
            if (!courseExists)
                return (false, "The specified course does not exist.");

            report.UserId = userId;
            report.ReportStatus = "Pending";

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            return (true, null);
        }
    }
}
