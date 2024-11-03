using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Shared;
using Games.Application.Interfaces;

namespace Games.Application.Features.Commands.TestModeGame;

public class TestModeGameCommandHandler(
    IGameRepository gameRepository,
    IUnitOfWork unitOfWork
    ) : ICommandQueryHandler<TestModeGameCommand>
{
    private readonly IGameRepository _gameRepository = gameRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<Result> Handle(TestModeGameCommand request, CancellationToken cancellationToken)
    {
        var game = await _gameRepository.GetGameByIdAsync(request.GameId, cancellationToken);

        game.UpdateForTesting(request.ForTesting);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}