namespace CB.SensorService.Src.Domain.Exception;

public class RestException : System.Exception
{
    public RestException(string message) : base(message)
    {
    }
}