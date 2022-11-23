using BldIt.Api.Shared.Interfaces;
using BldIt.Jobs.Core.Models;
using BldIt.Projects.Contracts.Contracts;
using MassTransit;

namespace BldIt.Jobs.Api.Consumers;

public class ProjectDeletedConsumer : IConsumer<ProjectDeleted>
{
    private readonly IRepository<JobsProject, Guid> _projectsRepository;

    public ProjectDeletedConsumer(IRepository<JobsProject, Guid> projectsRepository)
    {
        _projectsRepository = projectsRepository;
    }

    public async Task Consume(ConsumeContext<ProjectDeleted> context)
    {
        var message = context.Message;
        var project = _projectsRepository.GetAsync(message.Id);
        
        if (project == null)
        {
            return;
        }
        
        await _projectsRepository.RemoveAsync(message.Id);
    }
}