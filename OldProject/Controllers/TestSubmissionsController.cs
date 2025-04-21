using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectroLab.Models;
using Microsoft.AspNetCore.Identity;
using ElectroLab.Data;

namespace ElectroLab.Controllers
{
    public class TestSubmissionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TestSubmissionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TestSubmissions/TakeTest/5
        public async Task<IActionResult> TakeTest(int? testId)
        {
            if (testId == null)
            {
                return NotFound();
            }

            var test = await _context.Tests
                .Include(t => t.Questions)
                .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(t => t.Id == testId);

            if (test == null)
            {
                return NotFound();
            }

            return View(test);
        }

        // POST: TestSubmissions/SubmitTest
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitTest(int testId, List<SubmissionAnswer> answers)
        {
            var userId = _userManager.GetUserId(User);

            var test = await _context.Tests
                .Include(t => t.Questions)
                .FirstOrDefaultAsync(t => t.Id == testId);

            if (test == null)
            {
                return NotFound();
            }

            // Calculate score
            var score = 0;
            foreach (var answer in answers)
            {
                var question = test.Questions.FirstOrDefault(q => q.Id == answer.QuestionId);
                if (question != null && question.CorrectAnswer == answer.Answer)
                {
                    score++;
                }
            }

            // Create Submission entry
            var submission = new Submission
            {
                TestId = testId,
                UserId = userId,
                Score = score
            };

            _context.Add(submission);
            await _context.SaveChangesAsync();

            // Add SubmissionAnswers for each question
            foreach (var answer in answers)
            {
                answer.SubmissionId = submission.Id;
                _context.Add(answer);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ViewSubmissions));
        }

        // GET: TestSubmissions/ViewSubmissions
        public async Task<IActionResult> ViewSubmissions()
        {
            var userId = _userManager.GetUserId(User);

            var submissions = await _context.Submissions
                .Where(s => s.UserId == userId)
                .Include(s => s.Test)
                .OrderByDescending(s => s.DateSubmitted)
                .ToListAsync();

            return View(submissions);
        }
    }
}
