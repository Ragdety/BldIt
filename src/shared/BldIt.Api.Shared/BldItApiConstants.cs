namespace BldIt.Api.Shared;

public static class BldItApiConstants
{
    // ReSharper disable once UnusedType.Global
    public static class BldItEnvironmentNames
    {
        // ReSharper disable once InconsistentNaming
        public const string BLDIT_HOME = nameof(BLDIT_HOME);
    }
    
    public static class Services
    {
        // ReSharper disable once UnusedType.Global
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
}