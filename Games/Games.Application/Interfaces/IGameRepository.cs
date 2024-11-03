using BuildingBlocks.Domain.Enums;
using Games.Domain.Entities;

namespace Games.Application.Interfaces;

public interface IGameRepository
{
    Task<List<Game>> GetGamesAsync(GameType gameType, CancellationToken cancellationToken = default);
    Task<Game> GetGameByIdAsync(Guid gameId, CancellationToken cancellationToken = default);
    Task AddAsync(Game game, CancellationToken cancellationToken = default);
    void Delete(Game game);
}
