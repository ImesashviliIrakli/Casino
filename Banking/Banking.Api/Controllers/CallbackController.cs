using Banking.Application.Deposit.EndBOGDeposit;
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
}
