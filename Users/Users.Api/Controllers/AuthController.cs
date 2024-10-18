using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Features.Commands.RegisterUser;

namespace Users.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("RegisterUser")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
    {
        var data = await _mediator.Send(command);

        return data.IsSuccess
               ? Ok(data.Value)
               : NotFound(data.Error);
    }
}
