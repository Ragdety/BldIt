using System.Runtime.InteropServices;

namespace BldIt.Shared.OSInformation;

public static class OsInfo
{
    public static bool IsLinux()   => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    public static bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    public static bool IsMacOs()   => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

    public struct Paths
    {
        public struct Linux
        {
            public static string Shell => "/usr/bin/sh";
            public static string Bash  => "/usr/bin/bash";
        }
    }
}