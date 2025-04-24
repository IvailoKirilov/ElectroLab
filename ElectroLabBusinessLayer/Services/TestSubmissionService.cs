using ElectroLabModels.Models;
using ElectroLabDB;
using Microsoft.EntityFrameworkCore;

namespace ElectroLabBusinessLayer.Services
{
    public class TestSubmissionService : ITestSubmissionService
    {
        private readonly ApplicationDbContext _context;

        public TestSubmissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Test?> GetTestWithQuestionsAsync(int testId)
        {
            return await _context.Tests
                .Include(t => t.Questions)
                .ThenInclude(q => q.Options)
                .FirstOrDefaultAsync(t => t.Id == testId);
        }

        public async Task<(int score, Submission submission)> CreateSubmissionAsync(int testId, string userId, List<SubmissionAnswer> answers)
        {
            var test = await _context.Tests
                .Include(t => t.Questions)
                .FirstOrDefaultAsync(t => t.Id == testId);

            if (test == null)
                throw new Exception("Test not found.");

            int score = 0;
            foreach (var answer in answers)
            {
                var question = test.Questions.FirstOrDefault(q => q.Id == answer.QuestionId);
                if (question != null && question.CorrectAnswer == answer.Answer)
                {
                    score++;
                }
            }

            var submission = new Submission
            {
                TestId = testId,
                UserId = userId,
                Score = score,
                DateSubmitted = DateTime.UtcNow
            };

            _context.Submissions.Add(submission);
            await _context.SaveChangesAsync();

            foreach (var answer in answers)
            {
                answer.SubmissionId = submission.Id;
                _context.SubmissionAnswers.Add(answer);
            }

            await _context.SaveChangesAsync();

            return (score, submission);
        }

        public async Task<List<Submission>> GetUserSubmissionsAsync(string userId)
        {
            return await _context.Submissions
                .Where(s => s.UserId == userId)
                .Include(s => s.Test)
                .OrderByDescending(s => s.DateSubmitted)
                .ToListAsync();
        }
    }

}
