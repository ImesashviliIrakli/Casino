using AutoMapper;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Shared;
using Games.Application.Interfaces;
using Games.Application.Models;

namespace Games.Application.Features.Queries.GetGames;

public class GetGamesQueryHandler(IGameRepository gameRepository, IMapper mapper) : ICommandQueryHandler<GetGamesQuery, List<GameDto>>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<List<GameDto>>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
    {
        var games = await _gameRepository.GetGamesAsync(request.GameType, cancellationToken);

        return _mapper.Map<List<GameDto>>(games);
    }
}
