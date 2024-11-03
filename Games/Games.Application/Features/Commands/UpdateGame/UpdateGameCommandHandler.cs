using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Shared;
using Games.Application.Interfaces;
using Games.Domain.Errors;

namespace Games.Application.Features.Commands.UpdateGame;

public class UpdateGameCommandHandler(
    IGameProviderRepository gameProviderRepository,
    IGameRepository gameRepository,
    IUnitOfWork unitOfWork
    ) : ICommandQueryHandler<UpdateGameCommand>
{
    private readonly IGameProviderRepository _gameProviderRepository = gameProviderRepository;
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Result> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
    {
        var gameProvider = await _gameProviderRepository.GetGameProviderByIdAsync(request.GameProviderId, cancellationToken);

        if (gameProvider is null)
            return Result.Failure(GameDomainErrors.ProviderNotFound);

        var game = await _gameRepository.GetGameByIdAsync(request.Id, cancellationToken);

        if (game is null)
            return Result.Failure(GameDomainErrors.GameNotFound);

        game.UpdateGameDetails(request.GameProviderId, request.Name, request.RealUrl, request.GameId, request.ImageUrl, request.ForTesting, request.IsDisabled);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
