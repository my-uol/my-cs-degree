using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using my_cs_degree.Models;
using Newtonsoft.Json;

namespace my_cs_degree.Controllers;

public class GradeCalculatorController : Controller
{
    private readonly ILogger<HomeController> _logger;
    
    public GradeCalculatorController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult ChangeModule(string partialName)
    {
        if (string.IsNullOrEmpty(partialName) || (partialName != "itp1" && partialName != "itp2"))
        {
            return BadRequest("Invalid partial view.");
        }
        return PartialView($"Partials/{partialName}");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}