namespace BldIt.Identity.Contracts.Results
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public Guid RefreshToken { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        //public string RefreshToken { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        
        //Null by default meaning there was no error
        public int? ErrorCode { get; set; } = null;
    }
}