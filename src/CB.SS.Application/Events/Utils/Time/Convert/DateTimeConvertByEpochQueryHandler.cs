using CB.SensorService.Src.Domain.Models.Event.Query;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CB.SensorService.Src.Application.Service.Utils.Time.Convert;

public class
    DateTimeConvertByEpochQueryHandler : IRequestHandler<DateTimeConvertByEpochQuery,
        DateTimeConvertByEpochQueryResponse>
{
    private readonly ILogger<DateTimeConvertByEpochQueryHandler> _logger;

    public DateTimeConvertByEpochQueryHandler(ILogger<DateTimeConvertByEpochQueryHandler> logger)
    {
        _logger = logger;
    }

    public async Task<DateTimeConvertByEpochQueryResponse> Handle(DateTimeConvertByEpochQuery request,
        CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            var now = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(request.Epoch);

            // ReSharper disable once TemplateIsNotCompileTimeConstantProblem
            _logger.LogInformation($"Convert epoch=[{request.Epoch}] to datetime=[{now}]");

            return new DateTimeConvertByEpochQueryResponse(now);
        }, cancellationToken);
    }
}