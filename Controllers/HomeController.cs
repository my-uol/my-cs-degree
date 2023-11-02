using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using my_cs_degree.Models;
using Newtonsoft.Json;
using my_cs_degree.Models;
using System.Net;

namespace my_cs_degree.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        string gitHubApi = "https://api.github.com/repos/my-uol/my-cs-degree/commits";

        try
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "C# App");
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                client.DefaultRequestHeaders.Add("Authorization", "token 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");

                var response = await client.GetAsync(gitHubApi);

                if (response.IsSuccessStatusCode)
                {
                    // start from the json parameter commit
                    var json = await response.Content.ReadAsStringAsync();
                    var commits = JsonConvert.DeserializeObject<List<GitHubCommitModel>>(json);

                    return View(commits);
                }
                else
                {
                    return View();
                }
            }
        }
        catch (Exception ex)
        {
            return View();
        }
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
