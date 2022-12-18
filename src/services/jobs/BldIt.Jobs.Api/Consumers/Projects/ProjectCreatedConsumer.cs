using BldIt.Api.Shared.Interfaces;
using BldIt.Jobs.Core.Models;
using BldIt.Projects.Contracts.Contracts;
using MassTransit;

namespace BldIt.Jobs.Api.Consumers.Projects;

public class ProjectCreatedConsumer : IConsumer<ProjectCreated>
{
    private readonly IRepository<JobsProject, Guid> _projectRepository;

    public ProjectCreatedConsumer(IRepository<JobsProject, Guid> projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task Consume(ConsumeContext<ProjectCreated> context)
    {
        var message = context.Message;

        var exists = await _projectRepository.ExistsAsync(message.Id);
        if (exists) return;
        
        var project = new JobsProject
        {
            Id = message.Id, 
            ProjectWorkspacePath = message.ProjectWorkspacePath
        };

        await _projectRepository.CreateAsync(project);
    }
}