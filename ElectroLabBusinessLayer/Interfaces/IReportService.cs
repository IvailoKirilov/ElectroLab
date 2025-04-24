using ElectroLabModels.Models;

namespace ElectroLabBusinessLayer.Interfaces
{
    public interface IReportService
    {
        Task<Report?> PrepareNewReportAsync(int courseId);
        Task<List<Course>> GetCoursesAsync();
        Task<List<ApplicationUser>> GetUsersAsync();
        Task<(bool Success, string? ErrorMessage)> CreateReportAsync(Report report, string? userId);
    }
}
