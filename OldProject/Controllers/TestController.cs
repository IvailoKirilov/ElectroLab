using ElectroLab.Data;
using ElectroLab.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectroLab.Controllers
{
    public class TestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TestController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // [HTTP GET] /Test/Index
        // Route: Index (Default page for Test)
        // Action to list tests (optional search term)
        public IActionResult Index(string searchTerm)
        {
            var courses = string.IsNullOrEmpty(searchTerm)
                ? _context.Tests.ToList()
                : _context.Tests
                    .Where(c => c.Title.Contains(searchTerm))
                    .ToList();

            ViewData["SearchTerm"] = searchTerm;

            return View(courses);
        }
        // [HTTP GET] /Test/Create/{courseId}
        // Route: Create (Used to render the form to create a new test)
        public IActionResult Create(int courseId)
        {
            ViewBag.CourseId = courseId;
            return View();
        }

        // [HTTP POST] /Test/Create
        // Route: Create (Used to save a new test into the database)
        [HttpPost]
        public async Task<IActionResult> Create(Test test)
        {
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();

            foreach (var question in test.Questions)
            {
                question.TestId = test.Id;

                string[] parts = question.CorrectAnswer.Split(' ');
                if (parts.Length > 1)
                {
                    int index = int.Parse(parts[1]) - 1;

                    if (index >= 0 && index < question.Options.Count)
                    {
                        question.CorrectAnswer = question.Options[index];
                        Console.WriteLine(question.CorrectAnswer);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index for correct answer.");
                    }
                }
                else
                {
                    Console.WriteLine("CorrectAnswer format is invalid.");
                }

                Console.WriteLine($"CorrectAnswer for Question: {question.CorrectAnswer}");

                _context.Questions.Add(question);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        // [HTTP GET] /Test/TakeTest/{id}?isFromCourse={isFromCourse}
        // Route: TakeTest (To show the test to take, with or without course context)
        [HttpGet]
        public async Task<IActionResult> TakeTest(int id, bool isFromCourse = false)
        {
            if (!isFromCourse)
            {
                var test = await _context.Tests
                                         .Include(t => t.Questions)
                                         .FirstOrDefaultAsync(t => t.Id == id);

                if (test == null)
                {
                    return NotFound();
                }

                return View(test);
            }
            else
            {
                var test = await _context.Tests
                                         .Include(t => t.Questions)
                                         .FirstOrDefaultAsync(t => t.CourseId == id);

                if (test == null)
                {
                    return NotFound();
                }

                return View(test);
            }
        }

        // [HTTP POST] /Test/SubmitTest
        // Route: SubmitTest (Used to submit the test answers and calculate the score)
        [HttpPost]
        public async Task<IActionResult> SubmitTest(int testId, List<SubmissionAnswer> submissionAnswers)
        {
            if (submissionAnswers.Any(sa => string.IsNullOrEmpty(sa.Answer)))
            {
                ModelState.AddModelError("", "Please answer all questions.");
                return View("TakeTest", await _context.Tests.Include(t => t.Questions).FirstOrDefaultAsync(t => t.Id == testId));
            }

            var test = await _context.Tests.FirstOrDefaultAsync(t => t.Id == testId);
            if (test == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var questions = await _context.Questions
                                          .Where(q => q.TestId == testId)
                                          .ToListAsync();
            if (questions == null || questions.Count == 0)
            {
                return NotFound();
            }

            var submission = new Submission
            {
                TestId = test.Id,
                UserId = user.Id,
                DateSubmitted = DateTime.Now
            };

            _context.Submissions.Add(submission);
            await _context.SaveChangesAsync();

            int score = 0;
            var submissionAnswerList = new List<SubmissionAnswer>();

            foreach (var answer in submissionAnswers)
            {
                var question = questions.FirstOrDefault(q => q.Id == answer.QuestionId);

                if (question != null)
                {
                    string[] parts = question.CorrectAnswer.Split(' ');
                    string actualCorrectAnswer = "";

                    if (parts.Length > 1 && int.TryParse(parts[1], out int index))
                    {
                        index -= 1;
                        if (index >= 0 && index < question.Options.Count)
                        {
                            actualCorrectAnswer = question.Options[index];
                        }
                    }

                    var submissionAnswer = new SubmissionAnswer
                    {
                        QuestionId = question.Id,
                        SubmissionId = submission.Id,
                        Answer = answer.Answer,
                        IsCorrect = actualCorrectAnswer == answer.Answer
                    };

                    score += submissionAnswer.IsCorrect ? 1 : 0;
                    submissionAnswerList.Add(submissionAnswer);
                }
            }

            _context.SubmissionAnswers.AddRange(submissionAnswerList);

            submission.Score = score;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ViewResult), new { submissionId = submission.Id });
        }

        // [HTTP GET] /Test/ViewResult/{submissionId}
        // Route: ViewResult (To show the result of a submitted test)
        public async Task<IActionResult> ViewResult(int submissionId)
        {
            var userId = _userManager.GetUserId(User);
            var applicationUser = await _userManager.FindByIdAsync(userId);

            // Fetch the submission
            var submission = await _context.Submissions
                .Include(s => s.Test)
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == submissionId);

            if (submission == null)
            {
                return NotFound();
            }

            var isAdmin = await _userManager.IsInRoleAsync(applicationUser, "Admin");

            if (submission.UserId != userId && !isAdmin)
            {
                return Forbid();
            }

            submission.SubmissionAnswers = await _context.SubmissionAnswers
                .Include(sa => sa.Question)
                .Where(sa => sa.SubmissionId == submissionId)
                .ToListAsync();


            foreach (var answer in submission.SubmissionAnswers)
            {
                if (answer.Question != null)
                {
                    string[] parts = answer.Question.CorrectAnswer.Split(' ');
                    if (parts.Length > 1 && int.TryParse(parts[1], out int index))
                    {
                        index -= 1;
                        if (index >= 0 && index < answer.Question.Options.Count)
                        {
                            answer.Question.CorrectAnswer = answer.Question.Options[index];
                        }
                    }
                }
            }

            return View(submission);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int testId)
        {
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

            var test = await _context.Tests
                .FirstOrDefaultAsync(t => t.CourseId == testId);

            if (test == null)
            {
                return NotFound();
            }



            var course = await _context.Courses
                .FirstOrDefaultAsync(c => c.Id == test.CourseId);

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

            return RedirectToAction(nameof(Index));
        }
    }
}
