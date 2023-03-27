using System.Net;
using BldIt.Api.Shared;
using BldIt.Api.Shared.Abstractions;
using BldIt.Api.Shared.Exceptions;
using BldIt.Api.Shared.Interfaces;
using BldIt.Api.Shared.Responses.Problems;
using BldIt.Api.Shared.Services.Uri;
using BldIt.GitHub.Core.Interfaces;
using BldIt.GitHub.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace BldIt.GitHub.Api.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class GitHubRepositoriesController : ApiController
{
    private readonly IGitHubService _gitHubService;
    private readonly IRepository<GitHubCredential, Guid> _gitHubCredentialsRepository;
    private readonly UriService _uriService;

    public GitHubRepositoriesController(
        IGitHubService gitHubService,
        GitHubClient gitHubClient,
        IRepository<GitHubCredential, Guid> gitHubCredentialsRepository, 
        UriService uriService)
    {
        _gitHubService = gitHubService;
        _gitHubCredentialsRepository = gitHubCredentialsRepository;
        _uriService = uriService;
        _gitHubService = gitHubService;
    }
    
    [HttpGet(Routes.GitHub.Repositories.GetAll)]
    public async Task<IActionResult> GetAll([FromQuery] Guid credentialId)
    {
        var cred = await EnsureCredentialExists(credentialId);
        
        var response = await _gitHubService.GetUserRepos(cred.AccessToken);

        if (response.Success) return Ok(response);
        
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            throw new ProblemDetailsException(new InvalidCredentials(
                "GitHub credentials are invalid", 
                Routes.GitHub.Repositories.GetAll, 
                _uriService));
        }
            
        var errorDict = new Dictionary<string, object?> {{"Errors", response.ErrorContent}};

        throw new ProblemDetailsException(new InvalidInstance(
            "GitHub returned an error", 
            Routes.GitHub.Repositories.GetAll, 
            _uriService,
            errorDict));
    }
    
    private async Task<GitHubCredential> EnsureCredentialExists(Guid credentialId)
    {
        var cred = await _gitHubCredentialsRepository.GetAsync(credentialId);

        if (cred is null)
        {
            throw new ProblemDetailsException(
                new InstanceNotFound(
                    "GitHub credential does not exist", 
                    Routes.GitHub.Repositories.GetAll, 
                    _uriService));
        }

        return cred;
    }
}