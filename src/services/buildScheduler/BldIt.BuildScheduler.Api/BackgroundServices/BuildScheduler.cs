using BldIt.BuildScheduler.Core.Interfaces;

namespace BldIt.BuildScheduler.Api.BackgroundServices;

public class BuildScheduler : BackgroundService
{
    private readonly IBuildQueue _buildQueue;
    private readonly ILogger<BuildScheduler> _logger;
    private int _scheduledBuilds;

    public BuildScheduler(IBuildQueue buildQueue, ILogger<BuildScheduler> logger)
    {
        _buildQueue = buildQueue;
        _logger = logger;
        _scheduledBuilds = 0;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("BuildScheduler is listening and ready to take builds");
        while (true)
        {
            try
            {
                if (stoppingToken.IsCancellationRequested)
                {
                    //Build cancellation logic here (somehow? idk yet)
                    _logger.LogWarning("BuildScheduler is shutting down");
                    _logger.LogInformation("BuildScheduler scheduled {ScheduledBuilds} builds total", _scheduledBuilds);
                    return;
                }
            
                //Redirect Build Request to Build Queue
                var startBuild = await _buildQueue.DequeueBuildAsync(stoppingToken);

                _logger.LogInformation("A build has been released by the {BuildScheduler} queue", nameof(BuildScheduler));

                //Send build to worker service
                await startBuild(stoppingToken);
            
                _scheduledBuilds++;
                _logger.LogInformation("BuildScheduler has scheduler {ScheduledBuilds} builds so far", _scheduledBuilds);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to schedule build for build count {ScheduledBuilds}", _scheduledBuilds);
            }
        }
    }
}