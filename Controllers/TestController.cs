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
      //  async public Task<IActionResult> Index()
     //   {
      //      var tests = _context.Tests.ToList();

          //  foreach (var course in courses)
          //  {
          //  course.User = await _userManager.FindByIdAsync(course.UserId.ToString());
          //  }

       //     return View(tests);
      //  }

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


            foreach (var question in test.Questions)
            {
                question.TestId = test.Id;


                string[] parts = question.CorrectAnswer.Split(' ');
                if (parts.Length > 1)
                {
                    int index = int.Parse(parts[1]) - 1;  // Zero-based index

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


        [HttpGet]
        public async Task<IActionResult> TakeTest(int id)
        {
            var test = await _context.Tests
                                     .Include(t => t.Questions)  
                                     .FirstOrDefaultAsync(t => t.Id == id);

            if (test == null)
            {
                return NotFound();
            }

            await Console.Out.WriteLineAsync(test.Questions.Count.ToString());

            return View(test);
        }


        [HttpPost]
        public async Task<IActionResult> SubmitTest(int testId, List<SubmissionAnswer> submissionAnswers)
        {
            await Console.Out.WriteLineAsync($"Received {submissionAnswers.Count} answers.");

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

            submission.SubmissionAnswers = await _context.SubmissionAnswers
                .Include(sa => sa.Question)
                .Where(sa => sa.SubmissionId == submissionId)
                .ToListAsync();

            Console.WriteLine($"📌 Submission ID: {submission.Id}, Answers Count: {submission.SubmissionAnswers.Count}");

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

                    Console.WriteLine($"➡ Answer: {answer.Answer}, QuestionId: {answer.QuestionId}, IsCorrect: {answer.IsCorrect}, " +
                                      $"Correct Answer: {answer.Question.CorrectAnswer}, Question: {answer.Question.Text}");
                }
            }

            return View(submission);
        }

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
    }
}
