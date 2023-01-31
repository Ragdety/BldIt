using BldIt.BuildWorker.Core.Interfaces;
using BldIt.BuildWorker.Core.Results;
using BldIt.BuildWorker.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BldIt.BuildWorker.Core.Hubs;

//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BuildStreamHub : Hub
{
    private readonly BuildLogRegistry _buildLogRegistry;
    private readonly IBuildWorkerManager _buildWorkerManager;
    
    public BuildStreamHub(BuildLogRegistry buildLogRegistry, IBuildWorkerManager buildWorkerManager)
    {
        _buildLogRegistry = buildLogRegistry;
        _buildWorkerManager = buildWorkerManager;
    }

    public async Task StreamBuildAsync(string output, CancellationToken cancellationToken)
    {
        await Clients.All.SendAsync("BuildOutputReceived", output, cancellationToken);
    }
    
    //Invoked by frontend
    public async Task<JoinBuildLogRoomResult> JoinBuildLogRoom(string buildId)
    {
        var maxCapacityReached = _buildWorkerManager.MaxCapacityReached();
        var buildAlreadyStarted = _buildWorkerManager.HasActiveWorker(Guid.Parse(buildId));
        
        if (maxCapacityReached && !buildAlreadyStarted)
        {
            return new JoinBuildLogRoomResult
            {
                Errors = new List<string> {"Build is in queue..."},
                Joined = false
            };
        }
        
        //The group name will be the buildId
        await Groups.AddToGroupAsync(Context.ConnectionId, buildId);
        var id = Guid.Parse(buildId);

        //Return the logs that are currently available, then the frontend will start listening for new logs
        return new JoinBuildLogRoomResult
        {
            Logs = _buildLogRegistry.GetBuildLogs(id).ToList(),
            Joined = true
        };
    }

    public async Task LeaveBuildLogRoom(string buildId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, buildId);
    }
}