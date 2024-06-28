using Microsoft.AspNetCore.Mvc;
using SummerWebinarApp.Models;
using System.Diagnostics;

namespace SummerWebinarApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // Logger instance for logging purposes

        // Constructor accepting an ILogger<HomeController> parameter for dependency injection
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action method returning the view for the home page
        public IActionResult Index()
        {
            return View();
        }

        // Action method returning the view for the mission page
        public IActionResult Mission()
        {
            return View();
        }

        // Action method returning the view for the privacy page
        public IActionResult Privacy()
        {
            return View();
        }
        // Action method for handling errors, with response caching disabled
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Create an instance of ErrorViewModel, populating it with the current request ID or trace identifier
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
