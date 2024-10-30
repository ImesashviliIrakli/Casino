using Banking.Application.Deposit.EndBOGDeposit;
using Banking.Application.WIthdraw.EndBOGWithdraw;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CallbackController : BaseController
{
    private readonly IMediator _mediator;
    public CallbackController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("EndBOGDeposit")]
    public async Task<IActionResult> EndBOGDeposit(EndBOGDepositCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }

    [HttpPost("EndBOGWithdraw")]
    public async Task<IActionResult> EndBOGWithdraw(EndBOGWithdrawCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }
}
