namespace BldIt.BuildWorker.Core.Services;

//In memory database to hold the build logs
public class BuildLogRegistry
{
    //Dictionary to hold the build logs. Build ID as the key and list of logs as the value
    private readonly Dictionary<Guid, List<string>> _buildLogs = new();

    public void CreateBuildLogRoom(Guid buildId)
    {
        //Create a room with empty log messages list
        if (!_buildLogs.ContainsKey(buildId))
        {
            _buildLogs.Add(buildId, new List<string>());
        }
    }

    public void AppendBuildLog(Guid buildId, string log)
    {
        _buildLogs[buildId].Add(log);
    }
    
    public IEnumerable<string> GetBuildLogs(Guid buildId)
    {
        return _buildLogs[buildId];
    }
    
    public List<Guid> GetBuildLogRooms()
    {
        return _buildLogs.Keys.ToList();
    }
    
    //Once the build is done, we can invoke this method and remove the in memory logs and use the log file contents instead
    //To display in the frontend if the user requests to see logs
    public void RemoveBuildLogRoom(Guid buildId)
    {
        _buildLogs.Remove(buildId);
    }
}