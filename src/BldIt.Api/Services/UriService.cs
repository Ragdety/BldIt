namespace BldIt.Api.Services
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
    }
}