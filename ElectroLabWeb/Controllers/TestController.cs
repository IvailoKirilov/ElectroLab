using ElectroLabBusinessLayer;
using ElectroLabModels.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectroLabWeb.Controllers
{
    public class TestController : Controller
    {
        private readonly TestService _testService;
        private readonly UserManager<ApplicationUser> _userManager;

        public TestController(TestService testService, UserManager<ApplicationUser> userManager)
        {
            _testService = testService;
            _userManager = userManager;
        }

        public IActionResult Index(string searchTerm)
        {
            var tests = _testService.GetTests(searchTerm);
            ViewData["SearchTerm"] = searchTerm;
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
            await _testService.CreateTestAsync(test);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> TakeTest(int id, bool isFromCourse = false)
        {
            var test = await _testService.GetTestForTakingAsync(id, isFromCourse);
            if (test == null) return NotFound();
            return View(test);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitTest(int testId, List<SubmissionAnswer> submissionAnswers)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _testService.SubmitTestAsync(testId, submissionAnswers, user);
            if (!result.Success)
            {
                ModelState.AddModelError("", result.ErrorMessage ?? "Submission error");
                var test = await _testService.GetTestForTakingAsync(testId);
                return View("TakeTest", test);
            }

            return RedirectToAction(nameof(ViewResult), new { submissionId = result.SubmissionId });
        }

        public async Task<IActionResult> ViewResult(int submissionId)
        {
            var user = await _userManager.GetUserAsync(User);
            var submission = await _testService.GetSubmissionWithResultsAsync(submissionId, user);
            if (submission == null) return NotFound();
            if (submission == TestService.ForbiddenSubmission) return Forbid();
            return View(submission);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int testId)
        {
            var user = await _userManager.GetUserAsync(User);
            var result = await _testService.DeleteTestAsync(testId, user);
            if (!result) return Forbid();
            return RedirectToAction(nameof(Index));
        }
    }
}
