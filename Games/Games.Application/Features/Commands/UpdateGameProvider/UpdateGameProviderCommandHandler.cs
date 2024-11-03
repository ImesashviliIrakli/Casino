using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Shared;
using Games.Application.Interfaces;
using Games.Domain.Errors;

namespace Games.Application.Features.Commands.UpdateGameProvider;

public class UpdateGameProviderCommandHandler : ICommandQueryHandler<UpdateGameProviderCommand>
{
    private readonly IGameProviderRepository _gameProviderRepository;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateGameProviderCommandHandler(IGameProviderRepository gameProviderRepository, IUnitOfWork unitOfWork)
    {
        _gameProviderRepository = gameProviderRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(UpdateGameProviderCommand request, CancellationToken cancellationToken)
    {
        var gameProvider = await _gameProviderRepository.GetGameProviderByIdAsync(request.GameProviderId, cancellationToken);

        if (gameProvider is null)
            return Result.Failure(GameDomainErrors.ProviderNotFound);

        gameProvider.UpdateProviderDetails(request.Name, request.ViewName, request.GameType, request.ForTesting, request.ImageUrl);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
