using BldIt.GitHub.Core.Interfaces;
using BldIt.GitHub.Core.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;

namespace BldIt.GitHub.Core.Services;

public class GitHubService : IGitHubService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<GitHubService> _logger;
    
    public GitHubService(HttpClient httpClient, ILogger<GitHubService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }
    
    public async Task<GitHubUser?> GetGitHubUser(string gitHubToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/user");
        request.Headers.Add("Authorization", $"Bearer {gitHubToken}");
        request.Headers.Add("User-Agent", "BldItGitHubServiceClient");
        
        var response = await _httpClient.SendAsync(request);
        var responseContent = await response.Content.ReadAsStringAsync();
        
        //Return null if not successful
        if (!response.IsSuccessStatusCode)
        {
            //TODO: Parse errors and return an error result
            _logger.LogError("GitHub API returned an error: {@GitHubError}", responseContent);
            return null;
        }
        
        var gitHubUser = JsonConvert.DeserializeObject<GitHubUser>(responseContent);
        return gitHubUser;
    }

    // public async Task<IEnumerable<GitHubRepo>?> GetUserRepos(string token)
    // {
    //     //TODO: Get this from api:
    //     var user = "Ragdety";
    //     
    //     var request = new HttpRequestMessage(HttpMethod.Get, $"/users/{user}/repos");
    //     request.Headers.Add("Authorization", $"Bearer {token}");
    //     var response = await _httpClient.SendAsync(request);
    //     
    //     if (response.IsSuccessStatusCode)
    //     {
    //         var content = await response.Content.ReadAsStringAsync();
    //         return JsonConvert.DeserializeObject<IEnumerable<GitHubRepo>>(content);
    //     }
    // }
}