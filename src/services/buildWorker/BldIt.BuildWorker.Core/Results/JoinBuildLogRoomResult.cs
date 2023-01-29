namespace BldIt.BuildWorker.Core.Results;

public class JoinBuildLogRoomResult
{
    public IEnumerable<string>? Logs { get; set; }
    public bool Joined { get; set; }
    public List<string>? Errors { get; set; }
}