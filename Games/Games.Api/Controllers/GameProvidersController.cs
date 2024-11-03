using BuildingBlocks.Domain.Enums;
using Games.Application.Features.Commands.AddGameProvider;
using Games.Application.Features.Commands.DisableGameProvider;
using Games.Application.Features.Commands.TestModeGameProvider;
using Games.Application.Features.Commands.UpdateGameProvider;
using Games.Application.Features.Queries.GetGameProviderById;
using Games.Application.Features.Queries.GetGameProviders;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Games.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameProvidersController(IMediator mediator) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GameType gameType)
    {
        var query = new GetGameProvidersQuery(gameType);

        var data = await _mediator.Send(query);

        return CreateResponse(data);
    }

    [HttpGet("{gameProviderId}")]
    public async Task<IActionResult> Get(Guid gameProviderId)
    {
        var query = new GetGameProviderByIdQuery(gameProviderId);

        var data = await _mediator.Send(query);

        return CreateResponse(data);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddGameProviderCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateGameProviderCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }

    [HttpPatch("SetGameProviderTestMode")]
    public async Task<IActionResult> SetGameProviderTestMode([FromBody] TestModeGameProviderCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }

    [HttpPatch("SetGameProviderIsDisabled")]
    public async Task<IActionResult> SetGameProviderIsDisabled([FromBody] DisableGameProviderCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }
}
