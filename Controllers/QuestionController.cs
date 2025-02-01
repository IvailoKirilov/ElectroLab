using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ElectroLab.Data;
using ElectroLab.Models;
using Microsoft.AspNetCore.Authorization;

namespace ElectroLab.Controllers
{
    [Authorize]  // Require login
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int testId)
        {
            ViewBag.TestId = testId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Question question, string[] options)
        {
            if (ModelState.IsValid)
            {
                question.Options = options.ToList();
                _context.Questions.Add(question);
                _context.SaveChanges();
                return RedirectToAction("Details", "Test", new { id = question.TestId });
            }
            return View(question);
        }
    }
}
