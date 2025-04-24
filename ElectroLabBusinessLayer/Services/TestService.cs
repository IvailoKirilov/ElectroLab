using ElectroLabBusinessLayer.Interfaces;
using ElectroLabDB;
using ElectroLabModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ElectroLabBusinessLayer.Services
{
    public class TestService : ITestService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public static readonly Submission ForbiddenSubmission = new();

        public TestService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Test> GetTests(string searchTerm)
        {
            return string.IsNullOrEmpty(searchTerm)
                ? _context.Tests.ToList()
                : _context.Tests.Where(t => t.Title.Contains(searchTerm)).ToList();
        }

        public async Task CreateTestAsync(Test test)
        {
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();  // Save the Test first to generate the TestId

            foreach (var question in test.Questions)
            {
                question.TestId = test.Id;  // Now that the TestId is valid, assign it to the question

                if (question.CorrectAnswer.Split(' ') is [_, var indexStr] &&
                    int.TryParse(indexStr, out var index) &&
                    index > 0 && index <= question.Options.Count)
                {
                    question.CorrectAnswer = question.Options[index - 1];
                }

                _context.Questions.Add(question);
            }

            await _context.SaveChangesAsync();  // Now save the Questions
        }


        public async Task<Test?> GetTestForTakingAsync(int id, bool isFromCourse = false)
        {
            return await _context.Tests
                .Include(t => t.Questions)
                .FirstOrDefaultAsync(t => isFromCourse ? t.CourseId == id : t.Id == id);
        }

        public async Task<(bool Success, string? ErrorMessage, int SubmissionId)> SubmitTestAsync(
            int testId, List<SubmissionAnswer> submissionAnswers, ApplicationUser user)
        {
            if (submissionAnswers.Any(sa => string.IsNullOrEmpty(sa.Answer)))
                return (false, "Please answer all questions.", 0);

            var test = await _context.Tests.FindAsync(testId);
            var questions = await _context.Questions.Where(q => q.TestId == testId).ToListAsync();

            if (test == null || questions.Count == 0 || user == null)
                return (false, "Invalid test or user", 0);

            var submission = new Submission
            {
                TestId = testId,
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
                if (question == null) continue;

                string actualCorrectAnswer = "";
                if (question.CorrectAnswer.Split(' ') is [_, var indexStr] &&
                    int.TryParse(indexStr, out var index) &&
                    index > 0 && index <= question.Options.Count)
                {
                    actualCorrectAnswer = question.Options[index - 1];
                }

                var isCorrect = actualCorrectAnswer == answer.Answer;
                score += isCorrect ? 1 : 0;

                submissionAnswerList.Add(new SubmissionAnswer
                {
                    QuestionId = question.Id,
                    SubmissionId = submission.Id,
                    Answer = answer.Answer,
                    IsCorrect = isCorrect
                });
            }

            _context.SubmissionAnswers.AddRange(submissionAnswerList);
            submission.Score = score;

            await _context.SaveChangesAsync();
            return (true, null, submission.Id);
        }

        public async Task<Submission?> GetSubmissionWithResultsAsync(int submissionId, ApplicationUser user)
        {
            var submission = await _context.Submissions
                .Include(s => s.Test)
                .Include(s => s.User)
                .FirstOrDefaultAsync(s => s.Id == submissionId);

            if (submission == null || user == null) return null;

            bool isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            if (submission.UserId != user.Id && !isAdmin)
                return ForbiddenSubmission;

            submission.SubmissionAnswers = await _context.SubmissionAnswers
                .Include(sa => sa.Question)
                .Where(sa => sa.SubmissionId == submissionId)
                .ToListAsync();

            foreach (var answer in submission.SubmissionAnswers)
            {
                if (answer.Question?.CorrectAnswer.Split(' ') is [_, var indexStr] &&
                    int.TryParse(indexStr, out var index) &&
                    index > 0 && index <= answer.Question.Options.Count)
                {
                    answer.Question.CorrectAnswer = answer.Question.Options[index - 1];
                }
            }

            return submission;
        }

        public async Task<bool> DeleteTestAsync(int testId, ApplicationUser user)
        {
            if (user == null) return false;

            var test = await _context.Tests.FirstOrDefaultAsync(t => t.CourseId == testId);
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == test.CourseId);

            if (test == null || course == null) return false;

            bool isAdminOrOwner = await _userManager.IsInRoleAsync(user, "Admin") ||
                                  await _userManager.IsInRoleAsync(user, "Owner");
            bool isCourseOwner = course.UserId == user.Id;

            if (!isAdminOrOwner && !isCourseOwner) return false;

            var submissions = await _context.Submissions
                .Where(s => s.TestId == testId)
                .Include(s => s.SubmissionAnswers)
                .ToListAsync();

            _context.SubmissionAnswers.RemoveRange(submissions.SelectMany(s => s.SubmissionAnswers));
            _context.Submissions.RemoveRange(submissions);

            var questions = await _context.Questions.Where(q => q.TestId == testId).ToListAsync();
            _context.Questions.RemoveRange(questions);

            _context.Tests.Remove(test);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
