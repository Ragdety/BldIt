using System;

namespace BldIt.Api.Services
{
    public class UriService
    {
        private readonly string _baseUri;
        
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        
        public Uri GetJobUri(string jobName)
        {
            return new Uri(_baseUri + Routes.Jobs.Get.Replace("{jobName}", jobName));
        }
    }
}