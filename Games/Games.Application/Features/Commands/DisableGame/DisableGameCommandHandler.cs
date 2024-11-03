using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Shared;
using Games.Application.Interfaces;

namespace Games.Application.Features.Commands.DisableGame;

public class DisableGameCommandHandler(
    IGameRepository gameRepository,
    IUnitOfWork unitOfWork
    ) : ICommandQueryHandler<DisableGameCommand>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Result> Handle(DisableGameCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetGameByIdAsync(request.GameId, cancellationToken);

        game.UpdateForTesting(request.IsDisabled);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
