using BartenderApp.Data;
using BartenderApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BartenderApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ICocktailRepository repo;

        public HomeController (ICocktailRepository cocktailRepo)
        {
            repo = cocktailRepo;
        }


        

        public IActionResult Index()
        {
            var menu = repo.GetAll();
            return View(menu);
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
