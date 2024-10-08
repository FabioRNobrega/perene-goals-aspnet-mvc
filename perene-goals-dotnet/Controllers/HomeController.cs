﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using perene_goals_dotnet.Models;

namespace perene_goals_dotnet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var quote = new Tuple<string, string>("A goal without a plan is just a wish", "Antoine de Saint-Exupéry");
        return View(quote);
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
