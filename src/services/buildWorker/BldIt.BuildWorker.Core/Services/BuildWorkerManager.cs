using BldIt.Api.Shared.Settings;
using BldIt.BuildScheduler.Contracts.Contracts;
using BldIt.BuildWorker.Contracts.Contracts;
using BldIt.BuildWorker.Core.Interfaces;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BldIt.BuildWorker.Core.Services;

public class BuildWorkerManager : IBuildWorkerManager
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly ILogger<BuildWorkerManager> _logger;
    private readonly int _maxWorkerCapacity;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly BuildLogRegistry _buildLogRegistry;

    public BuildWorkerManager(
        IServiceScopeFactory serviceScopeFactory, 
        ILogger<BuildWorkerManager> logger,
        IOptionsMonitor<BldItWorkerSettings> workerSettings, 
        IPublishEndpoint publishEndpoint, 
        BuildLogRegistry buildLogRegistry)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _logger = logger;
        _publishEndpoint = publishEndpoint;
        _buildLogRegistry = buildLogRegistry;

        var workerSettingsValue = workerSettings.CurrentValue;
        _maxWorkerCapacity = workerSettingsValue.WorkerNumber;
        
        ActiveBuildWorkers = new Dictionary<Guid, IBuildWorker>(_maxWorkerCapacity);
        _logger.LogInformation("Max worker capacity set to {Capacity}", _maxWorkerCapacity);
    }
    
    //Active workers are workers that are currently working on a build
    private Dictionary<Guid, IBuildWorker> ActiveBuildWorkers { get; }

    /// <summary>
    /// Allocates a worker to a build. Publish a message if the max capacity has been reached
    /// </summary>
    /// <param name="buildRequest">Start Build Request of the build that needs to execute</param>
    /// <returns>True if worker was added successfully, false otherwise</returns>
    public async Task<bool> TryAddActiveWorkerAsync(StartBuildRequest buildRequest)
    {
        //Create a scope since we are using IBuildWorker which is scoped
        using var scope = _serviceScopeFactory.CreateScope();
        var buildWorker = scope.ServiceProvider.GetRequiredService<IBuildWorker>();

        if (MaxCapacityReached())
        {
            _logger.LogInformation("Worker capacity reached, adding build request to queue.");
            
            //Publish a message so we can add the build request to a queue
            await _publishEndpoint.Publish(new BuildWorkerCapacityReached(buildRequest));
            return false;
        }
        
        //Create an empty room for this build to log to
        _buildLogRegistry.CreateBuildLogRoom(buildRequest.BuildId);
        _logger.LogInformation("Created build log room for build {BuildId}", buildRequest.BuildId);
        
        ActiveBuildWorkers.Add(buildRequest.BuildId, buildWorker);
        
        _logger.LogInformation("Added worker to start build request {StartBuildRequest}", buildRequest);
        _logger.LogInformation("Workers available: {WorkerNumber}", _maxWorkerCapacity - ActiveBuildWorkers.Count);
        return true;
    }

    public IBuildWorker GetActiveWorker(Guid buildId) => ActiveBuildWorkers[buildId];
    
    public bool HasActiveWorker(Guid buildId) => ActiveBuildWorkers.ContainsKey(buildId);

    /// <summary>
    /// Deallocates a worker from a build
    /// </summary>
    /// <param name="buildId">The build id of the worker to be removed</param>
    /// <returns>The removed worker</returns>
    public async Task RemoveActiveWorkerAsync(Guid buildId)
    {
        if (!ActiveBuildWorkers.ContainsKey(buildId)) return;
        
        var sendAvailabilityMessage = MaxCapacityReached();
        ActiveBuildWorkers.Remove(buildId);
        
        _buildLogRegistry.RemoveBuildLogRoom(buildId);
        _logger.LogInformation("Removed build log room for build {BuildId}", buildId);
        _logger.LogInformation("Logs will be saved to build {BuildId} log file", buildId);

        if (sendAvailabilityMessage)
        {
            //Since we removed the active worker, a new worker space has been opened for the build
            //Publish a message so we know to pop a build request from the queue and start it
            await _publishEndpoint.Publish(new BuildWorkerCapacityAvailable());
        }

        _logger.LogInformation("Removed worker from build {BuildId}", buildId);
        _logger.LogInformation("Workers available: {WorkerNumber}", _maxWorkerCapacity - ActiveBuildWorkers.Count);
    }
    
    public bool MaxCapacityReached() => ActiveBuildWorkers.Count == _maxWorkerCapacity;
    
    public IEnumerable<IBuildWorker> GetActiveWorkers() => ActiveBuildWorkers.Values;
}