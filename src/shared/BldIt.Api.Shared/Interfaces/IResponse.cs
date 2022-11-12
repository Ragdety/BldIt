namespace BldIt.Api.Shared.Interfaces
{
    public interface IResponse
    {
        //All responses have a message
        public string Message { get; set; }
    }
}