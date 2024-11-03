using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Shared;
using Games.Application.Interfaces;
using Games.Domain.Entities;
using Games.Domain.Errors;

namespace Games.Application.Features.Commands.AddGame;

public class AddGameCommandHandler(
    IGameProviderRepository gameProviderRepository,
    IGameRepository gameRepository,
    IUnitOfWork unitOfWork
    ) : ICommandQueryHandler<AddGameCommand>
{
    private readonly IGameProviderRepository _gameProviderRepository = gameProviderRepository;
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Result> Handle(AddGameCommand request, CancellationToken cancellationToken)
    {
        var gameProvider = await _gameProviderRepository.GetGameProviderByIdAsync(request.GameProviderId, cancellationToken);

        if (gameProvider is null)
            return Result.Failure(GameDomainErrors.ProviderNotFound);

        Game game = new(request.GameProviderId, request.Name, request.RealUrl, request.GameId, request.ImageUrl);

        await _gameRepository.AddAsync(game, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
