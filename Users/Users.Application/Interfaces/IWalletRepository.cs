using Users.Domain.Entities;

namespace Users.Application.Interfaces;

public interface IWalletRepository
{
    Task AddAsync(Wallet wallet);
}
