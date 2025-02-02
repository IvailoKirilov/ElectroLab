using ElectroLab.Data;
using ElectroLab.Models;
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
        async public Task<IActionResult> Index()
        {
            var tests = _context.Tests.ToList();

          //  foreach (var course in courses)
            //{
              //  course.User = await _userManager.FindByIdAsync(course.UserId.ToString());
          //  }

            return View(tests);
        }

        public IActionResult Create(int courseId)
        {
            ViewBag.CourseId = courseId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Test test)
        {

                _context.Tests.Add(test);
                await _context.SaveChangesAsync(); 

                // Now, assign the generated Test.Id to each Question
                foreach (var question in test.Questions)
                {
                    question.TestId = test.Id; 
                    _context.Questions.Add(question); 
                }

            try
            {
             await _context.SaveChangesAsync();
            }
            catch
            {

            }

                return RedirectToAction(nameof(Index));
            
        }

        [HttpGet]
        public async Task<IActionResult> TakeTest(int id)
        {
            var test = await _context.Tests
                                     .Include(t => t.Questions)  // Ensure the Questions are loaded
                                     .FirstOrDefaultAsync(t => t.Id == id);

            if (test == null)
            {
                return NotFound();
            }

            // You no longer need to manually add questions since they are already loaded with Include.
            // Just output the number of questions for debugging
            await Console.Out.WriteLineAsync(test.Questions.Count.ToString());

            return View(test);
        }


        [HttpPost]
        public async Task<IActionResult> SubmitTest(int testId, List<SubmissionAnswer> submissionAnswers)
        {
            // Debugging: Check if the submissionAnswers count is correct
            await Console.Out.WriteLineAsync(submissionAnswers.Count.ToString());

            // Fetch the test by id
            var test = await _context.Tests
                                     .FirstOrDefaultAsync(t => t.Id == testId);

            if (test == null)
            {
                return NotFound();
            }

            // Get the user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            // Fetch the related questions manually
            var questions = await _context.Questions
                                          .Where(q => q.TestId == testId)
                                          .ToListAsync();

            if (questions == null || questions.Count == 0)
            {
                return NotFound(); // Handle the case where no questions are found
            }

            // Create a new submission entry
            var submission = new Submission
            {
                TestId = test.Id,
                UserId = user.Id,
                DateSubmitted = DateTime.Now
            };

            // Add the submission first
            _context.Submissions.Add(submission);
            await _context.SaveChangesAsync();  // Save first to get the Submission Id

            // Calculate score and populate SubmissionAnswers
            int score = 0;

            foreach (var answer in submissionAnswers)
            {
                var question = questions.FirstOrDefault(q => q.Id == answer.QuestionId);

                if (question != null)
                {
                    // Check if the answer is correct
                    answer.IsCorrect = question.CorrectAnswer == answer.Answer;
                    score += answer.IsCorrect ? 1 : 0;

                    // Set the foreign key
                    answer.SubmissionId = submission.Id;

                    // Add the SubmissionAnswer to the context
                    _context.SubmissionAnswers.Add(answer);
                }
            }

            // After processing all answers, save everything together
            submission.Score = score;
            await _context.SaveChangesAsync();  // Save both the Submission and SubmissionAnswers in one batch

            // Redirect to result page with the submissionId
            return RedirectToAction(nameof(ViewResult), new { submissionId = submission.Id });
        }





        public async Task<IActionResult> ViewResult(int submissionId)
        {
            var submission = await _context.Submissions
                .Include(s => s.Test)
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == submissionId);

            if (submission == null)
            {
                return NotFound();
            }

            // Ensure SubmissionAnswers are loaded
            submission.SubmissionAnswers = await _context.SubmissionAnswers
                .Where(sa => sa.SubmissionId == submissionId)
                .Include(sa => sa.Question)
                .ToListAsync();

            Console.WriteLine($"📌 Submission ID: {submission.Id}, Answers Count: {submission.SubmissionAnswers.Count}");
            foreach (var answer in submission.SubmissionAnswers)
            {
                Console.WriteLine($"➡ Answer: {answer.Answer}, QuestionId: {answer.QuestionId}, IsCorrect: {answer.IsCorrect}, Question: {(answer.Question != null ? answer.Question.Text : "NULL")}");
            }

            return View(submission);
        }









    }
}
