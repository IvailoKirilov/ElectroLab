using ElectroLabBusinessLayer.Services;
using ElectroLabModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ElectroLabWeb.Controllers
{
    public class TestSubmissionsController : Controller
    {
        private readonly TestSubmissionService _submissionService;
        private readonly UserManager<ApplicationUser> _userManager;

        public TestSubmissionsController(TestSubmissionService submissionService, UserManager<ApplicationUser> userManager)
        {
            _submissionService = submissionService;
            _userManager = userManager;
        }

        public async Task<IActionResult> TakeTest(int? testId)
        {
            if (testId == null)
                return NotFound();

            var test = await _submissionService.GetTestWithQuestionsAsync(testId.Value);
            if (test == null)
                return NotFound();

            return View(test);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitTest(int testId, List<SubmissionAnswer> answers)
        {
            var userId = _userManager.GetUserId(User);
            var (score, submission) = await _submissionService.CreateSubmissionAsync(testId, userId, answers);
            return RedirectToAction(nameof(ViewSubmissions));
        }

        public async Task<IActionResult> ViewSubmissions()
        {
            var userId = _userManager.GetUserId(User);
            var submissions = await _submissionService.GetUserSubmissionsAsync(userId);
            return View(submissions);
        }
    }

}
