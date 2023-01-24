using BldIt.Builds.Contracts.Enums;
using BldIt.Builds.Core.Repos;
using BldIt.BuildWorker.Contracts.Contracts;
using MassTransit;

namespace BldIt.Builds.Service.Consumers.Builds;

public class UpdateBuildStatus : IConsumer<BuildStatusUpdated>
{
    private readonly IBuildsRepo _buildsRepo;
    private readonly IBuildConfigRepo _buildConfigRepo;
    
    public UpdateBuildStatus(IBuildsRepo buildsRepo, IBuildConfigRepo buildConfigRepo)
    {
        _buildsRepo = buildsRepo;
        _buildConfigRepo = buildConfigRepo;
    }
    
    public async Task Consume(ConsumeContext<BuildStatusUpdated> context)
    {
        var message = context.Message;
        
        var buildConfig = await _buildConfigRepo.GetAsync(message.BuildConfigId);
        if (buildConfig is null) return;
        
        var build = await _buildsRepo.GetByNumberAsync(buildConfig.JobId, message.BuildNumber);
        if (build is null) return;
        
        build.Status = (BuildStatus) message.BuildStatus;
        await _buildsRepo.UpdateAsync(build);
    }
}