using BuildingBlocks.Domain.Enums;
using Games.Application.Features.Commands.AddGame;
using Games.Application.Features.Commands.DisableGame;
using Games.Application.Features.Commands.TestModeGame;
using Games.Application.Features.Commands.UpdateGame;
using Games.Application.Features.Queries.GetGameById;
using Games.Application.Features.Queries.GetGames;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Games.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController(IMediator mediator) : BaseController
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GameType gameType)
    {
        var query = new GetGamesQuery(gameType);

        var data = await _mediator.Send(query);

        return CreateResponse(data);
    }

    [HttpGet("{gameId}")]
    public async Task<IActionResult> Get(Guid gameId)
    {
        var query = new GetGameByIdQuery(gameId);

        var data = await _mediator.Send(query);

        return CreateResponse(data);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] AddGameCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateGameCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }

    [HttpPatch("SetGameTestMode")]
    public async Task<IActionResult> SetGameTestMode([FromBody] TestModeGameCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }

    [HttpPatch("SetGameIsDisabled")]
    public async Task<IActionResult> SetGameIsDisabled([FromBody] DisableGameCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }
}
