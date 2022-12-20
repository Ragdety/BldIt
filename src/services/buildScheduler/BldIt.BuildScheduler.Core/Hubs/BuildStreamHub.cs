using Microsoft.AspNetCore.SignalR;

namespace BldIt.BuildScheduler.Api.Hubs;

public class BuildStreamHub : Hub
{
    private readonly string _id;
        
    public BuildStreamHub()
    {
        _id = Guid.NewGuid().ToString();
    }

    public void StreamBuild(string output, CancellationToken cancellationToken)
    {
        Clients.All.SendAsync("OutputReceived", output, cancellationToken);
    }
}