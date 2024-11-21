namespace Medical.Domain.Dto.Response.Abstract;

public interface IResponse
{
    bool Success { get; }
    int StatusCode { get; }
}
