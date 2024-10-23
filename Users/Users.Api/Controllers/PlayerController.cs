using BuildingBlocks.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Features.Queries.GetAllPlayers;
using Users.Application.Features.Queries.GetPlayerById;

namespace Users.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class PlayerController : BaseController
{
    private readonly IMediator _mediator;
    public PlayerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPlayers()
    {
        var query = new GetAllPlayersQuery();

        var data = await _mediator.Send(query);

        return CreateResponse(data);
    }

    [HttpGet("{playerId}")]
    public async Task<IActionResult> GetPlayerById(string playerId)
    {
        var query = new GetPlayerByIdQuery(playerId);

        var data = await _mediator.Send(query);

        return CreateResponse(data);
    }
}
