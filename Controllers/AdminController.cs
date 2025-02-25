using Microsoft.AspNetCore.Mvc;

namespace ElectroLab.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
