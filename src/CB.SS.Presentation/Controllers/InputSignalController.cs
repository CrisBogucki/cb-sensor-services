using Auge.Api.SmartBuildingEnergyManagement.Src.Presentation.DTO;
using CB.SensorService.Src.Domain.Models.Event.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CB.SensorService.Src.Presentation.Controllers;

[Route("api/[controller]")]
public class InputSignalController : Controller
{
    private readonly IMediator _mediator;

    public SensorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("input-signal")]
    public async Task<List<GraphItemDto>> GetItem(InputSignalCommand query, CancellationToken cancellationToken)
    {
        var models = await _mediator
            .Send(query, cancellationToken);
        
    }
}