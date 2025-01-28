using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StateManagement.Models;

namespace StateManagement.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        public ILogger<HomeController> Logger { get; } = logger;

        public IActionResult Index()
        {
            // Get existing values if any
            var preferences = new UserPreference
            {
                Theme = HttpContext.Session.GetString("Theme") ?? "light",
                Language = HttpContext.Session.GetString("Language") ?? "en",
                FontSize = HttpContext.Session.GetInt32("FontSize") ?? 14
            };
            
            ViewData["CookieTheme"] = Request.Cookies["Theme"] ?? "light";
            return View(preferences);
        }

        [HttpPost]
        public IActionResult SetSession(UserPreference preferences)
        {
            HttpContext.Session.SetString("Theme", preferences.Theme);
            HttpContext.Session.SetString("Language", preferences.Language);
            HttpContext.Session.SetInt32("FontSize", preferences.FontSize);
            
            TempData["Message"] = "Session values updated successfully!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SetCookie(string theme)
        {
            Response.Cookies.Append("Theme", theme, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30)
            });
            
            TempData["Message"] = "Cookie set successfully!";
            return RedirectToAction("Index");
        }

        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "Session cleared!";
            return RedirectToAction("Index");
        }

        public IActionResult ClearCookie()
        {
            Response.Cookies.Delete("Theme");
            TempData["Message"] = "Cookie cleared!";
            return RedirectToAction("Index");
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
