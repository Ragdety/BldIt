namespace BldIt.Api.Shared
{
    public struct Routes
    {
        private const string Root = "api";

        public struct Identity
        {
            public const string Version = "v1";
            private const string Base = Root + "/" + Version;
            private const string IdentityBase = Base + "/identity";

            public const string Register = IdentityBase + "/register";
            public const string Login = IdentityBase + "/login";
        }
        
        public struct Projects
        {
            public const string Version = "v1";
            private const string Base = Root + "/" + Version;
            private const string ProjectsBase = Base + "/projects";

            public const string GetAll = ProjectsBase;
            public const string Get = ProjectsBase + "/{projectId}";
            public const string GetQuery = ProjectsBase + "/search";
            public const string Post = ProjectsBase;
            public const string Delete = ProjectsBase + "/{projectId}";
        }

        public struct Jobs
        {
            public const string Version = "v1";
            private const string Base = Root + "/" + Version;
            private const string JobsBase = Projects.Get + "/jobs";

            /// <summary>
            /// Intended to get a job within a project, for specific users in a project
            /// </summary>
            public const string GetName = JobsBase + "/{jobName}";
            
            /// <summary>
            /// Intended to get a job within the entire database, admin only (most probably)
            /// </summary>
            public const string GetId = Base + "/jobs/{jobId}";
            public const string Post = JobsBase;
        }
        
        public struct Builds
        {
            public const string Version = "v1";
            private const string Base = Root + "/" + Version;
            private const string BuildsBase = Jobs.GetName;

            public const string GetAll = BuildsBase + "/builds";
            
            /// <summary>
            /// Intended to get a build within a project's job, for specific job in user's project
            /// </summary>
            public const string GetBuildByNumber = GetAll + "/{buildId}";
            
            /// <summary>
            /// Intended to get a build within the entire database, admin only (most probably)
            /// </summary>
            public const string GetBuildById = Base + "/builds/{buildId}";
            public const string Build = BuildsBase + "/build";
        }

        public struct Docs
        {
            public const string Version = "v1";
            private const string Base = Root + "/" + Version;
            
            public const string DocsBase = Base + "/docs";
            public const string Errors = DocsBase + "/errors";
        }
    }
}