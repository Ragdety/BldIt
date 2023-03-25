using BldIt.GitHub.Core.Dtos;
using BldIt.GitHub.Core.Models;

namespace BldIt.GitHub.Core.Interfaces;

public interface IGitHubService
{
    Task<GitHubUser?> GetGitHubUser(string token);
    //Task<IEnumerable<GitHubRepo>?> GetUserRepos(string token);
    
}