using Users.Domain.Entities;

namespace Users.Application.Interfaces;

public interface IWalletRepository
{
    Task<Wallet> GetWalletByUserId(string userId);
    Task AddAsync(Wallet wallet);
    Task DeleteAsync(Wallet wallet);
}
