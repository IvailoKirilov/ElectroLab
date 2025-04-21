using ElectroLabBusinessLayer;
using ElectroLabModels.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ElectroLabWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminService _adminService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AdminController(AdminService adminService, SignInManager<ApplicationUser> signInManager)
        {
            _adminService = adminService;
            _signInManager = signInManager;
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
