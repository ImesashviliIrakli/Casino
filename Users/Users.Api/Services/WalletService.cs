using Grpc.Core;
using MediatR;
using Users.Api.Grpc;
using Users.Application.Features.Queries.GetWalletByUserId;

namespace Users.Api.Services;

public class WalletService : WalletManager.WalletManagerBase
{
    private readonly IMediator _mediator;
    public WalletService(IMediator mediator)
    {
        _mediator = mediator;
    }
    public override async Task<GetWalletResponse> GetWallet(GetWalletRequest request, ServerCallContext context)
    {
        var query = new GetWalletByUserIdQuery(request.UserId);

        var data = await _mediator.Send(query);

        var response = new GetWalletResponse
        {
            UserId = request.UserId,
            Balance = data.Value.Balance.ToString(),
            Currency = data.Value.Currency.ToString(),
        };

        return response;
    }
}
