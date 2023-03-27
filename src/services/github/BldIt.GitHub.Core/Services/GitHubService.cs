using System.Net;
using BldIt.Api.Shared.Services.Http;
using BldIt.GitHub.Core.Dtos;
using BldIt.GitHub.Core.Interfaces;
using BldIt.GitHub.Core.Models;
using Microsoft.Extensions.Logging;
using Octokit;

namespace BldIt.GitHub.Core.Services;

public class GitHubService : IGitHubService
{
    private readonly IHttpService _httpService;
    private readonly GitHubClient _gitHubClient;
    private readonly ILogger<GitHubService> _logger;
    
    public GitHubService(
        IHttpService httpService, 
        ILogger<GitHubService> logger, 
        GitHubClient gitHubClient)
    {
        _httpService = httpService;
        _logger = logger;
        _gitHubClient = gitHubClient;
    }
    
    public async Task<IHttpContentResponse<GitHubUser, GitHubError>> GetGitHubUser(string gitHubToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/user");
        request.Headers.Add("Authorization", $"Bearer {gitHubToken}");
        return await _httpService.RequestWithContent<GitHubUser, GitHubError>(request);
    }

    public async Task<HttpContentResponse<IEnumerable<GitHubRepo>, ApiError>> GetUserRepos(string token)
    {
        _gitHubClient.Credentials = new Credentials(token);

        try
        {
            var repos = await _gitHubClient.Repository.GetAllForCurrent();
            var simplerRepos = repos.Select(r => new GitHubRepo
            {
                Id = r.Id,
                Name = r.Name,
                Url = r.Url,
                Description = r.Description
            });
            return new HttpContentResponse<IEnumerable<GitHubRepo>, ApiError>
            {
                Content = simplerRepos,
                StatusCode = HttpStatusCode.OK,
                Message = "Successfully retrieved GitHub repos",
                Success = true
            };
        }
        catch (ApiException e)
        {
            _logger.LogError(e, "Error getting GitHub repos");
            return new HttpContentResponse<IEnumerable<GitHubRepo>, ApiError>
            {
                Content = null,
                StatusCode = e.StatusCode,
                Success = false,
                Message = e.Message,
                ErrorContent = e.ApiError
            };
        }
    }

    public async Task<int> GetTokenLifetime(string accessToken)
    {
        // var request = new HttpRequestMessage(HttpMethod.Head, "/rate_limit");
        // request.Headers.Add("Authorization", $"Bearer {accessToken}");
        //
        // var response = await _httpClient.SendAsync(request);
        //
        //
        //
        // var resetTime = response.Headers.GetValues("x-ratelimit-reset").FirstOrDefault();
        // var resetTimestamp = DateTimeOffset.FromUnixTimeSeconds(int.Parse(resetTime));
        //
        // var remainingLifetime = resetTimestamp.Subtract(DateTimeOffset.Now).TotalSeconds;
        // return (int) Math.Max(remainingLifetime, 0);
        return 1;
    }

}