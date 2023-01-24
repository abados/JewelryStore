using jewelryStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.Entity;

namespace jewelryStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? id)
        {
            Group group = DataLayer.Data.Groups.Include(g=>g.SubGroups).Include(g=>g.Items).ToList().First();
            return View();
        }

        public IActionResult test(Price price)
        {
            return View(new Price());
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