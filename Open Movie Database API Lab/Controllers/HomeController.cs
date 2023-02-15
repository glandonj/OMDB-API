using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Open_Movie_Database_API_Lab.Models;

namespace Open_Movie_Database_API_Lab.Controllers;

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
    //HttpGet unnecessary since it defaults here but this allows more control over methods.
    public IActionResult MovieSearch()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MovieSearch(string title)
    {
        return View(MovieDAL.GetMovie(title));
    }

    [HttpGet]
    public IActionResult MovieNight()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MovieNight(string title1, string title2, string title3)
    {
        List<MovieModel> result = new List<MovieModel>();
        result.Add(MovieDAL.GetMovie(title1));
        result.Add(MovieDAL.GetMovie(title2));
        result.Add(MovieDAL.GetMovie(title3));
        return View(result);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

