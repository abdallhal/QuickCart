using System.Collections.Generic;
using System.Linq;

public class ServiceResponse<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public int TotalRecords { get; set; }

    public static ServiceResponse<T> DeliverData(T data, string message = "Operation successful.")
    {
        var response = new ServiceResponse<T>
        {
            Message = message,
            Data = data,
            Success = true
        };

        if (data is IEnumerable<T> enumerableData)
        {
            response.TotalRecords = enumerableData.Count();
        }
        else
        {
            response.TotalRecords = 1;
        }

        return response;
    }

    public static ServiceResponse<T> ReportError(string message)
    {
        return new ServiceResponse<T> { Message = message };
    }
}
