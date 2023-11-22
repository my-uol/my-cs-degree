using Newtonsoft.Json;

namespace my_cs_degree.Models;

public class GitHubCommitModel
{
    [JsonProperty("commit")]
    public CommitDetails Commit { get; set; }

    [JsonProperty("html_url")]
    public string Url { get; set; }
}

public class CommitDetails
{
    [JsonProperty("author")]
    public AuthorModel Author { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }
}

public class AuthorModel
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("date")]
    public DateTime Date { get; set; }
}