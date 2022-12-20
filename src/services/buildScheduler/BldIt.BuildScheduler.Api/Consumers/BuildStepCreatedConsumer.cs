using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Contracts;
using BldIt.Builds.Contracts.Keys;
using BldIt.BuildScheduler.Core.Models;
using MassTransit;

namespace BldIt.BuildScheduler.Api.Consumers;

public class BuildStepCreatedConsumer : IConsumer<BuildStepCreated>
{
    private readonly IRepository<SchedulerBuildStep, BuildStepKey> _buildStepsRepository;

    public BuildStepCreatedConsumer(IRepository<SchedulerBuildStep, BuildStepKey> buildStepsRepository)
    {
        _buildStepsRepository = buildStepsRepository;
    }

    public async Task Consume(ConsumeContext<BuildStepCreated> context)
    {
        var message = context.Message;
        
        var exists = await _buildStepsRepository.ExistsAsync(message.BuildStepKey);
        if (exists) return;

        var buildStepCreated = new SchedulerBuildStep
        {
            Id = message.BuildStepKey,
            Command = message.Command,
            Type = message.BuildStepType
        };
        
        await _buildStepsRepository.CreateAsync(buildStepCreated);
    }
}