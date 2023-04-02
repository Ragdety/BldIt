using BldIt.Shared.OSInformation;

namespace BldIt.Shared.Utils;

public static class PathUtil
{
    public static string PathVariable => 
        OsInfo.IsWindows() ? "Path" : "PATH";
    
    public static string AddToPath(string path, string currentPath)
    {
        if (string.IsNullOrEmpty(currentPath))
        {
            return path;
        }

        return currentPath.StartsWith(path) ? currentPath : $"{path}{Path.PathSeparator}{currentPath}";
    }
    
    public static void AddToPath(string directory)
    {
        var currentPath = Environment.GetEnvironmentVariable(PathVariable);
        var newPath = AddToPath(directory, currentPath);
        Environment.SetEnvironmentVariable(PathVariable, newPath);
    }
}