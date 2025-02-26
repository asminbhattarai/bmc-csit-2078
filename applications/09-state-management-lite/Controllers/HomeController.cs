using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace StateManagementLite.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        HttpContext.Session.SetString("UserName", "Asmin");
        HttpContext.Session.SetInt32("UserId", 25);
        TempData["Message"] = "Session Data Set!";
        return RedirectToAction("GetSession");
    }

    public IActionResult GetSession()
    {
        ViewBag.UserName = HttpContext.Session.GetString("UserName");
        ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
        ViewData["Info"] = "Stored session values retrieved!";
        return View();
    }
}
