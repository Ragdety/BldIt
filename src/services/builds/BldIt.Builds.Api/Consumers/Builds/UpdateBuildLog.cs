using BldIt.Builds.Core.Repos;
using BldIt.BuildWorker.Contracts.Contracts;
using MassTransit;

namespace BldIt.Builds.Service.Consumers.Builds;

public class UpdateBuildLog : IConsumer<BuildLogFileUpdate>
{
    private readonly IBuildsRepo _buildsRepo;
    private readonly IBuildConfigRepo _buildConfigRepo;

    public UpdateBuildLog(IBuildsRepo buildsRepo, IBuildConfigRepo buildConfigRepo)
    {
        _buildsRepo = buildsRepo;
        _buildConfigRepo = buildConfigRepo;
    }


    public async Task Consume(ConsumeContext<BuildLogFileUpdate> context)
    {
        var message = context.Message;
        
        //var buildConfig = await _buildConfigRepo.GetAsync(message.BuildId);
        //if (buildConfig is null) return;

        var build = await _buildsRepo.GetAsync(message.BuildId);
        if (build is null) return;

        build.LogFilePath = message.LogFilePath;

        await _buildsRepo.UpdateAsync(build);
    }
}