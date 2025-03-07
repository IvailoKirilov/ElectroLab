using ElectroLab.Data;
using ElectroLab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


namespace ElectroLab.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public CourseController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        async public Task<IActionResult> Index(string searchTerm)
        {
            var courses = string.IsNullOrEmpty(searchTerm)
                ? _context.Courses.Take(12).ToList()
                : _context.Courses
                    .Where(c => c.Title.Contains(searchTerm))
                    .ToList();

            ViewData["SearchTerm"] = searchTerm;

            foreach (var course in courses)
            {
                course.User = await _userManager.FindByIdAsync(course.UserId.ToString());
            }

            return View(courses);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Course course)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            course.UserId = userId;

            _context.Courses.Add(course);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int id)
        {
            var course = _context.Courses
                .Where(c => c.Id == id)
                .FirstOrDefault();

            course.Tests = [];

            foreach (var test in _context.Tests)
            {
                if (test.CourseId == id)
                {
                    course.Tests.Add(test);
                }
            }

            course.Comments = [];

            foreach (var comment in _context.Comments)
            {
                if (comment.CourseId == id)
                {
                    course.Comments.Add(comment);
                }
            }

            if (course == null) return NotFound();
            return View(course);
        }

        public async Task<IActionResult> Delete(int courseId)
        {
            var course = _context.Courses
     .Where(c => c.Id == courseId)
     .FirstOrDefault();

            var testId = 1;

            if (course == null) return NotFound();


            var reports = _context.Reports.Where(x => x.CourseId == courseId);
            

            foreach(var report in reports)
            {
                _context.Reports.Remove(report);
            }

            var comments = _context.Comments.Where(x => x.CourseId == courseId);

            foreach(var comment in comments)
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


            if(test != null)
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

                // Fetch the questions related to the test manually
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
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int courseId, string commentText)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var course = await _context.Courses.FindAsync(courseId);
            if (course == null)
            {
                return NotFound();
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

            return RedirectToAction("Details", new { id = courseId });
        }
    }
}
