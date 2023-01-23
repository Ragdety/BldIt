using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Contracts;
using BldIt.Builds.Contracts.Keys;
using BldIt.BuildWorker.Core.Models;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers;

public class BuildStepCreatedConsumer : IConsumer<BuildStepCreated>
{
    private readonly IRepository<WorkerBuildStep, BuildStepKey> _buildStepsRepository;

    public BuildStepCreatedConsumer(IRepository<WorkerBuildStep, BuildStepKey> buildStepsRepository)
    {
        _buildStepsRepository = buildStepsRepository;
    }

    public async Task Consume(ConsumeContext<BuildStepCreated> context)
    {
        var message = context.Message;
        
        var exists = await _buildStepsRepository.ExistsAsync(message.BuildStepKey);
        if (exists) return;

        var buildStepCreated = new WorkerBuildStep
        {
            Id = message.BuildStepKey,
            Command = message.Command,
            Type = message.BuildStepType
        };
        
        await _buildStepsRepository.CreateAsync(buildStepCreated);
    }
}