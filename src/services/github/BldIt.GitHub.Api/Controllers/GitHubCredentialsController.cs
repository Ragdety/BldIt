using BldIt.Api.Shared;
using BldIt.Api.Shared.Abstractions;
using BldIt.Api.Shared.Exceptions;
using BldIt.Api.Shared.Interfaces;
using BldIt.Api.Shared.Responses.Problems;
using BldIt.Api.Shared.Services.Uri;
using BldIt.GitHub.Contracts.Contracts;
using BldIt.GitHub.Core.Dtos;
using BldIt.GitHub.Core.Interfaces;
using BldIt.GitHub.Core.Models;
using BldIt.GitHub.Core.ViewModels;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.GitHub.Api.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class GitHubCredentialsController : ApiController
{
    private readonly IRepository<GitHubCredential, Guid> _gitHubCredentialsRepository;
    private readonly UriService _uriService;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IGitHubService _gitHubService;
    private readonly ILogger<GitHubCredentialsController> _logger;
    private readonly IRepository<GitHubUser, string> _gitHubUserRepository;
    
    public GitHubCredentialsController(
        IRepository<GitHubCredential, Guid> gitHubCredentialsRepository, 
        UriService uriService, 
        IPublishEndpoint publishEndpoint, 
        IGitHubService gitHubService, 
        ILogger<GitHubCredentialsController> logger, 
        IRepository<GitHubUser, string> gitHubUserRepository)
    {
        _gitHubCredentialsRepository = gitHubCredentialsRepository;
        _uriService = uriService;
        _publishEndpoint = publishEndpoint;
        _gitHubService = gitHubService;
        _logger = logger;
        _gitHubUserRepository = gitHubUserRepository;
    }

    [HttpGet(Routes.GitHub.Credentials.GetAll)]
    public async Task<IActionResult> GetAllCredentials()
    {
        var credentials = await _gitHubCredentialsRepository.GetAllAsync(
            c => c.UserId == Guid.Parse(UserId));
        
        var credentialViewModels = credentials.Select(c => new GitHubCredentialView
        {
            Id = c.Id,
            Deleted = c.Deleted,
            CreatedAt = c.CreatedAt,
            Description = c.Description,
            GitHubUserId = c.GitHubUserId,
            UserId = c.UserId,
        });
        
        return Ok(credentialViewModels);
    }

    [HttpPost(Routes.GitHub.Credentials.Post)]
    public async Task<IActionResult> Create([FromBody] GitHubCredentialCreationDto credentialToCreate)
    {
        /*
         * Steps:
         * 0. Check if user already has a credential
         * 1. Check if credential is valid with GitHub
         * 2. Create new credential
         * 3. Publish GitHubCredentialCreated event
         * 4. Return 201 with credential information
         */
    
        var userId = Guid.Parse(UserId);
        
        var cred = await _gitHubCredentialsRepository.GetAsync(
            c => c.AccessToken == credentialToCreate.PersonalAccessToken);

        if (cred is not null)
        {
            throw new ProblemDetailsException(
                new ExistingInstance(
                    "GitHub credential already exists", 
                    Routes.GitHub.Credentials.Post, 
                    _uriService));
        }
        
        var user = await _gitHubUserRepository.GetAsync(u => u.BldItUserId == userId);
        string gitUserId;
        
        //If user exists, just use that Id for the credential
        if (user is not null)
        {
            gitUserId = user.Id;
        }
        else
        {
            var response = await _gitHubService.GetGitHubUser(credentialToCreate.PersonalAccessToken);

            if (!response.Success)
            {
                throw new ProblemDetailsException(new InvalidInstance(
                    "Invalid GitHub Token",
                    Routes.GitHub.Credentials.Post,
                    _uriService));
            }
        
            var gitHubUser = response.Content!;
        
            //Can suppress because if we reach this point, the user is not null
            gitHubUser.BldItUserId = userId;
        
            await _gitHubUserRepository.CreateAsync(gitHubUser);
            await _publishEndpoint.Publish(new GitHubUserCreated
            (
                gitHubUser.Id,
                gitHubUser.Login,
                gitHubUser.Name,
                gitHubUser.Url,
                gitHubUser.BldItUserId
            ));
            
            gitUserId = gitHubUser.Id;
        }
        
        var credential = new GitHubCredential
        {
            AccessToken = credentialToCreate.PersonalAccessToken,
            GitHubUserId = gitUserId,
            Description = credentialToCreate.Description,
            UserId = Guid.Parse(UserId)
        };
        
        await _gitHubCredentialsRepository.CreateAsync(credential);
        await _publishEndpoint.Publish(new GitHubCredentialCreated(credential.Id, credential.UserId));
        
        var locationUri = _uriService.GetGitHubCredential(credential.Id);
        return Created(locationUri, new GitHubCredentialView
        {
            Id = credential.Id,
            Deleted = credential.Deleted,
            CreatedAt = credential.CreatedAt,
            UserId = credential.UserId,
            Description = credential.Description,
            GitHubUserId = credential.GitHubUserId
        });
    }
    
    [HttpGet(Routes.GitHub.Credentials.Get)]
    public async Task<IActionResult> GetCredential([FromRoute] Guid credentialId)
    {
        var credential =
            await _gitHubCredentialsRepository.GetAsync(
                u => u.UserId == Guid.Parse(UserId) && u.Id == credentialId);
        
        if (credential is null || credential.Deleted)
        {
            throw new ProblemDetailsException(
                new InstanceNotFound(
                    "GitHub credential not found", 
                    Routes.GitHub.Credentials.Get, 
                    _uriService));
        }
        
        return Ok(new GitHubCredentialView
        {
            Id = credential.Id,
            Deleted = credential.Deleted,
            CreatedAt = credential.CreatedAt,
            Description = credential.Description,
            UserId = credential.UserId,
            GitHubUserId = credential.GitHubUserId
        });
    }
    
    [HttpDelete(Routes.GitHub.Credentials.Delete)]
    public async Task<IActionResult> DeleteCredential([FromRoute] Guid credentialId)
    {
        //For now, only allowing 1 cred per user. Later we will add credentialId to these endpoints
        var credential =
            await _gitHubCredentialsRepository.GetAsync(
                c => c.Id == credentialId);
        
        if (credential is null || credential.Deleted)
        {
            throw new ProblemDetailsException(
                new InstanceNotFound(
                    "GitHub credential not found", 
                    Routes.GitHub.Credentials.Delete, 
                    _uriService));
        }
        
        //Delete user first, completely remove because if our bldit user decides to add a new credential,
        //but their github account details like username or name have changed, we want to update the user
        //when they add a new credential (when we call the api in our service)
        await _gitHubUserRepository.RemoveAsync(credential.GitHubUserId);
        await _publishEndpoint.Publish(new GitHubUserDeleted(credential.GitHubUserId));
        
        await _gitHubCredentialsRepository.RemoveAsync(credentialId);
        await _publishEndpoint.Publish(new GitHubCredentialDeleted(credential.Id));
        
        return NoContent();
    }
    
    [HttpGet(Routes.GitHub.Me.Get)]
    public async Task<IActionResult> GetMe()
    {
        var me = await _gitHubUserRepository.GetAsync(
            u => u.BldItUserId == Guid.Parse(UserId));

        if (me is null)
        {
            throw new ProblemDetailsException(
                new InstanceNotFound(
                    "GitHub user not found", 
                    Routes.GitHub.Me.Get, 
                    _uriService));
        }

        return Ok(me);
    }

    //This one does require jwt auth
    // [HttpGet(Routes.GitHub.Auth.Login)]
    // public async Task<IActionResult> LoginGitHub(string returnUrl = "/")
    // {
    //     //For now, add userId in the redirect url until I find a more secure way of doing this...
    //     var callbackUrl = _uriService.GetGitHubCallbackUri().ToString();
    //     callbackUrl = QueryHelpers.AddQueryString(callbackUrl, "userId", UserId);
    //     
    //     var authProperties = new AuthenticationProperties
    //     {
    //         RedirectUri = callbackUrl
    //     };
    //     
    //     return Challenge(authProperties, GitHubAuthenticationDefaults.AuthenticationScheme);
    // }
    
    //Allow anonymous since even if you call it without auth, it will not work since oAuth state won't be valid (I think?)
    // [AllowAnonymous]
    // [HttpGet(Routes.GitHub.Auth.Callback)]
    // public async Task<IActionResult> GitHubCallback(string returnUrl = "/")
    // {
    //     var bldItUserId = Guid.Parse(Request.Query["userId"]);
    //     var authResult = await HttpContext.AuthenticateAsync(BldItApiConstants.AuthenticationSchemes.GitHub);
    //
    //     if (!authResult.Succeeded)
    //     {
    //         _logger.LogError("Failed to authenticate with GitHub");
    //         
    //         //TODO: Append error messages from GitHub to the problem details exception as extensions
    //         
    //         throw new ProblemDetailsException(
    //             new InvalidCredentials(
    //                 "Failed to authenticate with GitHub", 
    //                 Routes.GitHub.Auth.Callback, 
    //                 _uriService));
    //     }
    //     
    //     _logger.LogInformation("GITHUB AUTH SUCCEEDED");
    //     var githubUser = authResult.Principal;
    //
    //     var createdGitHubUser = new GitHubUser
    //     {
    //         BldItUserId = bldItUserId,
    //         Id = githubUser.FindFirstValue("urn:github:id"),
    //         Login = githubUser.FindFirstValue("urn:github:login"),
    //         Name = githubUser.FindFirstValue("urn:github:name"),
    //         Email = githubUser.FindFirstValue("urn:github:email"),
    //         Url = githubUser.FindFirstValue("urn:github:url")
    //     };
    //     
    //     _logger.LogInformation("GITHUB USERRRRR {user}", createdGitHubUser.Url);
    //
    //     // //If user exists, redirect to returnUrl, don't save anything in db since it already exists
    //     // var userExists = await _gitHubUserRepository.ExistsAsync(createdGitHubUser.Id);
    //     // if (userExists) return NoContent();
    //     //
    //     // await _gitHubUserRepository.CreateAsync(createdGitHubUser);
    //     // //TODO: publish message
    //     
    //     var credential = new GitHubCredential
    //     {
    //         UserId = Guid.Parse(UserId),
    //         GitHubUserId = createdGitHubUser.Id,
    //         AccessToken = githubUser.FindFirstValue("urn:github:accesstoken")
    //     };
    //     
    //     _logger.LogInformation("ACCESS TOKEN: {token}", credential.AccessToken);
    //     
    //     // //TODO: publish message
    //     // await _gitHubCredentialsRepository.CreateAsync(credential);
    //
    //     return Ok(new
    //     {
    //         createdGitHubUser,
    //         credential
    //     });
    // }
}