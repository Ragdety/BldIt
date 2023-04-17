using BldIt.Api.Shared.Interfaces;
using BldIt.Builds.Contracts.Contracts;
using BldIt.Builds.Core.Models;
using MassTransit;

namespace BldIt.Builds.Service.Consumers.BuildSteps;

public class DeletedBuildStep : IConsumer<BuildStepDeleted>
{
    private readonly IRepository<BuildStep, Guid> _buildStepsRepo;
    
    public DeletedBuildStep(IRepository<BuildStep, Guid> buildStepsRepo)
    {
        _buildStepsRepo = buildStepsRepo;
    }
    
    public async Task Consume(ConsumeContext<BuildStepDeleted> context)
    {
        var (_, buildConfigId, deletedStepNumber) = context.Message;
        
        var buildSteps = 
            await _buildStepsRepo.GetAllAsync(x => x.BuildConfigId == buildConfigId);

        //Reassign numbers to all steps after the deleted one
        foreach (var buildStep in buildSteps)
        {
            if (buildStep.Number <= deletedStepNumber) continue;
            
            //Only update if the number is greater than the deleted step
            buildStep.Number--;
            await _buildStepsRepo.UpdateAsync(buildStep);
        }
    }
}