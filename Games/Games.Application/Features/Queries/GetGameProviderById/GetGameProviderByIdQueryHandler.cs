using AutoMapper;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Shared;
using Games.Application.Interfaces;
using Games.Application.Models;
using Games.Domain.Errors;

namespace Games.Application.Features.Queries.GetGameProviderById;

public class GetGameProviderByIdQueryHandler(IGameProviderRepository gameProviderRepository, IMapper mapper) : ICommandQueryHandler<GetGameProviderByIdQuery, GameProviderDto>
{
    private readonly IGameProviderRepository _gameProviderRepository = gameProviderRepository;
    private readonly IMapper _mapper = mapper;
    public async Task<Result<GameProviderDto>> Handle(GetGameProviderByIdQuery request, CancellationToken cancellationToken)
    {
        var gameProvider = await _gameProviderRepository.GetGameProviderByIdAsync(request.GameProviderId, cancellationToken);

        if (gameProvider is null)
            return Result.Failure<GameProviderDto>(GameDomainErrors.ProviderNotFound);

        return _mapper.Map<GameProviderDto>(gameProvider);
    }
}
