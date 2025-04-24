using ElectroLabBusinessLayer.Services;
using ElectroLabModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ElectroLabWeb.Controllers
{
    public class ReportController : Controller
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? courseId)
        {
            if (!courseId.HasValue)
                return RedirectToAction("Index", "Home");

            var report = await _reportService.PrepareNewReportAsync(courseId.Value);

            if (report == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Courses = await _reportService.GetCoursesAsync();
            ViewBag.Users = await _reportService.GetUsersAsync();

            return View(report);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Report report)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _reportService.CreateReportAsync(report, userId);

            if (!result.Success)
            {
                ModelState.AddModelError("CourseId", result.ErrorMessage ?? "An error occurred.");
                ViewBag.Courses = await _reportService.GetCoursesAsync();
                ViewBag.Users = await _reportService.GetUsersAsync();
                return View(report);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
