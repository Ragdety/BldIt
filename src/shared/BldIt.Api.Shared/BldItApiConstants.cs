namespace BldIt.Api.Shared;

public static class BldItApiConstants
{
    public static class Services
    {
        // ReSharper disable once UnusedType.Global
        public struct Identity
        {
            public const string Name = $"BldIt{nameof(Identity)}Service";
            
            public static class Collections
            {
                public const string Users = "Users";
                public const string Roles = "Roles";
            }
        }
        
        // ReSharper disable once UnusedType.Global
        public struct Builds
        {
            public const string Name = $"BldIt{nameof(Builds)}Service";
            
            public static class Collections
            {
                public const string Builds = "Builds";
            }
        }
        
        // ReSharper disable once UnusedType.Global
        public struct Projects
        {
            public const string Name = $"BldIt{nameof(Projects)}Service";
            
            public static class Collections
            {
                public const string Projects = "Projects";
            }
        }
    }
}