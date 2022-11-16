using BldIt.Api.Shared;
using BldIt.Api.Shared.Abstractions;
using BldIt.Api.Shared.Config;
using BldIt.Api.Shared.Exceptions;
using BldIt.Api.Shared.Responses;
using BldIt.Api.Shared.Services;
using BldIt.Api.Shared.Services.Errors;
using BldIt.Projects.Contracts.Dtos;
using BldIt.Projects.Core.Models;
using BldIt.Projects.Core.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BldIt.Projects.Service.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProjectController : ApiController
    {
        private readonly IProjectRepo _projectsRepository;
        private readonly UriService _uriService;
        private readonly BldItWorkspacePathConfig _bldItWorkspacePathConfig;

        public ProjectController(
            IProjectRepo projectsRepository,
            UriService uriService, 
            BldItWorkspacePathConfig bldItWorkspacePathConfig)
        {
            _projectsRepository = projectsRepository;
            _uriService = uriService;
            _bldItWorkspacePathConfig = bldItWorkspacePathConfig;
        }
        
        [HttpGet(Routes.Projects.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var projects = 
                await _projectsRepository.GetProjectsCreatedByUserAsync(Guid.Parse(UserId));

            if (projects == null)
                return Ok(new SuccessResponse<Project>
                {
                    Message = "You do no have any projects yet.",
                    Data = new List<Project>()
                });
            
            return Ok(new SuccessResponse<Project>
            {
                Message = "Successfully listing all projects",
                Data = projects
            });
        }
        
        [HttpGet(Routes.Projects.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid projectId)
        {
            var project = await _projectsRepository.GetAsync(projectId);
            if (project == null) 
                throw new DomainNotFoundException($"Project with id '{projectId}' was not found");

            if (!await _projectsRepository.IsUserOwnerOfProject(Guid.Parse(UserId), projectId))
                throw new DomainForbiddenException("You are not the owner of this project");
            
            return Ok(project);
        }
        
        [HttpGet(Routes.Projects.GetQuery)]
        public async Task<IActionResult> GetWithQuery([FromQuery] string projectName)
        {
            var project = await _projectsRepository.GetByNameAsync(projectName);
            if (project == null) 
                throw new DomainNotFoundException($"Project with name '{projectName}' was not found");
            
            if (!await _projectsRepository.IsUserOwnerOfProject(Guid.Parse(UserId), project.Id))
                throw new DomainForbiddenException("You are not the owner of this project");
            
            return Ok(project);
        }
        
        [HttpPost(Routes.Projects.Post)]
        public async Task<IActionResult> Create([FromBody] ProjectCreationDto projectToCreate)
        {
            /*
             * Steps:
             * 1. Check if project exists
             * 2. If it does, return bad request
             * 3. Check if workspace is null or empty
             * 4. If it is, assign it to default path
             * 5. Otherwise, create custom user directory
             * 6. Save project in db & return Created response
             */

            var existingProject = await _projectsRepository.GetByNameAsync(projectToCreate.ProjectName);

            if (existingProject != null)
            {
                throw new ProblemDetailsException(new ProblemDetails
                {
                    Detail = "All projects have unique names, there cannot be a project with the same name",
                    Instance = Routes.Projects.Post,
                    Status = StatusCodes.Status400BadRequest,
                    Title = ErrorTypeMessages.ExistingInstance,
                    Type = _uriService.GetDocsErrorTypeUri(ErrorTypeMessages.ExistingInstance).ToString()
                });
            }

            var projPath = Path.Combine(_bldItWorkspacePathConfig.ProjectsPath, projectToCreate.ProjectName);
            EnsureProjectWorkspaceExists(projPath);

            var project = new Project
            {
                ProjectName = projectToCreate.ProjectName,
                UpdatedAt = DateTime.Now,
                CreatorId = Guid.Parse(UserId),
                ProjectWorkspacePath = projPath
            };
            
            await _projectsRepository.CreateAsync(project);
            
            var locationUri = _uriService.GetProjectUri(project.ProjectName);
            return Created(locationUri, project);
        }

        [HttpDelete(Routes.Projects.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid projectId)
        {
            var project = await _projectsRepository.GetAsync(projectId);
            if (project == null) 
                throw new ProblemDetailsException(new ProblemDetails
                {
                    Detail = $"Project with id '{projectId}' was not found",
                    Instance = _uriService.GetProjectUri(projectId.ToString()).AbsolutePath,
                    Status = StatusCodes.Status404NotFound,
                    Title = ErrorTypeMessages.InstanceNotFound,
                    Type = _uriService.GetDocsErrorTypeUri(ErrorTypeMessages.InstanceNotFound).ToString()
                });
            
            if(Directory.Exists(project.ProjectWorkspacePath))
                Directory.Delete(project.ProjectWorkspacePath, true);

            await _projectsRepository.RemoveAsync(projectId);

            return NoContent();
        }
        
        private static void EnsureProjectWorkspaceExists(string projectWorkspacePath)
        {
            if(!Directory.Exists(projectWorkspacePath))
                Directory.CreateDirectory(projectWorkspacePath);
        }
    }
}