using BuildingBlocks.Applictaion.Features;
using BuildingBlocks.Applictaion.Interfaces;
using BuildingBlocks.Domain.Shared;
using Games.Application.Interfaces;
using Games.Domain.Errors;
using System.Windows.Input;

namespace Games.Application.Features.Commands.DisableGameProvider;

public class DisableGameProviderCommandHandler : ICommandQueryHandler<DisableGameProviderCommand>
{
    private readonly IGameProviderRepository _gameProviderRepository;
    private readonly IUnitOfWork _unitOfWork;
    public DisableGameProviderCommandHandler(IGameProviderRepository gameProviderRepository, IUnitOfWork unitOfWork)
    {
        _gameProviderRepository = gameProviderRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(DisableGameProviderCommand request, CancellationToken cancellationToken)
    {
        var gameProvider = await _gameProviderRepository.GetGameProviderByIdAsync(request.GameProviderId, cancellationToken);

        if (gameProvider is null)
            return Result.Failure(GameDomainErrors.ProviderNotFound);

        gameProvider.UpdateIsDisabled(request.IsDisabled);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
