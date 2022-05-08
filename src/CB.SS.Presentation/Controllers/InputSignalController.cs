using CB.SensorService.Src.Domain.Models.Event.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CB.SensorService.Src.Presentation.Controllers;

[Route("api/[controller]")]
public class InputSignalController : Controller
{
    private readonly IMediator _mediator;

    public InputSignalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task Add(InputSignalCommand query, CancellationToken cancellationToken)
    {
        await _mediator.Send(query, cancellationToken);
    }
}