using BldIt.Api.Shared;
using BldIt.Api.Shared.Abstractions;
using BldIt.Api.Shared.Config;
using BldIt.Api.Shared.Exceptions;
using BldIt.Api.Shared.Responses;
using BldIt.Api.Shared.Responses.Problems;
using BldIt.Api.Shared.Services.Uri;
using BldIt.Projects.Contracts.Contracts;
using BldIt.Projects.Core.Dtos;
using BldIt.Projects.Core.Models;
using BldIt.Projects.Core.Repos;
using MassTransit;
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
        private readonly BldItWorkspaceConfig _bldItWorkspaceConfig;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(
            IProjectRepo projectsRepository,
            UriService uriService, 
            BldItWorkspaceConfig bldItWorkspaceConfig, 
            IPublishEndpoint publishEndpoint, 
            ILogger<ProjectController> logger)
        {
            _projectsRepository = projectsRepository;
            _uriService = uriService;
            _bldItWorkspaceConfig = bldItWorkspaceConfig;
            _publishEndpoint = publishEndpoint;
            _logger = logger;
        }
        
        [HttpGet(Routes.Projects.GetAll)]
        public async Task<IActionResult> GetAllUserProjects()
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
            var project = await EnsureProjectExists(projectId);

            //If user does not own the project, log a 403, BUT return a 404 (for security purposes...like GitHub does)
            if (!await _projectsRepository.IsUserOwnerOfProject(Guid.Parse(UserId), projectId))
                throw Log403Throw404(projectId.ToString());
            
            //TODO: Check if user is a collaborator
            
            //Otherwise, return it
            return Ok(project);
        }

        [HttpGet(Routes.Projects.GetQuery)]
        public async Task<IActionResult> GetWithQuery([FromQuery] string projectName)
        {
            var project = await EnsureProjectExists(projectName);

            if (!await _projectsRepository.IsUserOwnerOfProject(Guid.Parse(UserId), project!.Id))
                throw Log403Throw404(projectName);
            
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
                throw new ProblemDetailsException(new ExistingInstance(
                    $"Project with name '{projectToCreate.ProjectName}' already exists",
                    Routes.Projects.Post,
                    _uriService));
            }

            var projPath = Path.Combine(_bldItWorkspaceConfig.ProjectsPath(), projectToCreate.ProjectName);

            var project = new Project
            {
                ProjectName = projectToCreate.ProjectName,
                UpdatedAt = DateTime.Now,
                CreatorId = Guid.Parse(UserId),
                ProjectWorkspacePath = projPath,
                Description = projectToCreate.Description
            };
            
            await _projectsRepository.CreateAsync(project);
            
            //Publish project created event
            await _publishEndpoint.Publish(new ProjectCreated(project.Id, project.ProjectWorkspacePath));
            
            var locationUri = _uriService.GetProjectUri(project.ProjectName);
            return Created(locationUri, project);
        }

        [HttpDelete(Routes.Projects.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid projectId)
        {
            var project = await EnsureProjectExists(projectId);
            
            if (!await _projectsRepository.IsUserOwnerOfProject(Guid.Parse(UserId), project!.Id))
                throw Log403Throw404(projectId.ToString());

            //EnsureProjectWorkspaceDeleted(project.ProjectWorkspacePath);
            
            project.Deleted = true;
            await _projectsRepository.UpdateAsync(project);
            await _publishEndpoint.Publish(new ProjectDeleted(project.Id));

            return NoContent();
        }

        [HttpPut(Routes.Projects.Put)]
        public async Task<IActionResult> Update([FromBody] ProjectUpdateDto projectToUpdate, [FromRoute] Guid projectId)
        {
            var existingProject = await EnsureProjectExists(projectId);
            
            //Update Project Information
            existingProject!.ProjectName = projectToUpdate.ProjectName;
            existingProject.Description = projectToUpdate.Description;
            
            await _projectsRepository.UpdateAsync(existingProject);
            
            //Publish project created event
            await _publishEndpoint.Publish(new ProjectCreated(existingProject.Id, existingProject.ProjectWorkspacePath));
            
            return Ok(existingProject);
            
            return Ok();//Replace Later
        }


        private async Task<Project?> EnsureProjectExists(Guid projectId)
        {
            var project = await _projectsRepository.GetAsync(projectId);
            if (project is null || project.Deleted)
            {
                throw new ProblemDetailsException(new InstanceNotFound(
                    $"Project with id '{projectId}' was not found",
                    _uriService.GetProjectUri(projectId.ToString()).AbsolutePath,
                    _uriService));
            }

            return project;
        }
        
        private async Task<Project?> EnsureProjectExists(string projectName)
        {
            var project = await _projectsRepository.GetByNameAsync(projectName);
            if (project is null || project.Deleted)
            {
                throw new ProblemDetailsException(new InstanceNotFound(
                    $"Project with id '{projectName}' was not found",
                    HttpContext.Request.Path.ToString(),
                    _uriService));
            }

            return project;
        }

        /// <summary>
        /// Returns ProblemDetailsException with InstanceNotFound
        /// but logs a 403 for the user trying to access a project that does not own
        /// </summary>
        /// <param name="project">Project Id trying to be accessed</param>
        /// <returns>ProblemDetailsException with InstanceNotFound</returns>
        /// <remarks>
        /// throw this method as if it was a ProblemDetailsException.
        /// https://softwareengineering.stackexchange.com/questions/207232/are-there-legitimate-reasons-for-returning-exception-objects-instead-of-throwing
        /// </remarks>
        private ProblemDetailsException Log403Throw404(string project)
        {
            _logger.LogWarning(
                "User \'{UserId}\' tried to access unowned project \'{Project}\' (403)", 
                UserId, project);
            
            return new ProblemDetailsException(new InstanceNotFound(
                $"Project with '{project}' was not found",
                _uriService.GetProjectUri(project).AbsolutePath,
                _uriService));
        }
    }
}