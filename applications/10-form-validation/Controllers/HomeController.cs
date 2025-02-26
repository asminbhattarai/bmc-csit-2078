using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormValidation.Models;

namespace FormValidation.Controllers;

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

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    [Route("/")]  // Makes this the default route
    [Route("/Home")]  // Optional: Allows accessing via /Home too
    [Route("/Home/Form")]  // Allows the usual access

    public IActionResult Form()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitForm(string name, string roll)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 4 || !int.TryParse(roll, out _))
        {
            ViewData["Error"] = "Invalid input! Please check your data.";
            return View("Form");
        }

        ViewData["Success"] = "Form submitted successfully!";
        return View("Form");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
