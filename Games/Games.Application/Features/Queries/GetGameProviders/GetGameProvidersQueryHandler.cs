using AutoMapper;
using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Domain.Shared;
using Games.Application.Interfaces;
using Games.Application.Models;

namespace Games.Application.Features.Queries.GetGameProviders;

public class GetGameProvidersQueryHandler(IGameProviderRepository gameProviderRepository, IMapper mapper) : ICommandQueryHandler<GetGameProvidersQuery, List<GameProviderDto>>
{
    private readonly IGameProviderRepository _gameProviderRepository = gameProviderRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<Result<List<GameProviderDto>>> Handle(GetGameProvidersQuery request, CancellationToken cancellationToken)
    {
        var gameProviders = await _gameProviderRepository.GetGameProvidersAsync(request.GameType, cancellationToken);

        return _mapper.Map<List<GameProviderDto>>(gameProviders);
    }
}
