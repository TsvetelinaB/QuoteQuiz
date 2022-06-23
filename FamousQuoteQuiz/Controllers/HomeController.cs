using System.Diagnostics;

using FamousQuoteQuiz.Models;

using Microsoft.AspNetCore.Mvc;

namespace FamousQuoteQuiz.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}
