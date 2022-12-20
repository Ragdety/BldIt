using BldIt.BuildScheduler.Core.Interfaces;

namespace BldIt.BuildScheduler.Api.BackgroundServices;

public class BuildScheduler : BackgroundService
{
    private readonly IBuildQueue _buildQueue;
    private readonly ILogger<BuildScheduler> _logger;
    private int _buildCount;

    public BuildScheduler(IBuildQueue buildQueue, ILogger<BuildScheduler> logger)
    {
        _buildQueue = buildQueue;
        _logger = logger;
        _buildCount = 0;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("BuildScheduler is listening and ready to take builds");
        while (!stoppingToken.IsCancellationRequested)
        {
            if (stoppingToken.IsCancellationRequested)
            {
                _logger.LogWarning("BuildScheduler is shutting down");
                _logger.LogInformation("BuildScheduler executed {BuildCount} builds total", _buildCount);
                return;
            }
            
            //Redirect Build Request to a Worker Queue
            var build = await _buildQueue.DequeueBuildAsync(stoppingToken);
            
            _logger.LogInformation("A build is being executed by the {BuildScheduler}", nameof(BuildScheduler));

            //Build the specific commands
            await build(stoppingToken);
            
            _logger.LogInformation("A build has finished execution by the {BuildScheduler}", nameof(BuildScheduler));
            _buildCount++;
            _logger.LogInformation("BuildScheduler executed {BuildCount} builds so far", _buildCount);
        }
    }
}