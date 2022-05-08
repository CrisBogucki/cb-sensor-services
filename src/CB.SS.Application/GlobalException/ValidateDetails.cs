using System.Text.Json;

namespace CB.SensorService.Src.Application.GlobalException;

public class ValidateDetails
{
    public ValidateDetails(string propertyName, string message)
    {
        PropertyName = propertyName;
        Message = message;
    }

    public string PropertyName { get; set; }
    public string Message { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}