using Banking.Application.Models;

namespace Banking.Application.Interfaces;

public interface IWalletGrpcService
{
    Task<WalletDto> GetWalletDataAsync(string userId, CancellationToken cancellationToken);

}
