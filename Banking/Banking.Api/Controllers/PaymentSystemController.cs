using Banking.Application.Features.Commands.CreatePaymentSystem;
using Banking.Application.Features.Commands.DeletePaymentSystem;
using Banking.Application.Features.Commands.DisablePaymentSystem;
using Banking.Application.Features.Commands.TestModePaymentSystem;
using Banking.Application.Features.Commands.UpdatePaymentSystem;
using Banking.Application.Features.Queries.GetPaymentSystemById;
using Banking.Application.Features.Queries.GetPaymentSystems;
using BuildingBlocks.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class PaymentSystemController : BaseController
{
    private readonly IMediator _mediator;
    public PaymentSystemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Get([FromQuery] PaymentDirection paymentDirection)
    {
        bool includeTestPaymentSystems = GetCurrentUserRole() == Roles.TestPlayer.ToString();

        var query = new GetPaymentSystemsQuery(paymentDirection, includeTestPaymentSystems);

        var data = await _mediator.Send(query);

        return CreateResponse(data);
    }

    [HttpGet("{paymentSystemId}")]
    public async Task<IActionResult> Get(Guid paymentSystemId)
    {
        var query = new GetPaymentSystemByIdQuery(paymentSystemId);

        var data = await _mediator.Send(query);

        return CreateResponse(data);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreatePaymentSystemCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdatePaymentSystemCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }

    [HttpPatch("DisablePaymentSystem")]
    public async Task<IActionResult> DisablePaymentSystem(DisablePaymentSystemCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }

    [HttpPatch("TestModePaymentSystem")]
    public async Task<IActionResult> TestModePaymentSystem(TestModePaymentSystemCommand command)
    {
        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }

    [HttpDelete("{paymentSystemId}")]
    public async Task<IActionResult> Delete(Guid paymentSystemId)
    {
        var command = new DeletePaymentSystemCommand(paymentSystemId);

        var data = await _mediator.Send(command);

        return CreateResponse(data);
    }
}
