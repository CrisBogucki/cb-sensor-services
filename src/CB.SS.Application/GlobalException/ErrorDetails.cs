using System.Text.Json;

namespace Auge.Api.SmartBuildingEnergyManagement.Src.Application.GlobalException;

public class ErrorDetails
{
    public ErrorDetails(int statusCode, string message, IEnumerable<string> validateDetails)
    {
        StatusCode = statusCode;
        Message = message;
        ValidateDetails = validateDetails;
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }
    public IEnumerable<string> ValidateDetails { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}