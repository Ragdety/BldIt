using BldIt.Api.Shared.Services.Errors;

namespace BldIt.Api.Shared.Services
{
    public class UriService
    {
        private readonly string _baseUri;
        
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        
        public Uri GetJobByNameUri(Guid projectId, string jobName)
        {
            return new Uri(_baseUri + Routes.Jobs.GetName
                .Replace("{projectId}", projectId.ToString())
                .Replace("{jobName}", jobName));
        }
        
        public Uri GetJobByIdUri(Guid jobId)
        {
            return new Uri(_baseUri + Routes.Jobs.GetId
                .Replace("{jobId}", jobId.ToString()));
        }
        
        public Uri GetProjectUri(string projectId)
        {
            return new Uri(_baseUri + Routes.Projects.Get
                .Replace("{projectId}", projectId));
        }
        
        public Uri GetDocsUri()
        {
            return new Uri(_baseUri + Routes.Docs.DocsBase);
        }
        
        public Uri GetDocErrorsUri()
        {
            return new Uri(_baseUri + Routes.Docs.Errors);
        }
        
        public Uri GetDocsErrorTypeUri(string errorTypeMessage)
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

            return new Uri(uriString);
        }
    }
}