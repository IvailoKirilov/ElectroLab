using ElectroLabModels.Models;
using ElectroLabModels.SystemModels;
using ElectroLabDB;
using Microsoft.EntityFrameworkCore;

namespace ElectroLabBusinessLayer
{
    public class CourseService
    {
        private ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;

        public CourseService(ApplicationDbContext dbContext, Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager)
        {
            _context = dbContext;
            _userManager = userManager;
        }

        public async Task<List<Course>> GetCoursesAsync(string? searchTerm = null, int limit = 12)
        {
            var query = _context.Courses.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(c => c.Title.Contains(searchTerm));
            }

            var courses = await query.Take(limit).ToListAsync();

            foreach (var course in courses)
            {
                course.User = await _userManager.FindByIdAsync(course.UserId);
            }

            return courses;
        }

        /// <summary>
        /// Creates course
        /// </summary>
        /// <param name="course">Course to create</param>
        /// <param name="userId">Userid</param>
        /// <returns>Returns OperationResult (Can return courseId or Unauthorized)</returns>
        public OperationResult Create(Course course, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return new OperationResult
                {
                    Success = false,
                    ErrorMessage = "Unauthorized"
                };
            }

            course.UserId = userId;

            _context.Courses.Add(course);
            _context.SaveChanges();

            return new OperationResult
            {
                Success = true,
                CreatedId = course.Id
            };
        }
        public async Task<OperationResult> DeleteCourseAsync(int courseId, string userId, string? username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return new OperationResult { Success = false, ErrorMessage = "User not authenticated." };
            }

            var course = await _context.Courses.FindAsync(courseId);
            if (course == null)
            {
                return new OperationResult { Success = false, ErrorMessage = "Course not found." };
            }

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return new OperationResult { Success = false, ErrorMessage = "User not found." };
            }

            var isAdminOrOwner = await _userManager.IsInRoleAsync(user, "Admin") ||
                                 await _userManager.IsInRoleAsync(user, "Owner");
            var isCourseOwner = course.UserId == user.Id;

            if (!isAdminOrOwner && !isCourseOwner)
            {
                return new OperationResult { Success = false, ErrorMessage = "Forbidden." };
            }

            var reports = _context.Reports.Where(r => r.CourseId == courseId);
            _context.Reports.RemoveRange(reports);

            var comments = _context.Comments.Where(c => c.CourseId == courseId);
            _context.Comments.RemoveRange(comments);

            var test = await _context.Tests.FirstOrDefaultAsync(t => t.CourseId == courseId);
            if (test != null)
            {
                var submissions = await _context.Submissions
                    .Where(s => s.TestId == test.Id)
                    .ToListAsync();

                foreach (var submission in submissions)
                {
                    var submissionAnswers = await _context.SubmissionAnswers
                        .Where(sa => sa.SubmissionId == submission.Id)
                        .ToListAsync();

                    _context.SubmissionAnswers.RemoveRange(submissionAnswers);
                }

                _context.Submissions.RemoveRange(submissions);

                var questions = await _context.Questions
                    .Where(q => q.TestId == test.Id)
                    .ToListAsync();

                _context.Questions.RemoveRange(questions);

                _context.Tests.Remove(test);
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true };
        }

        public async Task<OperationResult> AddCommentAsync(int courseId, string userId, string commentText)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course == null)
            {
                return new OperationResult { Success = false, ErrorMessage = "Course not found." };
            }

            var comment = new Comment
            {
                UserId = userId,
                CourseId = courseId,
                CommentText = commentText,
                CreatedAt = DateTime.Now
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true };
        }

        public async Task<Course?> GetCourseDetailsAsync(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            if (course == null) return null;

            course.Tests = await _context.Tests.Where(t => t.CourseId == id).ToListAsync();
            course.Comments = await _context.Comments.Where(c => c.CourseId == id).ToListAsync();

            return course;
        }

    }
}
