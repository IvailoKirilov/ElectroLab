using System.Diagnostics;
using ElectroLab.Data;
using ElectroLab.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;



namespace ElectroLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        async public Task<IActionResult> Index()
        {
            var courses = _context.Courses.ToList();

            foreach (var course in courses)
            {
                course.User = await _userManager.FindByIdAsync(course.UserId.ToString());
            }

            return View(courses); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture)
        {
            if (!string.IsNullOrEmpty(culture))
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Profile(string id)
        {
            var user = _context.Users.FirstOrDefault(f => f.Id == id);

            ApplicationUser newUser = (ApplicationUser)user;


            if (user == null)
            {
                return NotFound();
            }

            foreach (var course in _context.Courses)
            {
                if (course.UserId == id)
                {
                    newUser.Courses.Add(course);
                }
            }

            return View(newUser);
        }
    }
}
