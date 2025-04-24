using ElectroLabModels.Models;

namespace ElectroLabBusinessLayer.Services
{
    public interface ITestSubmissionService
    {
        Task<Test?> GetTestWithQuestionsAsync(int testId);
        Task<(int score, Submission submission)> CreateSubmissionAsync(int testId, string userId, List<SubmissionAnswer> answers);
        Task<List<Submission>> GetUserSubmissionsAsync(string userId);
    }
}
