using System.Security.Claims;
// ReSharper disable UnusedType.Global

namespace BldIt.Api.Shared;

public static class BldItApiConstants
{
    public struct BldItEnvironmentNames
    {
        // ReSharper disable once InconsistentNaming
        public const string BLDIT_HOME = nameof(BLDIT_HOME);
    }
    
    public struct Services
    {
        public struct Identity
        {
            public const string Name = $"BldIt{nameof(Identity)}Service";
            
            public static class Collections
            {
                public const string Users = nameof(Users);
                public const string Roles = nameof(Roles);
            }
        }
        
        // ReSharper disable once UnusedType.Global
        public struct Builds
        {
            public const string Name = $"BldIt{nameof(Builds)}Service";
            
            public static class Collections
            {
                public const string Builds = nameof(Builds);
                public const string BuildSteps = nameof(BuildSteps);
                public const string BuildConfigs = nameof(BuildConfigs);
            }
        }
        
        // ReSharper disable once UnusedType.Global
        public struct Jobs
        {
            public const string Name = $"BldIt{nameof(Jobs)}Service";
            
            public static class Collections
            {
                public const string Jobs = nameof(Jobs);
                public const string JobConfigs = nameof(JobConfigs);
            }
        }
        
        // ReSharper disable once UnusedType.Global
        public struct Projects
        {
            public const string Name = $"BldIt{nameof(Projects)}Service";
            
            public static class Collections
            {
                public const string Projects = nameof(Projects);
            }
        }
    }
    
    public struct Policies
    {
        // public const string User = IdentityServerConstants.LocalApi.PolicyName;
        public const string Admin = nameof(Admin);
    }

    public struct IdentityResources
    {
        public const string RoleScope = "role";
    }

    public struct Claims
    {
        public const string Role = "role";
        public static readonly Claim AdminClaim = new(Role, Roles.Admin);
    }

    public struct Roles
    {
        public const string Mod = nameof(Mod);
        public const string Admin = nameof(Admin);
    }

    public struct Files
    {
        public struct Providers
        {
            public const string Local = nameof(Local);
            public const string S3 = nameof(S3);
        }

        public const string BldItTempPrefix = "bldit_temp_";
        public const string BldItScriptPrefix = "bldit_script_";
        public const string BldItScriptLogPrefix = "bldit_script_log_";
        
        public const string BldItLogExtension = ".log";
        public const string BldItTempExtension = ".temp";

        public struct ScriptTypeExtensions
        {
            public const string Bash = ".sh";
            public const string Batch = ".bat";
            public const string PowerShell = ".ps1";
            public const string Python = ".py";
            public const string BldIt = ".bldit";
        }
        
        public static string GenerateScriptFileName(ScriptTypeExtensions scriptType)
        {
            return $"{BldItScriptPrefix}{DateTime.Now.Ticks}{scriptType}";
        }
        
        public static string GenerateScriptLogFileName()
        {
            return $"{BldItScriptLogPrefix}{DateTime.Now.Ticks}{BldItLogExtension}";
        }
    }
}