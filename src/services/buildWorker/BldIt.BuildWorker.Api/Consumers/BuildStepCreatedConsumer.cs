using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Contracts;
using BldIt.BuildWorker.Core.Models;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers;

public class BuildStepCreatedConsumer : IConsumer<BuildStepCreated>
{
    private readonly IRepository<WorkerBuildStep, Guid> _buildStepsRepository;

    public BuildStepCreatedConsumer(IRepository<WorkerBuildStep, Guid> buildStepsRepository)
    {
        _buildStepsRepository = buildStepsRepository;
    }

    public async Task Consume(ConsumeContext<BuildStepCreated> context)
    {
        var message = context.Message;

        var step = await _buildStepsRepository.GetAsync(
            bs => bs.BuildConfigId == message.BuildConfigId && bs.BuildStepNumber == message.BuildStepNumber);
        if (step is not null) return;

        var buildStepCreated = new WorkerBuildStep
        {
            BuildConfigId = message.BuildConfigId,
            BuildStepNumber = message.BuildStepNumber,
            Command = message.Command,
            Type = message.BuildStepType
        };
        
        await _buildStepsRepository.CreateAsync(buildStepCreated);
    }
}