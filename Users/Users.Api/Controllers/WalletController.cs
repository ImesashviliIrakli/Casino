using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Users.Application.Features.Queries.GetWalletByUserId;

namespace Users.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class WalletController : BaseController
{
    private readonly IMediator _mediator;
    public WalletController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetWalletByUserId")]
    public async Task<IActionResult> GetWalletByUserId()
    {
        var query = new GetWalletByUserIdQuery(GetCurrentUserId());

        var data = await _mediator.Send(query);

        return CreateResponse(data);
    }
}
