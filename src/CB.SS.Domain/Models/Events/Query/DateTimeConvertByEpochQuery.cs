using MediatR;

namespace CB.SensorService.Src.Domain.Models.Event.Query;

public class DateTimeConvertByEpochQuery : IRequest<DateTimeConvertByEpochQueryResponse>
{
    public int Epoch { get; set; }
}