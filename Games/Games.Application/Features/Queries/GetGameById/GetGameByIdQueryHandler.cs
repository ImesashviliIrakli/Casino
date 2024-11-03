using AutoMapper;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Shared;
using Games.Application.Interfaces;
using Games.Application.Models;
using Games.Domain.Errors;

namespace Games.Application.Features.Queries.GetGameById;

public class GetGameByIdQueryHandler(IGameRepository gameRepository, IMapper mapper) : ICommandQueryHandler<GetGameByIdQuery, GameDto>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<GameDto>> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetGameByIdAsync(request.GameId, cancellationToken);

        if (game is null)
            return Result.Failure<GameDto>(GameDomainErrors.GameNotFound);

        return _mapper.Map<GameDto>(game);
    }
}
