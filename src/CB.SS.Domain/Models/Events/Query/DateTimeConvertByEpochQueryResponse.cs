namespace CB.SensorService.Src.Domain.Models.Event.Query;

public class DateTimeConvertByEpochQueryResponse
{
    public DateTimeConvertByEpochQueryResponse(DateTime dateTime)
    {
        DateTime = dateTime;
    }

    public DateTime DateTime { get; }
}