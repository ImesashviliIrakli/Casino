using MediatR;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Features.Commands.Login;
using Users.Application.Features.Commands.RegisterUser;

namespace Users.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }

    [HttpPost("RegisterUser")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }
}
