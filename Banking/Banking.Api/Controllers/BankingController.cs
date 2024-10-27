using Banking.Application.Deposit.StartBOGDeposit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Player")]
public class BankingController : BaseController
{
    private readonly IMediator _mediator;
    public BankingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("StartBOGDeposit")]
    public async Task<IActionResult> StartBOGDeposit([FromBody] decimal amount)
    {
        var command = new StartBOGDepositCommand(amount, GetCurrentUserId());

        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }
}
