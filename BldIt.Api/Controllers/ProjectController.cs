using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BldIt.Api.Options;
using BldIt.Api.Services;
using BldIt.Models.DataModels;
using BldIt.Models.Exceptions;
using BldIt.Models.Forms;
using BldIt.Models.Interfaces;
using BldIt.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BldIt.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProjectController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UriService _uriService;
        private readonly BldItEnvVariablesSettings _bldItEnvVariablesSettings;

        public ProjectController(
            IUnitOfWork unitOfWork,
            UriService uriService, 
            IOptionsMonitor<BldItEnvVariablesSettings> bldItSettingsMonitor)
        {
            _unitOfWork = unitOfWork;
            _uriService = uriService;
            _bldItEnvVariablesSettings = bldItSettingsMonitor.CurrentValue;
        }
        
        [HttpGet(Routes.Projects.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var projects = 
                await _unitOfWork.ProjectRepo.GetProjectsCreatedByUserAsync(Guid.Parse(UserId));

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
            var project = await _unitOfWork.ProjectRepo.GetByIdAsync(projectId);
            if (project == null) 
                throw new DomainNotFoundException($"Project with id '{projectId}' was not found");

            if (!await _unitOfWork.ProjectRepo.IsUserOwnerOfProject(Guid.Parse(UserId), projectId))
                throw new DomainForbiddenException("You are not the owner of this project");
            
            return Ok(project);
        }
        
        [HttpGet(Routes.Projects.GetQuery)]
        public async Task<IActionResult> GetWithQuery([FromQuery] string projectName)
        {
            var project = await _unitOfWork.ProjectRepo.GetByNameAsync(projectName);
            if (project == null) 
                throw new DomainNotFoundException($"Project with name '{projectName}' was not found");
            
            if (!await _unitOfWork.ProjectRepo.IsUserOwnerOfProject(Guid.Parse(UserId), project.Id))
                throw new DomainForbiddenException("You are not the owner of this project");
            
            return Ok(project);
        }
        
        [HttpPost(Routes.Projects.Post)]
        public async Task<IActionResult> Create([FromBody] ProjectCreationForm projectToCreate)
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

            var existingProject = await _unitOfWork.ProjectRepo.GetByNameAsync(projectToCreate.ProjectName);
            
            if(existingProject != null)
                throw new DomainValidationException(
                    $"A project with name: {projectToCreate.ProjectName} already exists",
                    "All projects have unique names, there cannot be a project with the same name");

            var projPath = Path.Combine(_bldItEnvVariablesSettings.BLDIT_PROJECTS, projectToCreate.ProjectName);
            EnsureProjectWorkspaceExists(projPath);

            var project = new Project
            {
                ProjectName = projectToCreate.ProjectName,
                UpdatedAt = DateTime.Now,
                CreatorId = Guid.Parse(UserId),
                ProjectWorkspacePath = projPath
            };
            
            await _unitOfWork.ProjectRepo.AddAsync(project);
            await _unitOfWork.CompleteAsync();
            
            var locationUri = _uriService.GetProjectUri(project.ProjectName);
            return Created(locationUri, project);
        }

        [HttpDelete(Routes.Projects.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid projectId)
        {
            var project = await _unitOfWork.ProjectRepo.GetByIdAsync(projectId);
            if (project == null) 
                throw new DomainNotFoundException($"Project with id '{projectId}' was not found");
            
            if(Directory.Exists(project.ProjectWorkspacePath))
                Directory.Delete(project.ProjectWorkspacePath, true);

            await _unitOfWork.ProjectRepo.DeleteAsync(projectId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
        
        private static void EnsureProjectWorkspaceExists(string projectWorkspacePath)
        {
            if(!Directory.Exists(projectWorkspacePath))
                Directory.CreateDirectory(projectWorkspacePath);
        }
    }
}