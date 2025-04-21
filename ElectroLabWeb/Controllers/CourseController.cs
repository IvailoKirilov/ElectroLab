using Microsoft.AspNetCore.Mvc;
using ElectroLabBusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;
using System.Security.Claims;
using ElectroLabModels.Models;

namespace ElectroLabWeb.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: /Course/Index?searchTerm=...
        public async Task<IActionResult> Index(string searchTerm)
        {
            var courses = await _courseService.GetCoursesAsync(searchTerm);
            ViewData["SearchTerm"] = searchTerm;
            return View(courses);
        }

        // GET: /Course/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Course/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int courseId)
        {
            var userId = User.Identity?.Name;

            var result = await _courseService.DeleteCourseAsync(courseId, userId, User.Identity.GetUserName());

            if (!result.Success)
            {
                return result.ErrorMessage switch
                {
                    "User not authenticated." => RedirectToAction("Login", "Account"),
                    "User not found." => Unauthorized(),
                    "Course not found." => NotFound(),
                    "Forbidden." => Forbid(),
                    _ => BadRequest(result.ErrorMessage)
                };
            }

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

            var result = await _courseService.AddCommentAsync(courseId, userId, commentText);

            if (!result.Success)
            {
                return result.ErrorMessage switch
                {
                    "Course not found." => NotFound(),
                    _ => BadRequest(result.ErrorMessage)
                };
            }

            return RedirectToAction("Details", new { id = courseId });
        }

        public async Task<IActionResult> Details(int id)
        {
            var course = await _courseService.GetCourseDetailsAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(Course course)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var result = _courseService.Create(course, userId);

            if (!result.Success)
            {
                return BadRequest(result.ErrorMessage);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
