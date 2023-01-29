using BldIt.BuildWorker.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace BldIt.BuildWorker.Core.Hubs;

//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class BuildStreamHub : Hub
{
    private readonly BuildLogRegistry _buildLogRegistry;
    
    public BuildStreamHub(BuildLogRegistry buildLogRegistry)
    {
        _buildLogRegistry = buildLogRegistry;
    }

    public async Task StreamBuildAsync(string output, CancellationToken cancellationToken)
    {
        await Clients.All.SendAsync("BuildOutputReceived", output, cancellationToken);
    }
    
    //Invoked by frontend
    public async Task<List<string>> JoinBuildLogRoom(string buildId)
    {
        //TODO: Check if the worker capacity is full, if so, return an error message rather than crashing
        
        //The group name will be the buildId
        await Groups.AddToGroupAsync(Context.ConnectionId, buildId);
        var id = Guid.Parse(buildId);

        //Return the logs that are currently available, then the frontend will start listening for new logs
        return _buildLogRegistry.GetBuildLogs(id).ToList();
    }

    public async Task LeaveBuildLogRoom(string buildId)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, buildId);
    }
}