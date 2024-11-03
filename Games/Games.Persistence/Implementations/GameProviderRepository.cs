using BuildingBlocks.Domain.Enums;
using Games.Application.Interfaces;
using Games.Domain.Entities;
using Games.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Games.Persistence.Implementations;

public class GameProviderRepository(AppDbContext context) : IGameProviderRepository
{
    private readonly AppDbContext _context = context;
    public async Task AddAsync(GameProvider gameProvider, CancellationToken cancellationToken = default) 
        => await _context.GameProviders.AddAsync(gameProvider, cancellationToken);

    public void Delete(GameProvider gameProvider, CancellationToken cancellationToken = default)
        => _context.GameProviders.Remove(gameProvider);

    public async Task<GameProvider> GetGameProviderByIdAsync(Guid gameProviderId, CancellationToken cancellationToken = default)
        => await _context.GameProviders.FirstOrDefaultAsync(x => x.Id.Equals(gameProviderId));
    public async Task<List<GameProvider>> GetGameProvidersAsync(GameType gameType = 0, CancellationToken cancellationToken = default)
        => await _context.GameProviders.Where(x => x.GameType.Equals(gameType)).ToListAsync();
}
