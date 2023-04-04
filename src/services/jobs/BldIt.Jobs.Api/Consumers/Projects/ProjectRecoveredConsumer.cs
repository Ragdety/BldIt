using BldIt.Api.Shared.Interfaces;
using BldIt.Jobs.Core.Models;
using BldIt.Jobs.Core.Repos;
using BldIt.Projects.Contracts.Contracts;
using MassTransit;

namespace BldIt.Jobs.Api.Consumers.Projects;

public class ProjectRecoveredConsumer : IConsumer<ProjectRecovered>
{
    private readonly IRepository<JobsProject, Guid> _projectsRepo;
    private readonly IJobsRepo _jobsRepo;
    private readonly ILogger<ProjectRecoveredConsumer> _logger;

    public ProjectRecoveredConsumer(
        IRepository<JobsProject, Guid> projectsRepo, 
        IJobsRepo jobsRepo, 
        ILogger<ProjectRecoveredConsumer> logger)
    {
        _projectsRepo = projectsRepo;
        _jobsRepo = jobsRepo;
        _logger = logger;
    }
    
    public async Task Consume(ConsumeContext<ProjectRecovered> context)
    {
        var message = context.Message;
        var projectToBeRecovered = await _projectsRepo.GetAsync(message.ProjectId);
        
        if (projectToBeRecovered is null)
        {
            _logger.LogWarning($"Project with id '{message.ProjectId}' was not found");
            _logger.LogWarning($"Project with id '{message.ProjectId}' is not being recovered");
            return;
        }
        
        projectToBeRecovered.Deleted = false;
        await _projectsRepo.UpdateAsync(projectToBeRecovered);
        
        var jobsToBeRecovered = 
            await _jobsRepo.GetAllAsync(j => j.ProjectId == message.ProjectId && j.Deleted);
        
        foreach (var job in jobsToBeRecovered)
        {
            job.Deleted = false;
            await _jobsRepo.UpdateAsync(job);
        }
        
        _logger.LogInformation($"Project with id '{message.ProjectId}' was recovered from Jobs microservice");
    }
}