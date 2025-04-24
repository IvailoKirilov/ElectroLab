using ElectroLabBusinessLayer.Interfaces;
using ElectroLabBusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace ElectroLabWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = await _adminService.GetDashboardAsync();
            return View(viewModel);
        }

        public async Task<IActionResult> ViewReport(int id)
        {
            var viewModel = await _adminService.GetReportViewModelAsync(id);
            return viewModel == null ? NotFound() : View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> HandleReport(int id, string action, int? banDuration)
        {
            var currentUser = User.Identity?.Name;
            if (string.IsNullOrEmpty(currentUser)) return RedirectToAction("Login", "Account");

            var result = await _adminService.HandleReportActionAsync(id, action, banDuration, currentUser);
            return result ? RedirectToAction("Index") : BadRequest();
        }

        public async Task<IActionResult> Bans()
        {
            var bans = await _adminService.GetAllBansAsync();
            return View(bans);
        }
    }

}
