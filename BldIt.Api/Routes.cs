namespace BldIt.Api
{
    public struct Routes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string Base = Root + "/" + Version;

        public struct Jobs
        {
            private const string JobsBase = Base + "/jobs";

            public const string Get = JobsBase + "/{jobName}";
            public const string Post = JobsBase;
        }
        
        public struct Builds
        {
            private const string BuildsBase = Jobs.Get;

            public const string GetAll = BuildsBase + "/builds";
            public const string Get = BuildsBase + "/{buildId}";
            public const string Build = BuildsBase + "/build";
            
        }
    }
}