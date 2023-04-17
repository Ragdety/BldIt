using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Contracts;
using BldIt.BuildWorker.Core.Models;
using MassTransit;

namespace BldIt.BuildWorker.Api.Consumers;

public class BuildStepDeletedConsumer : IConsumer<BuildStepDeleted>
{
    private readonly IRepository<WorkerBuildStep, Guid> _buildStepsRepository;

    public BuildStepDeletedConsumer(IRepository<WorkerBuildStep, Guid> buildStepsRepository)
    {
        _buildStepsRepository = buildStepsRepository;
    }

    public async Task Consume(ConsumeContext<BuildStepDeleted> context)
    {
        var message = context.Message;
        
        var step = await _buildStepsRepository.GetAsync(
            bs => bs.BuildConfigId == message.BuildConfigId && bs.BuildStepNumber == message.BuildStepNumber);
        
        if (step is null) return;
        
        await _buildStepsRepository.RemoveAsync(step.Id);
        
        //Reassign numbers
        var steps = await _buildStepsRepository.GetAllAsync(
            bs => bs.BuildConfigId == message.BuildConfigId && bs.BuildStepNumber > message.BuildStepNumber);
        
        foreach (var buildStep in steps)
        {
            if (buildStep.BuildStepNumber <= message.BuildStepNumber) continue;
            
            buildStep.BuildStepNumber--;
            await _buildStepsRepository.UpdateAsync(buildStep);
        }
    }
}