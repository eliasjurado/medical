using Medical.Domain.Dto.Response.Abstract;
using Medical.Resource;

namespace Medical.Domain.Dto.Response.Concrete;

public class DataResponse<T> : IDataResponse<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }

    public int StatusCode { get; }
    public List<string> Messages { get; private set; } = new List<string>();

    public DataResponse(T data, int statuscode, bool success = true)
    {
        Data = data;
        StatusCode = statuscode;
        Success = success;
        if (success)
        {
            Messages.Add(Resource.Messages.DataFound);
        }
        else
        {
            Messages.Add(Resource.Messages.NoDataFound);
        }

    }

    public DataResponse(T data, int statuscode, string message, bool success = true)
    {
        Data = data;
        StatusCode = statuscode;
        Success = success;
        Messages.Add(message);
    }

    public DataResponse(T data, int statuscode, List<string> messages, bool success = true)
    {
        Data = data;
        StatusCode = statuscode;
        Success = success;
        Messages = messages;
    }

    public DataResponse(T data)
    {
        Data = data;
        StatusCode = HttpStatusCodes.ACCEPTED;
        Success = true;
    }
}