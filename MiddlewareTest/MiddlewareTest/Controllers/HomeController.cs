using Microsoft.AspNetCore.Mvc;
using MiddlewareTest.Models;
using System.Diagnostics;
using MiddlewareTest.Data;

namespace MiddlewareTest.Controllers
{
    public class HomeController : Controller
    {
        DataBase db { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            db = new DataBase();
        }

        public IActionResult Index()
        {
            var user = db.GetUser();
            return View(user);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IncreaseMoney(User t1)
        {
            var user = db.GetUser();
            user.CurrentMoney = t1.CurrentMoney + t1.IncreaseMoney;
            return Redirect(nameof(IncreaseMoney));
        }

        [HttpGet]
        public IActionResult IncreaseMoney()
        {
            var user = db.GetUser();
            return View(user);
        }
    }
}