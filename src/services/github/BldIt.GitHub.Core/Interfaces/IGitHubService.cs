using BldIt.Api.Shared.Services.Http;
using BldIt.GitHub.Core.Dtos;
using BldIt.GitHub.Core.Models;
using Octokit;

namespace BldIt.GitHub.Core.Interfaces;

public interface IGitHubService
{
    Task<IHttpContentResponse<GitHubUser, GitHubError>> GetGitHubUser(string token);
    Task<HttpContentResponse<IEnumerable<GitHubRepo>, ApiError>> GetUserRepos(string token);
    Task<int> GetTokenLifetime(string accessToken);
}