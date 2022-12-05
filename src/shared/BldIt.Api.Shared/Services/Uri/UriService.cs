using BldIt.Api.Shared.Services.Errors;

namespace BldIt.Api.Shared.Services.Uri
{
    public class UriService
    {
        private readonly string _baseUri;
        
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public System.Uri GetBuildByNumberUri(Guid projectId, string jobName, int buildNumber)
        {
            return new System.Uri(_baseUri + Routes.Builds.GetBuildByNumber
                .Replace("{projectId}", projectId.ToString())
                .Replace("{jobName}", jobName)
                .Replace("{buildNumber}", buildNumber.ToString()));
        }
        
        public System.Uri GetBuildUri(Guid projectId, string jobName)
        {
            return new System.Uri(_baseUri + Routes.Builds.Build
                .Replace("{projectId}", projectId.ToString())
                .Replace("{jobName}", jobName));
        }
        
        public System.Uri GetBuildConfigsUri(Guid projectId, string jobName)
        {
            return new System.Uri(_baseUri + Routes.BuildConfigs.GetAll
                .Replace("{projectId}", projectId.ToString())
                .Replace("{jobName}", jobName));
        }
        
        public System.Uri GetBuildConfigByIdUri(Guid projectId, string jobName, Guid buildConfigId)
        {
            return new System.Uri(_baseUri + Routes.BuildConfigs.Get
                .Replace("{projectId}", projectId.ToString())
                .Replace("{jobName}", jobName)
                .Replace("{configId}", buildConfigId.ToString()));
        }

        public System.Uri GetJobConfigsUri(Guid projectId, string jobName)
        {
            return new System.Uri(_baseUri + Routes.JobConfigs.GetAll
                .Replace("{projectId}", projectId.ToString())
                .Replace("{jobName}", jobName));
        }
        
        public System.Uri GetJobConfigByIdUri(Guid projectId, string jobName, Guid jobConfigId)
        {
            return new System.Uri(_baseUri + Routes.JobConfigs.Get
                .Replace("{projectId}", projectId.ToString())
                .Replace("{jobName}", jobName)
                .Replace("{configId}", jobConfigId.ToString()));
        }

        public System.Uri GetJobByNameUri(Guid projectId, string jobName)
        {
            return new System.Uri(_baseUri + Routes.Jobs.GetName
                .Replace("{projectId}", projectId.ToString())
                .Replace("{jobName}", jobName));
        }
        
        public System.Uri GetJobByIdUri(Guid jobId)
        {
            return new System.Uri(_baseUri + Routes.Jobs.GetId
                .Replace("{jobId}", jobId.ToString()));
        }
        
        public System.Uri GetJobsUri(Guid projectId)
        {
            return new System.Uri(_baseUri + Routes.Jobs.GetAll
                .Replace("{projectId}", projectId.ToString()));
        }
        
        public System.Uri GetProjectUri(string projectId)
        {
            return new System.Uri(_baseUri + Routes.Projects.Get
                .Replace("{projectId}", projectId));
        }
        
        public System.Uri GetDocsUri()
        {
            return new System.Uri(_baseUri + Routes.Docs.DocsBase);
        }
        
        public System.Uri GetDocErrorsUri()
        {
            return new System.Uri(_baseUri + Routes.Docs.Errors);
        }
        
        public System.Uri GetDocsErrorTypeUri(string errorTypeMessage)
        {
            var baseErrorDocs = _baseUri + Routes.Docs.Errors;
            var uriString = errorTypeMessage switch
            {
                ErrorTypeMessages.ExistingInstance => baseErrorDocs + '/' + nameof(ErrorTypeMessages.ExistingInstance),
                ErrorTypeMessages.InvalidInstance  => baseErrorDocs + '/' + nameof(ErrorTypeMessages.InvalidInstance),
                ErrorTypeMessages.InstanceNotFound => baseErrorDocs + '/' + nameof(ErrorTypeMessages.InstanceNotFound),
                ErrorTypeMessages.InstanceNotOwned => baseErrorDocs + '/' + nameof(ErrorTypeMessages.InstanceNotOwned),
                _ => baseErrorDocs
            };

            return new System.Uri(uriString);
        }
    }
}