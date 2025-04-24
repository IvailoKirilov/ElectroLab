using ElectroLabModels.Models;

namespace ElectroLabBusinessLayer.Interfaces
{
    public interface ITestService
    {
        List<Test> GetTests(string searchTerm);
        Task CreateTestAsync(Test test);
        Task<Test?> GetTestForTakingAsync(int id, bool isFromCourse = false);
        Task<(bool Success, string? ErrorMessage, int SubmissionId)> SubmitTestAsync(
            int testId, List<SubmissionAnswer> submissionAnswers, ApplicationUser user);
        Task<Submission?> GetSubmissionWithResultsAsync(int submissionId, ApplicationUser user);
        Task<bool> DeleteTestAsync(int testId, ApplicationUser user);
    }
}
