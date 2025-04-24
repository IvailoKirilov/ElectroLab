using ElectroLabModels.Models;
using ElectroLabModels.SystemModels;

namespace ElectroLabBusinessLayer.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetCoursesAsync(string? searchTerm = null, int limit = 12);
        OperationResult Create(Course course, string userId);
        Task<OperationResult> DeleteCourseAsync(int courseId, string userId, string? username);
        Task<OperationResult> AddCommentAsync(int courseId, string userId, string commentText);
        Task<Course?> GetCourseDetailsAsync(int id);
    }
}
