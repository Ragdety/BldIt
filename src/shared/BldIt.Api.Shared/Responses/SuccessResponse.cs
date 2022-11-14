namespace BldIt.Api.Shared.Responses;

public class SuccessResponse<T> : IResponse
{
    public SuccessResponse()
    {
        Data = new List<T>();
    }

    public SuccessResponse(IEnumerable<T> data)
    {
        Data = data;
    }

    public IEnumerable<T> Data { get; set; }
    public string Message { get; set; } = "Success";
}