using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Shared;
using Games.Application.Interfaces;
using Games.Domain.Errors;

namespace Games.Application.Features.Commands.TestModeGameProvider;

public class TestModeGameProviderCommandHandler : ICommandQueryHandler<TestModeGameProviderCommand>
{
    private readonly IGameProviderRepository _gameProviderRepository;
    private readonly IUnitOfWork _unitOfWork;
    public TestModeGameProviderCommandHandler(IGameProviderRepository gameProviderRepository, IUnitOfWork unitOfWork)
    {
        _gameProviderRepository = gameProviderRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(TestModeGameProviderCommand request, CancellationToken cancellationToken)
    {
        var gameProvider = await _gameProviderRepository.GetGameProviderByIdAsync(request.GameProviderId, cancellationToken);

        if (gameProvider is null)
            return Result.Failure(GameDomainErrors.ProviderNotFound);

        gameProvider.UpdateForTesting(request.ForTesting);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
