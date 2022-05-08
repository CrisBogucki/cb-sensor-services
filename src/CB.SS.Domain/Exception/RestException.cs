namespace Auge.Api.SmartBuildingEnergyManagement.Src.Domain.Exception;

public class RestException : System.Exception
{
    public RestException(string message) : base(message)
    {
    }
}