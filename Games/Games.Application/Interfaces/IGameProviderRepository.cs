using BuildingBlocks.Domain.Enums;
using Games.Domain.Entities;

namespace Games.Application.Interfaces;

public interface IGameProviderRepository
{
    Task<List<GameProvider>> GetGameProvidersAsync(GameType gameType = 0, CancellationToken cancellationToken = default);
    Task<GameProvider> GetGameProviderByIdAsync(Guid gameProviderId, CancellationToken cancellationToken = default);
    Task AddAsync(GameProvider gameProvider, CancellationToken cancellationToken = default);
    void Delete(GameProvider gameProvider, CancellationToken cancellationToken = default);
}
