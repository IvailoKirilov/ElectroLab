﻿using ElectroLab.Data;
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
                ? _context.Courses.ToList()
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
                    .Include(s => s.SubmissionAnswers)
                    .ToListAsync();

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
    }
}
