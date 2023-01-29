using BldIt.Builds.Core.Repos;
using MassTransit;

namespace BldIt.Builds.Service.Consumers.Builds;

public class UpdateLatestBuild : IConsumer<Contracts.Contracts.UpdateLatestBuild>
{
    private readonly IBuildsRepo _buildsRepo;

    public UpdateLatestBuild(IBuildsRepo buildsRepo)
    {
        _buildsRepo = buildsRepo;
    }

    public async Task Consume(ConsumeContext<Contracts.Contracts.UpdateLatestBuild> context)
    {
        var message = context.Message;

        var oldLatestBuild = await _buildsRepo.GetAsync(b => 
            b.JobId == message.JobId && b.Number == message.OldBuildNumber);

        //Update the old latest build from being the latest
        if (oldLatestBuild is not null)
        {
            oldLatestBuild.IsLatest = false;
            await _buildsRepo.UpdateAsync(oldLatestBuild);
        }
    }
}