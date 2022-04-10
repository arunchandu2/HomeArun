using HomeArun.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HomeLoanArun.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult aboutus()
        {
            return View();
        }
        public IActionResult calculator()
        {
            return View();
        }
        public IActionResult application()
        {
            return View();
        }
        public IActionResult login()
        {
            return View();
        }
        public IActionResult faq()
        {
            return View();
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
    }
}