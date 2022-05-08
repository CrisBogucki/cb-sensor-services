using MediatR;

namespace CB.SensorService.Src.Domain.Models.Event.Command;

public class InputSignalCommand : IRequest
{
    public string? Token { get; set; }
    public int EpochTime { get; set; }
    public List<InputSignalValue>? Value { get; set; }
}

public abstract class InputSignalValue
{
    public string Address { get; set; }
    public decimal TempC { get; set; }
    public decimal TempF { get; set; }
} 