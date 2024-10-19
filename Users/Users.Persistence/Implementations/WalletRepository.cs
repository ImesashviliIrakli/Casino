using Microsoft.EntityFrameworkCore;
using Users.Application.Interfaces;
using Users.Domain.Entities;
using Users.Persistence.Data;

namespace Users.Persistence.Implementations;

public class WalletRepository : IWalletRepository
{
    private readonly AppDbContext _context;
    public WalletRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Wallet wallet) => await _context.Wallets.AddAsync(wallet);

    public async Task DeleteAsync(Wallet wallet)
    {
        await Task.Run(() =>
        {
            _context.Wallets.Remove(wallet);
        });
    }

    public async Task<Wallet> GetWalletByUserId(string userId)
    {
        return await _context.Wallets.FirstOrDefaultAsync(x => x.PlayerUserId.Equals(userId));
    }
}
