namespace BldIt.GitHub.Core.Results;

public class GitHubResult
{
    public string Message { get; set; }
    public int StatusCode { get; set; }
    public bool Success { get; set; }
    public IEnumerable<string> Errors { get; set; } = new List<string>();
}