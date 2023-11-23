using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using my_cs_degree.Models;
using Newtonsoft.Json;


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
        const string gitHubApi = "https://api.github.com/repos/my-uol/my-cs-degree/commits";
        var githubToken = Environment.GetEnvironmentVariable("GITHUB_TOKEN");
        
        try
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "C# App");
                client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                client.DefaultRequestHeaders.Add("Authorization", $"token {githubToken}");

                if (string.IsNullOrEmpty(githubToken))
                {
                    throw new InvalidOperationException("GITHUB_TOKEN environment variable is not set.");
                }

                var response = await client.GetAsync(gitHubApi);

                if (response.IsSuccessStatusCode)
                {
                    // start from the json parameter commit
                    var json = await response.Content.ReadAsStringAsync();
                    var commits = JsonConvert.DeserializeObject<List<GitHubCommitModel>>(json);

                    return View(commits);
                }
                return View();
            }
        }
        catch (Exception)
        {
            return View();
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
