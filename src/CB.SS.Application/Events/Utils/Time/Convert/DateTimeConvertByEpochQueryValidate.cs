using CB.SensorService.Src.Domain.Models.Event.Query;
using FluentValidation;

namespace Auge.Api.SmartBuildingEnergyManagement.Src.Application.Service.Utils.Time.Convert;

public class DateTimeConvertByEpochQueryValidate : AbstractValidator<DateTimeConvertByEpochQuery>
{
    public DateTimeConvertByEpochQueryValidate()
    {
        RuleFor(x => x.Epoch)
            .NotEmpty()
            .WithMessage("{PropertyName} is required!");

        var now = DateTimeOffset.Now.ToUnixTimeSeconds();
        RuleFor(x => x.Epoch)
            .GreaterThan(int.Parse(now.ToString()))
            .WithMessage("{PropertyName} must be greater than " + now + "!");
    }
}