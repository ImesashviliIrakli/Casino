using Banking.Application.Interfaces;
using Banking.Application.Models;
using Google.Protobuf;
using Grpc.Net.ClientFactory;
using Users.Api.Grpc;

namespace Banking.Infrastructure.Grpc;

public class WalletGrpcService : IWalletGrpcService
{
    private readonly WalletManager.WalletManagerClient _client;

    public WalletGrpcService(GrpcClientFactory grpcClientFactory)
    {
        _client = grpcClientFactory.CreateClient<WalletManager.WalletManagerClient>("Wallet");

    }

    public async Task<WalletDto> GetWalletDataAsync(string userId, CancellationToken cancellationToken)
    {
        var request = new GetWalletRequest
        {
            UserId = userId
        };

        var response = await _client.GetWalletAsync(request);

        return new WalletDto(response.Balance, response.Currency);
    }
}
