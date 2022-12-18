using BldIt.Api.Shared.Interfaces;
using BldIt.Jobs.Core.Models;
using BldIt.Projects.Contracts.Contracts;
using MassTransit;

namespace BldIt.Jobs.Api.Consumers.Projects;

public class ProjectUpdatedConsumer : IConsumer<ProjectUpdated>
{
    private readonly IRepository<JobsProject, Guid> _projectRepository;
    
    public ProjectUpdatedConsumer(IRepository<JobsProject, Guid> projectRepository)
    {
        _projectRepository = projectRepository;
    }
    
    public async Task Consume(ConsumeContext<ProjectUpdated> context)
    {
        var message = context.Message;

        var project = await _projectRepository.GetAsync(message.Id);

        if (project == null)
        {
            project = new JobsProject
            {
                Id = message.Id,
                UpdatedAt = DateTime.Now,
                ProjectWorkspacePath = message.ProjectWorkspacePath
            };

            await _projectRepository.CreateAsync(project);
        }
        else
        {
            project.ProjectWorkspacePath = message.ProjectWorkspacePath;
            await _projectRepository.UpdateAsync(project);
        }
    }
}