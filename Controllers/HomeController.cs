using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HelperMethod_MVC.Models;
using Helpers;

namespace HelperMethod_MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        string a = "merhaba ben string bir değerim";
        string value = a.Reverse();


        Random rnd = new Random();
        string randomString = rnd.NextString(10);
    }

    public IActionResult Index()
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
