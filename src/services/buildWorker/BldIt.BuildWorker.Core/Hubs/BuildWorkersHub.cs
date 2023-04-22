using BldIt.Api.Shared.Settings;
using BldIt.BuildWorker.Core.Hubs.Clients;
using BldIt.BuildWorker.Core.Interfaces;
using BldIt.BuildWorker.Core.Results;
using BldIt.BuildWorker.Core.ViewModels;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;

namespace BldIt.BuildWorker.Core.Hubs;

public class BuildWorkersHub : Hub<IBuildWorkersClient>
{
    private readonly IBuildWorkerManager _buildWorkerManager;
    private readonly int _maxWorkerCapacity;
    private readonly List<BuildWorkerViewModel> _buildWorkers;

    public BuildWorkersHub(
        IBuildWorkerManager buildWorkerManager,
        IOptionsMonitor<BldItWorkerSettings> workerSettings)
    {
        _buildWorkerManager = buildWorkerManager;
        
        var workerSettingsValue = workerSettings.CurrentValue;
        _maxWorkerCapacity = workerSettingsValue.WorkerNumber;
        
        _buildWorkers = new List<BuildWorkerViewModel>(_maxWorkerCapacity);
    }

    // public async Task UpdateBuildWorkerAvailability(BuildWorkerViewModel buildWorker)
    // {
    //     if(buildWorker.IsWorking)
    //     {
    //         await AddBuildWorker(buildWorker.BuildId);
    //     }
    //     else
    //     {
    //         await RemoveBuildWorker(buildWorker.BuildId);
    //     }
    // }

    private async Task AddBuildWorker(Guid buildId)
    {
        if (_buildWorkerManager.MaxCapacityReached())
        {
            return;
        }
        
        var availableBuildWorker = _buildWorkers.FirstOrDefault(x => !x.IsWorking);
        if (availableBuildWorker is not null)
        {
            availableBuildWorker.BuildId = buildId;
            availableBuildWorker.IsWorking = true;
            
            //We will do an "on" event here to update the UI
            //con.on("UpdateBuildWorkerAvailability", (buildWorker) => {code here});
            await Clients.All.UpdateBuildWorkerAvailability(availableBuildWorker);
        }
    }

    private async Task RemoveBuildWorker(Guid buildId)
    {
        var buildWorker = _buildWorkers.FirstOrDefault(x => x.BuildId == buildId);
        if (buildWorker is not null)
        {
            buildWorker.BuildId = Guid.Empty;
            buildWorker.IsWorking = false;
            
            await Clients.All.UpdateBuildWorkerAvailability(buildWorker);
        }
    }

    //Invoke this to get the initial build worker availability
    public Task<BuildWorkersAvailabilityResult> GetWorkers()
    {
        foreach (var worker in GetActiveBuildWorkerViewModels())
        {
            //Fill the list with the active workers
            _buildWorkers.Add(worker);
        }

        //If it's already full, return the list
        if (_buildWorkers.Count >= _maxWorkerCapacity)
        {
            return Task.FromResult(new BuildWorkersAvailabilityResult
            {
                BuildWorkers = _buildWorkers
            });
        }
        
        //Otherwise, fill the rest of the list with inactive workers
        for (var i = _buildWorkers.Count; i < _maxWorkerCapacity; i++)
        {
            _buildWorkers.Add(new BuildWorkerViewModel
            {
                IsWorking = false,
                BuildId = null
            });
        }
        
        return Task.FromResult(new BuildWorkersAvailabilityResult
        {
            BuildWorkers = _buildWorkers
        });
    }
    
    //This returns the build worker view models that are currently active
    private IEnumerable<BuildWorkerViewModel> GetActiveBuildWorkerViewModels()
    {
        var activeBuildWorkers = _buildWorkerManager.GetActiveWorkers().ToList();
        return activeBuildWorkers.Select(x => new BuildWorkerViewModel
        {
            IsWorking = x.IsWorking,
            BuildId = x.WorkingBuildId,
            BuildNumber = x.WorkingBuildNumber,
            JobId = x.WorkingJobId
        });
    }
}