using BldIt.Api.Shared.Interfaces;
using BldIt.Jobs.Core.Models;
using BldIt.Jobs.Core.Repos;
using BldIt.Projects.Contracts.Contracts;
using MassTransit;

namespace BldIt.Jobs.Api.Consumers.Projects;

public class ProjectDeletedConsumer : IConsumer<ProjectDeleted>
{
    private readonly IRepository<JobsProject, Guid> _projectsRepository;
    private readonly IJobsRepo _jobsRepo;

    public ProjectDeletedConsumer(
        IRepository<JobsProject, Guid> projectsRepository, 
        IJobsRepo jobsRepo)
    {
        _projectsRepository = projectsRepository;
        _jobsRepo = jobsRepo;
    }

    public async Task Consume(ConsumeContext<ProjectDeleted> context)
    {
        var message = context.Message;
        var project = await _projectsRepository.GetAsync(message.Id);
        
        if (project == null || project.Deleted)
        {
            return;
        }
        
        //Check if project has any jobs and delete (mark as deleted) them as well
        var projectJobs = await _jobsRepo.GetAllAsync(j => j.ProjectId == project.Id);
        if (projectJobs.Any())
        {
            foreach (var job in projectJobs)
            {
                job.Deleted = true;
                await _jobsRepo.UpdateAsync(job);
            }
        }
        
        project.Deleted = true;
        await _projectsRepository.UpdateAsync(project);
    }
}