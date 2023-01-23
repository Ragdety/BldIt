using BldIt.BuildWorker.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BldIt.BuildWorker.Core.Services;

public class BuildWorkerManager : IBuildWorkerManager
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public BuildWorkerManager(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        ActiveBuildWorkers = new Dictionary<Guid, IBuildWorker>();
    }
    
    public Dictionary<Guid, IBuildWorker> ActiveBuildWorkers { get; }

    /// <summary>
    /// Allocates a worker to a build
    /// </summary>
    /// <param name="buildId">Id of the build that needs to execute</param>
    /// <returns>The worker to be used for the build</returns>
    public IBuildWorker AddActiveWorker(Guid buildId)
    {
        //Create a scope since we are using BuildWorker which is scoped
        using var scope = _serviceScopeFactory.CreateScope();
        var buildWorker = scope.ServiceProvider.GetRequiredService<IBuildWorker>();
        ActiveBuildWorkers.Add(buildId, buildWorker);
        return buildWorker;
    }
    
    /// <summary>
    /// Deallocates a worker from a build
    /// </summary>
    /// <param name="buildId">The build id of the worker to be removed</param>
    /// <returns>The removed worker</returns>
    public void RemoveActiveWorker(Guid buildId)
    {
        if (!ActiveBuildWorkers.ContainsKey(buildId)) return;
        ActiveBuildWorkers.Remove(buildId);
    }
}