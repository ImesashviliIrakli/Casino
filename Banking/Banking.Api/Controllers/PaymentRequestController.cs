using Banking.Application.Features.Queries.GetPaymentRequestById;
using Banking.Application.Features.Queries.GetPaymentRequests;
using BuildingBlocks.Applictaion.Models.Filters;
using BuildingBlocks.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class PaymentRequestController : BaseController
{
    private readonly IMediator _mediator;
    public PaymentRequestController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] DateTime start,
        [FromQuery] DateTime end,
        [FromQuery] OrderType orderType = OrderType.Descending,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 20
        )
    {
        var filterParameters = new FilterParameters(start, end, orderType, page, pageSize);

        var query = new GetPaymentRequestsQuery(filterParameters);

        var data = await _mediator.Send(query);

        return CreateResponse(data);
    }

    [HttpGet("{paymentRequestId}")]
    public async Task<IActionResult> Get(Guid paymentRequestId)
    {
        var query = new GetPaymentRequestByIdQuery(paymentRequestId);

        var data = await _mediator.Send(query);

        return CreateResponse(data);
    }
}
