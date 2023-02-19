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
            public const string Refresh = IdentityBase + "/refresh";
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
            public const string Put = ProjectsBase + "/{projectId}";
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
            
            public const string GetAll = JobsBase;
            public const string Post = GetAll;
        }
        
        public struct JobConfigs
        {
            public const string Version = "v1";
            private const string Base = Root + "/" + Version;
            private const string JobConfigsBase = Jobs.GetName + "/configs";
            
            public const string Get = JobConfigsBase + "/{configId}";
            public const string GetAll = JobConfigsBase;
            public const string Post = GetAll;
            
            public const string GetLatest = JobConfigsBase + "/latest";
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
            public const string GetBuildByNumber = GetAll + "/{buildNumber}";
            
            /// <summary>
            /// Intended to get the script used to build a specific build
            /// </summary>
            public const string GetBuildScriptFile = GetBuildByNumber + "/script";
            
            /// <summary>
            /// Intended to get the log outputted by the build
            /// </summary>
            public const string GetBuildLog = GetBuildByNumber + "/log";
            
            /// <summary>
            /// Intended to get a build within the entire database, admin only (most probably)
            /// </summary>
            public const string GetBuildById = Base + "/builds/{buildId}";

            public const string Build = BuildsBase + "/build";
        }
        
        public struct BuildConfigs
        {
            public const string Version = "v1";
            private const string Base = Root + "/" + Version;
            private const string BuildConfigsBase = Jobs.GetName + "/buildConfigs";
            
            public const string Get = BuildConfigsBase + "/{configId}";
            public const string GetAll = BuildConfigsBase;
            public const string Post = GetAll;
            
            public const string GetLatest = BuildConfigsBase + "/latest";
        }
        
        public struct GitHub
        {
            public const string Version = "v1";
            private const string Base = Root + "/" + Version;
            private const string GitHubBase = Base + "/github";

            public struct Credentials
            {
                private const string CredentialsBase = GitHubBase + "/credentials";
                
                public const string GetAll = CredentialsBase;
                public const string Get = CredentialsBase + "/{credentialId}";
                public const string Post = CredentialsBase;
                public const string Delete = CredentialsBase + "/{credentialId}";
            }
            
            public struct Auth
            {
                private const string AuthBase = GitHubBase;
                
                public const string Login = AuthBase + "/login";
                public const string Logout = AuthBase + "/logout";
            }
            
            public struct Configs
            {
                private const string ConfigsBase = GitHubBase + "/configs";
                
                public const string GetAll = ConfigsBase;
                public const string Get = ConfigsBase + "/{configId}";
                public const string Post = ConfigsBase;
                public const string Delete = ConfigsBase + "/{configId}";
            }
            
            public struct Repositories
            {
                private const string RepositoriesBase = GitHubBase + "/repositories";
                
                public const string GetAll = RepositoriesBase;
                public const string Get = RepositoriesBase + "/{repositoryId}";
            }
            
            public struct Webhooks
            {
                private const string WebhooksBase = GitHubBase + "/webhooks";
                
                public const string GetAll = WebhooksBase;
                public const string Get = WebhooksBase + "/{webhookId}";
                public const string Post = WebhooksBase;
                public const string Delete = WebhooksBase + "/{webhookId}";
            }
            
            public struct Branches
            {
                private const string BranchesBase = GitHubBase + "/branches";
                
                public const string GetAll = BranchesBase;
                public const string Get = BranchesBase + "/{branchId}";
            }
            
            public struct Commits
            {
                private const string CommitsBase = GitHubBase + "/commits";
                
                public const string GetAll = CommitsBase;
                public const string Get = CommitsBase + "/{commitId}";
            }
            
            public struct PullRequests
            {
                private const string PullRequestsBase = GitHubBase + "/pullRequests";
                
                public const string GetAll = PullRequestsBase;
                public const string Get = PullRequestsBase + "/{pullRequestId}";
            }
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